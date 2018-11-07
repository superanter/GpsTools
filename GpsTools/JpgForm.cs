using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace GpsTools
{
    public partial class JpgForm : Form
    {
        string[][] strJpgIn;
        public JpgForm(string[][] strJpg)
        {
            strJpgIn = strJpg;
            InitializeComponent();
        }

        private void OpenJpgFile()		//打开源文件
        {
            string OpenFilter = "JEPG Files(*.jpg)|*.jpg";

            OpenJpg.Filter = OpenFilter;

            if (OpenJpg.ShowDialog() == DialogResult.OK)
            {
                //
            }
        }

        private void btnJpgOpen_Click(object sender, EventArgs e)
        {
            OpenJpgFile();
            if (OpenJpg.FileName != "")
            {
                SetJepgGps();
            }
        }

        private void SetJepgGps()
        {
            Image objImage = Image.FromFile(OpenJpg.FileName);

            PropertyItem[] propItems = new PropertyItem[5];

            propItems[0] = objImage.GetPropertyItem(0x9003);

            string strTime = "";
            for (int i = 0; i < 19; i++)
            {
                strTime += Convert.ToChar(propItems[0].Value[i]);
            }

            string[] strTimeS = strTime.Replace(' ',':').Split(':');
            DateTime timTime = new DateTime(Convert.ToInt16(strTimeS[0]), Convert.ToInt16(strTimeS[1]), Convert.ToInt16(strTimeS[2]), Convert.ToInt16(strTimeS[3]), Convert.ToInt16(strTimeS[4]), Convert.ToInt16(strTimeS[5]));

            propItems[1] = objImage.GetPropertyItem(0x5090);
            propItems[2] = objImage.GetPropertyItem(0x5090);
            propItems[3] = objImage.GetPropertyItem(0x5090);
            propItems[4] = objImage.GetPropertyItem(0x5090);

            propItems[1].Id = 1;
            propItems[1].Len = 2;
            propItems[1].Type = 2;
            propItems[1].Value = new byte[2];

            propItems[2].Id = 2;
            propItems[2].Len = 24;
            propItems[2].Type = 5;
            propItems[2].Value = new byte[24];
            propItems[2].Value[4] = 1;
            propItems[2].Value[12] = 1;
            propItems[2].Value[22] = 128;


            propItems[3].Id = 3;
            propItems[3].Len = 2;
            propItems[3].Type = 2;
            propItems[3].Value = new byte[2];

            propItems[4].Id = 4;
            propItems[4].Len = 24;
            propItems[4].Type = 5;
            propItems[4].Value = new byte[24];
            propItems[4].Value[4] = 1;
            propItems[4].Value[12] = 1;
            propItems[4].Value[22] = 128;

            int intTimeCont = 0;
            TimeSpan timTimeCont = new TimeSpan(99999, 0, 0, 0);
            for (int i = 0; i < strJpgIn.Length; i++)
            {
                string[] strTimeTemp = strJpgIn[i][0].Replace('.', ':').Replace(' ', ':').Split(':');
                DateTime timGpsTime = new DateTime(Convert.ToInt16(strTimeTemp[0]), Convert.ToInt16(strTimeTemp[1]), Convert.ToInt16(strTimeTemp[2]), Convert.ToInt16(strTimeTemp[3]), Convert.ToInt16(strTimeTemp[4]), Convert.ToInt16(strTimeTemp[5]));
                TimeSpan timContTemp = timGpsTime - timTime;
                TimeSpan DtimContTemp = timContTemp.Duration();
                TimeSpan DtimTimeCont = timTimeCont.Duration();
                if (DtimContTemp.TotalSeconds < DtimTimeCont.TotalSeconds)
                {
                    intTimeCont = i;
                    timTimeCont = timContTemp;
                }
            }

            //strJpgIn[intTimeCont]


            bool GpsOK = false;

            if (timTimeCont == new TimeSpan(0))
            {
                GpsOK = true;
            }
            else
            {
                DialogResult result = MessageBox.Show("照片时间和GPS数据时间不一致,\n相差" + timTimeCont.ToString().Replace(".","天"), "提醒", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    GpsOK = true;
                }
            }

            if (GpsOK)
            {
                //修改

                int[][] intV = new int[2][];
                double[] douV = new double[2];

                intV[0] = new int[4];
                intV[1] = new int[4];



                douV[0] = Convert.ToDouble(strJpgIn[intTimeCont][2]);
                douV[1] = Convert.ToDouble(strJpgIn[intTimeCont][4]);

                intV[0][0] = (int)douV[0];
                intV[1][0] = (int)douV[1];

                intV[0][1] = Convert.ToInt32((douV[0] - intV[0][0]) * 60);
                intV[1][1] = Convert.ToInt32((douV[1] - intV[1][0]) * 60);

                //intV[0][2] = Convert.ToInt32((((douV[0] - intV[0][0]) * 60 - intV[0][1]) * 60 + 4) * 0x800000);
                //intV[1][2] = Convert.ToInt32((((douV[1] - intV[1][0]) * 60 - intV[1][1]) * 60 + 21) * 0x800000);

                intV[0][2] = Convert.ToInt32((((douV[0] - intV[0][0]) * 60 - intV[0][1]) * 60) * 0x800000);
                intV[1][2] = Convert.ToInt32((((douV[1] - intV[1][0]) * 60 - intV[1][1]) * 60) * 0x800000);

                byte[][] bytOut = new byte[2][];
                bytOut[0] = new byte[4];
                bytOut[1] = new byte[4];
                string strTemp1 = intV[0][2].ToString("X").PadLeft(8,'0');
                string strTemp2 = intV[1][2].ToString("X").PadLeft(8, '0');


                bytOut[0][0] = Convert.ToByte(strTemp1.Remove(2, 6), 16);
                bytOut[1][0] = Convert.ToByte(strTemp2.Remove(2, 6), 16);

                bytOut[0][1] = Convert.ToByte(strTemp1.Remove(0, 2).Remove(2, 4), 16);
                bytOut[1][1] = Convert.ToByte(strTemp2.Remove(0, 2).Remove(2, 4), 16);

                bytOut[0][2] = Convert.ToByte(strTemp1.Remove(0, 4).Remove(2, 2), 16);
                bytOut[1][2] = Convert.ToByte(strTemp2.Remove(0, 4).Remove(2, 2), 16);

                bytOut[0][3] = Convert.ToByte(strTemp1.Remove(0, 6), 16);
                bytOut[1][3] = Convert.ToByte(strTemp2.Remove(0, 6), 16);

                propItems[1].Value[0] = Convert.ToByte(strJpgIn[intTimeCont][1][0]);

                propItems[2].Value[0] = (byte)intV[0][0];
                propItems[2].Value[8] = (byte)intV[0][1];
                propItems[2].Value[16] = bytOut[0][3];
                propItems[2].Value[17] = bytOut[0][2];
                propItems[2].Value[18] = bytOut[0][1];
                propItems[2].Value[19] = bytOut[0][0];

                propItems[3].Value[0] = Convert.ToByte(strJpgIn[intTimeCont][3][0]);

                propItems[4].Value[0] = (byte)intV[1][0];
                propItems[4].Value[8] = (byte)intV[1][1];
                propItems[4].Value[16] = bytOut[1][3];
                propItems[4].Value[17] = bytOut[1][2];
                propItems[4].Value[18] = bytOut[1][1];
                propItems[4].Value[19] = bytOut[1][0];

               
                //写入
                for (int i = 1; i < 5; i++)
                {
                    objImage.SetPropertyItem(propItems[i]);
                }
                objImage.Save(OpenJpg.FileName + ".GPS.JPG");
            }



            


            lblJpgMes.Text += "照片时间为:" + strTime + "\n";
            lblJpgMes.Text += "GPS数据时间为:" + strJpgIn[intTimeCont][0].ToString() + "\n";
            lblJpgMes.Text += "时间差为:" + timTimeCont.ToString().Replace(".", "天") + "\n\n";
            if (GpsOK)
            {
                lblJpgMes.Text += "已写入新文件";
            }
            else
            {
                lblJpgMes.Text += "未写入";
            }


        }
    }
}
