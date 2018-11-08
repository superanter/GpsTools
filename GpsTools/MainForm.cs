using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace GpsTools
{
    public partial class MainForm : Form
    {
        int couv = 0;
        bool isOK = false;
        GpsLog[][] strOut5 = new GpsLog[15][];
        int iChoise = 0;

        string sFileMode = "";
        double lat = 39.9073;
        double lon = 116.3912;
        int Zcot = 10;

        public MainForm()
        {
            InitializeComponent();
            webBrowserMap.Dock = DockStyle.Fill;
            this.tabPage5.Controls.Add(webBrowserMap);
        }

        private const double EARTH_RADIUS = 6378.137;

        #region 控件

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();

        }

            #region 轨迹导航

        private void btnPre_Click(object sender, EventArgs e)
        {
            ShowText(strOut5[iChoise], --couv);
            lblRound.Refresh();
            if (strOut5[iChoise][couv].isGSV == true)
            {
                lblOut5.Refresh();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ShowText(strOut5[iChoise], ++couv);
            lblRound.Refresh();
            if (strOut5[iChoise][couv].isGSV == true)
            {
                lblOut5.Refresh();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            couv = 0;
            ShowText(strOut5[iChoise], couv);
            lblRound.Refresh();
            if (strOut5[iChoise][couv].isGSV == true)
            {
                lblOut5.Refresh();
            }
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            couv = strOut5[iChoise].Length - 1;
            ShowText(strOut5[iChoise], couv);
            lblRound.Refresh();
            if (strOut5[iChoise][couv].isGSV == true)
            {
                lblOut5.Refresh();
            }
        }

        private void btnPre100_Click(object sender, EventArgs e)
        {
            if (couv >= 100)
            {
                couv = couv - 100;
            }
            else
            {
                couv = 0;
            }
            ShowText(strOut5[iChoise], couv);
            lblRound.Refresh();
            if (strOut5[iChoise][couv].isGSV == true)
            {
                lblOut5.Refresh();
            }
        }

        private void btnNext100_Click(object sender, EventArgs e)
        {
            if (couv <= strOut5[iChoise].Length - 101)
            {
                couv = couv + 100;
            }
            else
            {
                couv = strOut5[iChoise].Length - 1;
            }
            ShowText(strOut5[iChoise], couv);
            lblRound.Refresh();
            if (strOut5[iChoise][couv].isGSV == true)
            {
                lblOut5.Refresh();
            }
        }

        private void btnUpMap_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= couv; i++)
            {
                if (strOut5[iChoise][couv - i].isGSV == true)
                {
                    couv -= i;
                    ShowText(strOut5[iChoise], couv);
                    lblRound.Refresh();
                    lblOut5.Refresh();
                    break;
                }
            }
        }

        private void btnDownMap_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < strOut5[iChoise].Length - couv; i++)
            {
                if (strOut5[iChoise][couv + i].isGSV == true)
                {
                    couv += i;
                    ShowText(strOut5[iChoise], couv);
                    lblRound.Refresh();
                    lblOut5.Refresh();
                    break;
                }
            }
        }

            #endregion

            #region chk

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            iChoise = 0;
            getLatLon(strOut5[iChoise]);
            ShowC();
        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            iChoise = 1;
            getLatLon(strOut5[iChoise]);
            ShowC();
        }

        private void rdo3_CheckedChanged(object sender, EventArgs e)
        {
            iChoise = 2;
            getLatLon(strOut5[iChoise]);
            ShowC();
        }

        private void rdo4_CheckedChanged(object sender, EventArgs e)
        {
            iChoise = 3;
            getLatLon(strOut5[iChoise]);
            ShowC();
        }

        private void rdo5_CheckedChanged(object sender, EventArgs e)
        {
            iChoise = 4;
            getLatLon(strOut5[iChoise]);
            ShowC();
        }

        private void ChioseOpen(int iLength)
        {
            if (iLength == 5)
            {
                rdo5.Enabled = true;
            }
            if (iLength >= 4)
            {
                rdo4.Enabled = true;
            }
            if (iLength >= 3)
            {
                rdo3.Enabled = true;
            }
            if (iLength >= 2)
            {
                rdo2.Enabled = true;
            }
            if (iLength >= 1)
            {
                rdo1.Enabled = true;
            }

        }

            #endregion

            #region 按钮

        private void btnOpen_Click(object sender, EventArgs e)
        {
            iChoise = 0;
            btnRun.Enabled = false;
            txtMessage.Text = "";
            txtMessage.Refresh();
            OpenInputFile();
            if (dialogOpen.FileName != "")
            {
                GetInputFileMode(dialogOpen.FileName);
                toolStripStatusLabel2.Text = dialogOpen.FileName.Remove(0, dialogOpen.FileName.LastIndexOfAny(new char[] { '\\' }) + 1);
                isOK = false;

                if (sFileMode == "NMEA")
                {
                    strOut5[0] = Log2MessageNMEA(dialogOpen.FileName);
                    getLatLon(strOut5[0]);
                }
                else if (sFileMode == "CSV")
                {
                    btnRun.Enabled = true;
                    strOut5[0] = Log2MessageCSV(dialogOpen.FileName);
                    getLatLon(strOut5[0]);
                }
                else if (sFileMode == "CSV2")
                {
                    btnRun.Enabled = true;
                    strOut5[0] = Log2MessageCSV2(dialogOpen.FileName);
                    getLatLon(strOut5[0]);
                }
                else if (sFileMode == "CSV3")
                {
                    btnRun.Enabled = true;
                    strOut5[0] = Log2MessageCSV3(dialogOpen.FileName);
                    getLatLon(strOut5[0]);
                }
                else if (sFileMode == "Ozi")
                {
                    btnRun.Enabled = true;
                    strOut5[0] = Log2MessageOzi(dialogOpen.FileName);
                    getLatLon(strOut5[0]);
                }
                else if (sFileMode == "KLD1" || sFileMode == "KLD2" || sFileMode == "KLD3")
                {
                    btnRun.Enabled = true;
                    rdo1.Enabled = true;
                    rdo2.Enabled = false;
                    rdo3.Enabled = false;
                    rdo4.Enabled = false;
                    rdo5.Enabled = false;
                    rdo1.Checked = true;

                    strOut5 = Log2MessageKLD(dialogOpen.FileName);

                    ChioseOpen(strOut5.Length);
                }
                else if (sFileMode == "KLD_log")
                {
                    btnRun.Enabled = true;
                    strOut5[0] = Log2MessageKLDLOG(dialogOpen.FileName);
                    getLatLon(strOut5[0]);
                }
                ShowC();
            }
            if (strOut5[0].Length != 0)
            {
                int x = strOut5[iChoise].Length - 1;
                double vVv = new double();
                for (int i = 0; i < x; i++)
                {
                    vVv += strOut5[0][i].vV;
                }

                //lblMessage1.Text = "开始时间: " + strOut5[0][0].UtcTime.AddHours(8).ToString("s").Replace("T", " ") + "\n";
                //lblMessage1.Text += "结束时间: " + strOut5[0][x].UtcTime.AddHours(8).ToString("s").Replace("T", " ") + "\n";
                //lblMessage1.Text += "所用时间: " + (strOut5[0][x].UtcTime - strOut5[0][0].UtcTime).ToString().Replace(".","天") + "\n";
                //lblMessage1.Text += "行驶距离: " + vVv.ToString("F2") + "千米\n";
                //lblMessage1.Refresh();

                txtMessage.Text = "开始时间: " + strOut5[0][0].UtcTime.AddHours(8).ToString("s").Replace("T", " ") + "\r\n";
                txtMessage.Text += "结束时间: " + strOut5[0][x].UtcTime.AddHours(8).ToString("s").Replace("T", " ") + "\r\n";
                txtMessage.Text += "所用时间: " + (strOut5[0][x].UtcTime - strOut5[0][0].UtcTime).ToString().Replace(".", "天") + "\r\n";
                txtMessage.Text += "行驶距离: " + vVv.ToString("F2") + "千米\r\n";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            //lblMessage1.Refresh();
            if (sFileMode == "KLD1" || sFileMode == "KLD2" || sFileMode == "KLD3")
            {
                Kld2NMEA(dialogOpen.FileName);
            }
            else if (sFileMode == "Ozi")
            {
                Ozi2NMEA(dialogOpen.FileName);
            }
            else if (sFileMode == "CSV" || sFileMode == "CSV2" || sFileMode == "CSV3")
            {
                CSV2NMEA(dialogOpen.FileName);
            }
            else if (sFileMode == "KLD_log")
            {
                KLDLOG2NMEA(dialogOpen.FileName);
            }
        }

        private void btnKCode_Click(object sender, EventArgs e)
        {
            KCodeForm KForm = new KCodeForm();
            if (KForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            KForm.Dispose();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (sFileMode == "CSV")
            {
                txtMessage.Text = "";
                //lblMessage1.Refresh();
                BiJiao(dialogOpen.FileName);
            }
        }

        private void btnOld_Click(object sender, EventArgs e)
        {
            OldForm OlForm = new OldForm();
            if (OlForm.ShowDialog(this) == DialogResult.OK)
            {
                //We would apply changes here since the user accepted them
            }
            OlForm.Dispose();
        }

            #endregion

            #region 绘图区

        private void lblRound_Paint(object sender, PaintEventArgs e)
        {
            if (isOK)
            {
                ShowPic(e);
            }
        }

        private void lblOut5_Paint(object sender, PaintEventArgs e)
        {
            if (isOK)
            {
                ShowPicWX(e);
            }
        }

            #endregion

        #endregion

        #region Open

        private void OpenInputFile()		//打开源文件
        {
            string OpenFilter = "";

            OpenFilter += "All Log Files(*.log;*.nmea;*.cld;*.csv;*.plt;*.txt)|*.log;*.nmea;*.cld;*.csv;*.plt;*.txt|";
            OpenFilter += "GPS Log Files(*.log)|*.log|";
            OpenFilter += "NMEA Log Files(*.nmea)|*.nmea|";
            OpenFilter += "KLD Log Files(*.cld)|*.cld|";
            OpenFilter += "CSV Log Files(*.cld)|*.csv|";
            OpenFilter += "plt Log Files(*.plt)|*.plt|";
            OpenFilter += "Text Files(*.txt)|*.txt|";
            OpenFilter += "All Files(*.*)|*.*";

            dialogOpen.Filter = OpenFilter;

            if (dialogOpen.ShowDialog() == DialogResult.OK)
            {
                //
            }
        }

        private void GetInputFileMode(string strInputName)
        {
            grpKLD.Enabled = false;

            try
            {
                FileStream sri = new FileStream(strInputName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(sri);
                FileInfo FiInput = new FileInfo(strInputName);
                string strFileName = FiInput.Name.Remove(FiInput.Name.Length - FiInput.Extension.Length);
                byte[] chaTemp = r.ReadBytes(3);
                string txtString = Convert.ToString(chaTemp[0], 16).ToUpper() + Convert.ToString(chaTemp[1], 16).ToUpper() + Convert.ToString(chaTemp[2], 16).ToUpper();
                byte[] tttt = r.ReadBytes(21);
                string txtStringN = new string(r.ReadChars(3));
                sri.Close();

                if (FiInput.Name.Remove(7,FiInput.Name.Length - 7) == "log_out")
                {
                    sFileMode = "KLD_log";
                    grpKLD.Enabled = false;
                    toolStripStatusLabel3.Text = "凯立德log";
                }
                else if (txtString == "436172")  //"Car"
                {
                    sFileMode = "KLD1";
                    grpKLD.Enabled = true;
                    toolStripStatusLabel3.Text = "凯立德1";
                }
                else if (txtString == "6AD79F")
                {
                    sFileMode = "KLD3";
                    grpKLD.Enabled = true;
                    toolStripStatusLabel3.Text = "凯立德3";
                }
                else if (txtStringN == "Car")
                {
                    sFileMode = "KLD2";
                    grpKLD.Enabled = true;
                    toolStripStatusLabel3.Text = "凯立德2";
                }
                else if (txtString == "4F7A69")
                {
                    sFileMode = "Ozi";
                    toolStripStatusLabel3.Text = "Ozi";
                }
                else if (txtString == "40536F" || txtString == "244750")  //"@So","$GP"
                {
                    sFileMode = "NMEA";
                    toolStripStatusLabel3.Text = "NMEA";
                }
                else if (txtString == "494E44") //IND
                {
                    sFileMode = "CSV";
                    toolStripStatusLabel3.Text = "CSV";
                }
                else if (txtString == "22E590") //IND
                {
                    sFileMode = "CSV2";
                    toolStripStatusLabel3.Text = "CSV2";
                }
                else if (txtString == "6C6F6E") //IND
                {
                    sFileMode = "CSV3";
                    toolStripStatusLabel3.Text = "CSV3";
                }
                else
                {
                    sFileMode = "NMEA";
                    toolStripStatusLabel3.Text = "NEMA";
                }
            }
            catch
            {
            }
        }

        #endregion

        #region jisuan

        private struct GpsLog
        {
            public bool isGSV;
            public string[] strGGA;
            public string[] strRMC;
            public string[] strVTG;
            public string[] strGSA;
            public string[][] strGSV;

            public DateTime UtcTime;
            public Roult Latitude;
            public Roult Longitude;
            public double high;
            public double hangxiangT;
            public double hangxiangM;
            public double speedN;
            public double speedK;

            public GSV_point[] GSV_Point;
            public int[] xPoint;

            public struct Roult
            {
                public string Str;
                public int DD;
                public double MM;
                public double value;
            }

            public struct GSV_point
            {
                public int ID;
                public int ID_2;
                public int ID_3;
                public int ID_4;

            }

            public double vV;
        }

        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        public static double GetDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);
            double s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * EARTH_RADIUS;
            //s = Math.Round(s * 10000) / 10000;
            return s;
        }

        private void Start()
        {
            double iX1 = 5.928;
            double iY1 = 4.029;
            txtX1.Text = iX1.ToString();
            txtY1.Text = iY1.ToString();

            if (chkGoogleMap.Checked)
            {
                Map_Load(lat, lon, Zcot);
            }
        }

        private string GetString(string[] strString)
        {
            int i = new int();
            string strOutput = "";
            string[] strTemp = strString[4].Split('.');
            string[] strOut = new string[6];
            for (i = 0; i < 4; i++)
            {
                strOut[i] = strString[i];
            }
            for (i = 0; i < 2; i++)
            {
                strOut[i + 4] = strTemp[i];
            }

            string[] strO = GetDatabase(strOut);

            for (i = 0; i < strO.Length; i++)
            {
                strOutput += strO[i] + " \t";
            }
            return strOutput;
        }

        private string[] GetDatabase(string[] strString)
        {
            string[] strOut = new string[6];

            double[] intStr = new double[6];
            string[] strDate = new string[6];
            for (int i = 0; i < 6; i++)
            {

                intStr[i] = Convert.ToDouble(strString[i]);
                strOut[i] = intStr[i].ToString();
            }
            double intStr3 = ((double)((int)(intStr[3] / 3.28084 * 100))) / 100;
            strOut[3] = intStr3.ToString() + "m";
            int mySeconds = (int)(myRound(intStr[5] * 0.0864, 0) + 8 * 60 * 60);

            DateTime numDate = new DateTime(1899, 12, 30).AddDays(intStr[4]).AddSeconds(mySeconds);

            strDate[0] = numDate.Year.ToString();
            strDate[1] = numDate.Month.ToString();
            strDate[2] = numDate.Day.ToString();
            strDate[3] = numDate.Hour.ToString();
            strDate[4] = numDate.Minute.ToString();
            strDate[5] = numDate.Second.ToString();

            for (int i = 0; i < 6; i++)
            {
                if (strDate[i].Length == 1)
                {
                    strDate[i] = "0" + strDate[i];
                }
            }

            strOut[4] = strDate[0] + "/" + strDate[1] + "/" + strDate[2];

            strOut[5] = strDate[3] + ":" + strDate[4] + ":" + strDate[5];
            return strOut;

        }

        private double myRound(double v, int x)
        {
            bool isNegative = false;
            //如果是负数
            if (v < 0)
            {
                isNegative = true;
                v = -v;
            }

            int IValue = 1;
            for (int i = 1; i <= x; i++)
            {
                IValue = IValue * 10;
            }
            double Int = Math.Round(v * IValue + 0.5, 0);
            v = Int / IValue;

            if (isNegative)
            {
                v = -v;
            }

            return v;
        }

        private string myChk(string strInput)
        {
            int intOut = 0;
            for (int i = 0; i < strInput.Length; i++)
            {
                intOut = intOut ^ strInput[i];
            }
            return Convert.ToString(intOut, 16).ToUpper();
        }

        #endregion

        #region Show

        private void ShowText(GpsLog[] strOut, int intCouv)
        {

            txtOut2.Text = "";
            txtOut3.Text = "";
            double vVv = new double();
            if (strOut.Length != 0)
            {
                toolStripStatusLabel1.Text = (intCouv + 1).ToString() + "/" + strOut.Length.ToString();
            }
            else
            {
                toolStripStatusLabel1.Text = "无有效数据";
            }
            if (strOut.Length == 0)
            {
                btnPre.Enabled = false;
                btnNext.Enabled = false;
                btnFirst.Enabled = false;
                btnLast.Enabled = false;
                btnPre100.Enabled = false;
                btnNext100.Enabled = false;
                btnUpMap.Enabled = false;
                btnDownMap.Enabled = false;
            }
            else if (intCouv == 0)
            {
                btnPre.Enabled = false;
                btnNext.Enabled = true;
                btnFirst.Enabled = false;
                btnLast.Enabled = true;
                btnPre100.Enabled = false;
                btnNext100.Enabled = true;
                btnUpMap.Enabled = false;
                btnDownMap.Enabled = true;
            }
            else if (intCouv == strOut.Length - 1)
            {
                btnPre.Enabled = true;
                btnNext.Enabled = false;
                btnFirst.Enabled = true;
                btnLast.Enabled = false;
                btnPre100.Enabled = true;
                btnNext100.Enabled = false;
                btnUpMap.Enabled = true;
                btnDownMap.Enabled = false;
            }
            else
            {
                btnPre.Enabled = true;
                btnNext.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
                btnPre100.Enabled = true;
                btnNext100.Enabled = true;
                btnUpMap.Enabled = true;
                btnDownMap.Enabled = true;
            }

            if (strOut.Length != 0)
            {
                txtOut2.Text += "UTC 时间: " + strOut[intCouv].UtcTime.ToString("s").Replace("T", " ") + "\n";
                txtOut2.Text += "北京时间: " + strOut[intCouv].UtcTime.AddHours(8).ToString("s").Replace("T", " ") + "\n";
                txtOut2.Text += "经度: " + strOut[intCouv].Longitude.Str + " " + strOut[intCouv].Longitude.DD.ToString("D3") + "°" + strOut[intCouv].Longitude.MM.ToString("00.000000") + "′ " + strOut[intCouv].Longitude.value.ToString("000.000000") + "°\n";
                txtOut2.Text += "纬度: " + strOut[intCouv].Latitude.Str + "  " + strOut[intCouv].Latitude.DD.ToString("D2") + "°" + strOut[intCouv].Latitude.MM.ToString("00.000000") + "′  " + strOut[intCouv].Latitude.value.ToString("00.000000") + "°\n";

                txtOut2.Text += "海拔高度: " + strOut[intCouv].high.ToString("F3") + "m\n";

                txtOut2.Text += "地面航向: 真北" + strOut[intCouv].hangxiangT.ToString("F1") + "° 磁北" + strOut[intCouv].hangxiangM.ToString("F1") + "°\n";
                txtOut2.Text += "地面速率: " + strOut[intCouv].speedN.ToString("F2") + "节," + strOut[intCouv].speedK.ToString("F2") + "千米/小时\n";
                if (intCouv != 0)
                {
                    txtOut2.Text += "计算速度: " + (strOut[intCouv].vV / (strOut[intCouv].UtcTime - strOut[intCouv - 1].UtcTime).TotalSeconds * 3600).ToString("F2") + "千米/小时\n\n";
                }
                else
                {
                    txtOut2.Text += "计算速度: 0.00千米/小时\n\n";
                }
                for (int i = 0; i < intCouv; i++)
                {
                    vVv += strOut[i].vV;
                }
                txtOut2.Text += "行驶距离: " + vVv.ToString("F2") + "千米\n";
                txtOut2.Text += "行驶时间: " + (strOut[intCouv].UtcTime - strOut[0].UtcTime) + "\n";


                //°′″
                if (strOut[intCouv].xPoint != null)
                {
                    txtOut2.Text += "\n定位卫星(" + strOut[intCouv].xPoint.Length + "): ";
                    for (int i = 0; i < strOut[intCouv].xPoint.Length; i++)
                    {
                        txtOut2.Text += strOut[intCouv].xPoint[i].ToString() + " ";
                    }
                }



                if (strOut[intCouv].isGSV == true)
                {
                    txtOut1.Text = "";

                    txtOut3.Text += "\n 可见卫星(" + strOut[intCouv].GSV_Point.Length + "): \n\n";
                    for (int i = 0; i < strOut[intCouv].GSV_Point.Length; i++)
                    {
                        txtOut3.Text += " " + strOut[intCouv].GSV_Point[i].ID + "(" + strOut[intCouv].GSV_Point[i].ID_2 + "," + strOut[intCouv].GSV_Point[i].ID_3 + "," + strOut[intCouv].GSV_Point[i].ID_4 + ")\n";
                        if (strOut[intCouv].GSV_Point[i].ID_2 != 0 && strOut[intCouv].GSV_Point[i].ID_3 != 0 && strOut[intCouv].GSV_Point[i].ID_4 != 0)
                        {
                            txtOut1.Text += strOut[intCouv].GSV_Point[i].ID + "(" + strOut[intCouv].GSV_Point[i].ID_2 + "," + strOut[intCouv].GSV_Point[i].ID_3 + "," + strOut[intCouv].GSV_Point[i].ID_4 + ")\n";
                        }
                    }
                }

            }
        }

        private void ShowPic(PaintEventArgs e)
        {
            double Xmin = new double();
            double Ymin = new double();
            double Xmax = new double();
            double Ymax = new double();

            double Xcot = new double();
            double Ycot = new double();
            double Acot = new double();

            double AcotI = new double();

            Point[] myArray = new Point[strOut5[iChoise].Length];
            GraphicsPath path0 = new GraphicsPath();
            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2 = new GraphicsPath();

            Ymin = strOut5[iChoise][0].Latitude.value;
            Xmin = strOut5[iChoise][0].Longitude.value;
            Ymax = strOut5[iChoise][0].Latitude.value;
            Xmax = strOut5[iChoise][0].Longitude.value;

            for (int intCouv = 1; intCouv < strOut5[iChoise].Length; intCouv++)
            {
                if (strOut5[iChoise][intCouv].Latitude.value < Ymin)
                {
                    Ymin = strOut5[iChoise][intCouv].Latitude.value;
                }
                if (strOut5[iChoise][intCouv].Longitude.value < Xmin)
                {
                    Xmin = strOut5[iChoise][intCouv].Longitude.value;
                }
                if (strOut5[iChoise][intCouv].Latitude.value > Ymax)
                {
                    Ymax = strOut5[iChoise][intCouv].Latitude.value;
                }
                if (strOut5[iChoise][intCouv].Longitude.value > Xmax)
                {
                    Xmax = strOut5[iChoise][intCouv].Longitude.value;
                }
            }

            Xcot = Xmax - Xmin;
            Ycot = Ymax - Ymin;

            Acot = Xcot > Ycot ? Xcot : Ycot;
            if (Acot == 0.0)
            {
                Acot = 1;
            }
            AcotI = Acot / (lblRound.Width < lblRound.Height ? lblRound.Width : lblRound.Height - 20);

            for (int intCouv = 0; intCouv < strOut5[iChoise].Length; intCouv++)
            {
                myArray[intCouv] = new Point((Convert.ToInt32((strOut5[iChoise][intCouv].Longitude.value - Xmin) / AcotI + lblRound.Width / 2 - Xcot / AcotI / 2)),
               lblRound.Height - (Convert.ToInt32((strOut5[iChoise][intCouv].Latitude.value - Ymin) / AcotI + lblRound.Height / 2 - Ycot / AcotI / 2)));
                path0.AddEllipse(myArray[intCouv].X - 1, myArray[intCouv].Y - 1, 2, 2);
                if (intCouv == 0 || intCouv == strOut5[iChoise].Length - 1)
                {
                    path1.AddEllipse(myArray[intCouv].X - 2, myArray[intCouv].Y - 2, 4, 4);
                }

            }

            path2.AddEllipse(myArray[couv].X - 3, myArray[couv].Y - 3, 6, 6); 
            
            e.Graphics.DrawLines(new Pen(Color.FromArgb(255, 255, 0, 0), 1), myArray);  //路径连线
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 0, 0, 0), 1), path0);       //GPS数据点
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 0, 0, 255), 2), path1);     //起止点
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 255, 0, 0), 4), path2);     //当前点
        }

        private void ShowPicWX(PaintEventArgs e)
        {
            GraphicsPath path0 = new GraphicsPath();
            GraphicsPath path1 = new GraphicsPath();
            GraphicsPath path2 = new GraphicsPath();
            GraphicsPath path3 = new GraphicsPath();
            int OutWidth = lblOut5.Width > lblOut5.Height ? lblOut5.Height : lblOut5.Width;

            path0.AddEllipse(10, 10, OutWidth - 20, OutWidth - 20);
            path0.AddEllipse((OutWidth - 20) / 6 + 10, (OutWidth - 20) / 6 + 10, (OutWidth - 20) / 6 * 4, (OutWidth - 20) / 6 * 4);
            path0.AddEllipse((OutWidth - 20) / 3 + 10, (OutWidth - 20) / 3 + 10, (OutWidth - 20) / 6 * 2, (OutWidth - 20) / 6 * 2);
            path0.AddLine(10, OutWidth / 2, OutWidth - 10, OutWidth / 2);
            path0.AddLine(OutWidth / 2, OutWidth / 2, OutWidth / 2, OutWidth / 2);
            path0.AddLine(OutWidth / 2, 10, OutWidth / 2, OutWidth - 10);

            if (strOut5[iChoise][couv].isGSV == true)
            {
                for (int i = 0; i < strOut5[iChoise][couv].GSV_Point.Length; i++)
                {
                    int tX = Convert.ToInt32(Math.Cos(rad(strOut5[iChoise][couv].GSV_Point[i].ID_3 - 90)) * (90 - strOut5[iChoise][couv].GSV_Point[i].ID_2) * (OutWidth / 2 - 10) / 90 + OutWidth / 2);
                    int tY = Convert.ToInt32(Math.Sin(rad(strOut5[iChoise][couv].GSV_Point[i].ID_3 - 90)) * (90 - strOut5[iChoise][couv].GSV_Point[i].ID_2) * (OutWidth / 2 - 10) / 90 + OutWidth / 2);
                    if (strOut5[iChoise][couv].GSV_Point[i].ID_4 != 0)
                    {
                        path1.AddEllipse(tX - 2, tY - 2, 4, 4);
                    }
                    else
                    {
                        path2.AddEllipse(tX - 2, tY - 2, 4, 4);
                    }
                }
            }

            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 0, 0, 0), 1), path0);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 255, 0, 0), 3), path1);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 0, 0, 255), 2), path2);



        }

        private void ShowC()
        {
            if (strOut5[iChoise] != null)
            {
                if (strOut5[iChoise].Length > 1)
                {
                    isOK = true;
                }
                btnPre.Enabled = false;
                if (strOut5[iChoise].Length > 1)
                {
                    btnNext.Enabled = true;
                }
                couv = 0;
                txtOut1.Text = "";
                ShowText(strOut5[iChoise], couv);
                lblRound.Refresh();
                if (isOK && strOut5[iChoise][couv].isGSV == true)
                {
                    lblOut5.Refresh();
                }
            }
        }

        #endregion

        #region change

        private GpsLog[] Log2MessageKLDLOG(string strInputName)
        {
            int z = 0;
            string[][] strIn = new string[0x60 * 60 * 24 * 6][];

            try
            {

                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);

                for (int i = 0; i < strIn.Length; i++)
                {
                    string strRead = sr.ReadLine();
                    string[] strTempa = strRead.Replace("=", " ").Replace("[", "").Replace("]", " ").Replace("(", " ").Replace(")", " ").Replace(",", " ").Replace("-->", " ").Replace("    ", " ").Replace("   ", " ").Replace("  ", " ").Split(' ');
                    strIn[i] = strTempa;
                    if (strTempa[2] == "Longitude")
                    {
                        z++;
                    }
                }
                sr.Close();
            }
            catch { }
                                     
            GpsLog[] strTemp = new GpsLog[z];
            int x = 0;
            strTemp[0].strRMC = new string[14];
            strTemp[0].strGGA = new string[16];
            //strTemp[0].strGSA = new string[19];
            for (int i = 0; i < strIn.Length; i++)
            {
                try
                {
                    if (strIn[i] == null)
                        break;
                    if (strIn[i][1] == "onLocationChanged")
                    {

                        strTemp[x].strRMC[0] = "$GPRMC";
                        strTemp[x].strRMC[2] = "A";
                        strTemp[x].strRMC[10] = "";
                        strTemp[x].strRMC[11] = "";
                        strTemp[x].strRMC[12] = "A";
                        strTemp[x].strRMC[13] = "";

                        strTemp[x].strGGA[0] = "$GPGGA";
                        strTemp[x].strGGA[6] = "2";
                        strTemp[x].strGGA[7] = "0";
                        strTemp[x].strGGA[8] = "1.0";
                        strTemp[x].strGGA[10] = "M";
                        strTemp[x].strGGA[11] = "0.0";
                        strTemp[x].strGGA[12] = "M";
                        strTemp[x].strGGA[13] = "";
                        strTemp[x].strGGA[14] = "";
                        strTemp[x].strGGA[15] = "";

                        if (strIn[i][2] == "utcTime")
                        {
                        }
                        else if (strIn[i][2] == "locTime")
                        {
                            strTemp[x].strRMC[1] = strIn[i][6].PadLeft(2, '0') + strIn[i][7].PadLeft(2, '0') + strIn[i][8].PadLeft(2, '0');
                            strTemp[x].strGGA[1] = strTemp[x].strRMC[1];

                            strTemp[x].strRMC[9] = strIn[i][5].PadLeft(2, '0') + strIn[i][4].PadLeft(2, '0') + strIn[i][3].Remove(0,2);

                        }
                        else if (strIn[i][2] == "Longitude")
                        {
                            double tLon = Convert.ToDouble(strIn[i][4]);
                            double tLan = Convert.ToDouble(strIn[i][5]);
                            strTemp[x].strRMC[5] = ((int)tLon).ToString("000") + ((tLon - (int)tLon)*60).ToString("00.0000");
                            strTemp[x].strRMC[3] = ((int)tLan).ToString("00") + ((tLan - (int)tLan)*60).ToString("00.0000");
                            strTemp[x].strGGA[4] = strTemp[x].strRMC[5];
                            strTemp[x].strGGA[2] = strTemp[x].strRMC[3];

                            strTemp[x].strRMC[4] = "N";
                            strTemp[x].strRMC[6] = "E";
                            strTemp[x].strGGA[3] = strTemp[x].strRMC[4];
                            strTemp[x].strGGA[5] = strTemp[x].strRMC[6];

                        }
                        else if (strIn[i][2] == "hasAltitude")
                        {
                            if (strIn[i][3] == "true")
                            {
                                strTemp[x].strGGA[9] = (Convert.ToDouble(strIn[i][5])).ToString("0.0");
                            }
                            else
                            {
                                strTemp[x].strGGA[9] = "0.0";
                            }
                        }
                        else if (strIn[i][2] == "hasBearing")
                        {
                            if (strIn[i][3] == "true")
                            {
                                strTemp[x].strRMC[8] = (Convert.ToDouble(strIn[i][5])).ToString("0.0");
                            }
                            else
                            {
                                strTemp[x].strRMC[8] = "0";
                            }
                        }
                        else if (strIn[i][2] == "hasSpeed")
                        {
                            if (strIn[i][3] == "true")
                            {
                                strTemp[x].strRMC[7] = (Convert.ToDouble(strIn[i][5]) * 1.852).ToString("0.000"); ;
                            }
                            else
                            {
                                strTemp[x].strRMC[7] = "0.000";
                            }

                            if (x != 0)
                            {
                                strTemp[x] = ReadData(strTemp[x], strTemp[x - 1], x);
                            }
                            else
                            {
                                strTemp[x] = ReadData(strTemp[x], strTemp[x], x);
                            }

                            x++;
                            strTemp[x].strRMC = new string[14];
                            strTemp[x].strGGA = new string[16];
                            //strTemp[x].strGSA = new string[19];
                        }
                    }
                }
                catch { }
            }

            GpsLog[] strOut = new GpsLog[x];
            for (int i = 0; i < x; i++)
            {
                strOut[i] = strTemp[i];
            }
            return strOut;
        }

        private GpsLog[] Log2MessageNMEA(string strInputName)
        {
            int z = 0;
            string[][] strIn = new string[0x60 * 60 * 24 * 6][];

            try
            {

                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);

                for (int i = 0; i < strIn.Length; i++)
                {
                    string strRead = sr.ReadLine();
                    string[] strTempa = strRead.Replace("*", ",").Split(',');
                    strTempa[0] = strTempa[0].Remove(0, strTempa[0].IndexOf(';') + 1);

                    if (strTempa[0].Length == 6 && strTempa[0].Remove(3, 3) == "$GP")
                    {
                        strIn[z] = strTempa;
                        z++;
                    }
                }
                sr.Close();
            }
            catch { }

            GpsLog[] strTemp = new GpsLog[z];
            int x = 0;
            for (int i = 0; i < z; i++)
            {
                try
                {
                    if (strIn[i][0] != "$GPGSV")
                    {
                        if ((i < z - 3 ) && strIn[i][0] == "$GPGGA" && strIn[i + 1][0] == "$GPRMC" && strIn[i + 2][0] == "$GPVTG" && strIn[i + 3][0] == "$GPGSA")
                        {
                            strTemp[x].strGGA = strIn[i];
                            strTemp[x].strRMC = strIn[i + 1];
                            strTemp[x].strVTG = strIn[i + 2];
                            strTemp[x].strGSA = strIn[i + 3];
                            i = i + 3;
                        }
                        else if ((i < z - 2 ) && strIn[i][0] == "$GPRMC" && strIn[i + 1][0] == "$GPGGA" && strIn[i + 2][0] == "$GPGSA")
                        {
                            strTemp[x].strRMC = strIn[i];
                            strTemp[x].strGGA = strIn[i + 1];
                            strTemp[x].strGSA = strIn[i + 2];
                            i = i + 2;
                        }
                        else if ((i < z - 3) && strIn[i][0] == "$GPGGA" && strIn[i + 1][0] == "$GPVTG" && strIn[i + 2][0] == "$GPRMC" && strIn[i + 3][0] == "$GPGSA")
                        {
                            strTemp[x].strGGA = strIn[i];
                            strTemp[x].strVTG = strIn[i + 1];
                            strTemp[x].strRMC = strIn[i + 2];
                            strTemp[x].strGSA = strIn[i + 3];
                            i = i + 3;
                        }
                        else if (((i < z - 2) && (strIn[i][0] == "$GPRMC" && strIn[i + 1][0] == "$GPVTG" && strIn[i+2][0] == "$GPRMC"))
                              || ((i == z - 2) && (strIn[i - 1][0] == "$GPVTG" && strIn[i][0] == "$GPRMC" && strIn[i + 1][0] == "$GPVTG")))
                        {
                            strTemp[x].strRMC = strIn[i];
                            strTemp[x].strVTG = strIn[i + 1];
                            i = i + 1;
                        }
                        else if (((i < z - 1) && (strIn[i][0] == "$GPRMC" && strIn[i + 1][0] == "$GPRMC"))
                              || ((i == z - 1) && (strIn[i - 1][0] == "$GPRMC" && strIn[i][0] == "$GPRMC")))
                        {
                            strTemp[x].strRMC = strIn[i];
                        }
                        else if ((i < z - 1) && strIn[i][0] == "$GPRMC" && strIn[i + 1][0] == "$GPGGA")
                        {
                            strTemp[x].strRMC = strIn[i];
                            strTemp[x].strGGA = strIn[i + 1];

                        }
                        if (strTemp[x].strRMC[2] == "A")
                        {
                            if (x != 0)
                            {
                                strTemp[x] = ReadData(strTemp[x], strTemp[x - 1], x);
                            }
                            else
                            {
                                strTemp[x] = ReadData(strTemp[x], strTemp[x], x);
                            }

                            x++;
                        }
                    }
                    else if (strIn[i][0] == "$GPGSV" && strIn[i][2] == "1")
                    {
                        strTemp[x].isGSV = true;
                        strTemp[x].strGSV = new string[Convert.ToInt32(strIn[i][1])][];
                        for (int j = 0; j < strTemp[x].strGSV.Length; j++)
                        {
                            strTemp[x].strGSV[j] = strIn[i + j];
                        }

                        strTemp[x].GSV_Point = new GpsLog.GSV_point[Convert.ToInt32(strIn[i][3])];
                        for (int j = 0; j < strTemp[x].strGSV.Length; j++)
                        {
                            for (int jj = 0; jj < (strTemp[x].strGSV[j].Length - 5) / 4; jj++)
                            {
                                strTemp[x].GSV_Point[j * 4 + jj].ID = Convert.ToInt32("0" + strTemp[x].strGSV[j][4 + jj * 4]);
                                strTemp[x].GSV_Point[j * 4 + jj].ID_2 = Convert.ToInt32("0" + strTemp[x].strGSV[j][4 + jj * 4 + 1]);
                                strTemp[x].GSV_Point[j * 4 + jj].ID_3 = Convert.ToInt32("0" + strTemp[x].strGSV[j][4 + jj * 4 + 2]);
                                strTemp[x].GSV_Point[j * 4 + jj].ID_4 = Convert.ToInt32("0" + strTemp[x].strGSV[j][4 + jj * 4 + 3]);
                            }
                        }
                    }
                }
                catch { }
            }

            GpsLog[] strOut = new GpsLog[x];
            for (int i = 0; i < x; i++)
            {
                strOut[i] = strTemp[i];
            }
            return strOut;
        }

        private GpsLog[][] Log2MessageKLD(string strInputName)
        {
            int x = 0;
            double size = 3600000.0;
            string[][] strIn = new string[0x60 * 60 * 24 * 6][];
            GpsLog[][] gpsOut = new GpsLog[5][];
            int yyyy = 0;

            try
            {
                FileStream sri = new FileStream(strInputName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(sri);
                FileInfo FiInput = new FileInfo(strInputName);
                string strFileName = FiInput.Name.Remove(FiInput.Name.Length - FiInput.Extension.Length);
                int iMax = new int();
                if (sFileMode == "KLD1")
                {
                    r.ReadChars(26);        //"Careland Navi HistoryTrack"
                    r.ReadBytes(30);
                    iMax = r.ReadByte();
                    r.ReadBytes(11);
                }
                else if (sFileMode == "KLD2" || sFileMode == "KLD3")
                {
                    r.ReadBytes(24);
                    r.ReadChars(26);        //"Careland HisTrackParams\0\0\0"
                    r.ReadBytes(18); 
                    iMax = r.ReadByte();
                    r.ReadBytes(31);
                }

                gpsOut = new GpsLog[iMax][];
                GpsLog[][] strTemp = new GpsLog[5][];
                for (int i = 0; i < iMax; i++)
                {
                    string[] strTempx = new string[6];

                    if (sFileMode == "KLD1")
                    {
                        do
                        {
                            x = r.ReadInt32();
                        } while (x == 0);

                        strTempx = new string(r.ReadChars(40)).Replace("\0", "").Split('_');
                    }
                    else if (sFileMode == "KLD2" || sFileMode == "KLD3")
                    {
                        if (i != 0 && sFileMode == "KLD2")
                        {
                            do
                            {
                                x = r.ReadInt32();
                            } while (x == 0);
                        }

                        string strTempy = "";

                        if (sFileMode == "KLD2")
                        {
                            strTempy = new string(r.ReadChars(40)).Replace("\0", "").Replace("_", "");
                        }
                        else if (sFileMode == "KLD3" && i == 0)
                        {
                            strTempy = new string(r.ReadChars(40)).Replace("\0", "").Replace("_", "");
                        }
                        else if (sFileMode == "KLD3" && i != 0)
                        {
                            strTempy = new string(r.ReadChars(36)).Replace("\0", "").Replace("_", "");
                            char a2 = Convert.ToChar( yyyy/0x10000);
                            char a1 = Convert.ToChar( yyyy - yyyy/0x10000*0x10000);
                            strTempy = a1.ToString() + a2.ToString()  + strTempy;

                        }

                        try
                        {
                            strTempx[0] = "20" + strTempy.Substring(0, 2);
                            strTempx[1] = strTempy.Substring(2, 2);
                            strTempx[2] = strTempy.Substring(4, 2);
                            strTempx[3] = strTempy.Substring(6, 2);
                            strTempx[4] = strTempy.Substring(8, 2);
                            strTempx[5] = strTempy.Substring(10, 2);
                        }
                        catch
                        {
                            strTempx[0] = "2012";
                            strTempx[1] = "01";
                            strTempx[2] = "01";
                            strTempx[3] = "00";
                            strTempx[4] = "00";
                            strTempx[5] = "00";
                        }
                    }
                    strTemp[i] = new GpsLog[65535];

                    for (int j = 0; ; j++)
                    {
                        int xx = r.ReadInt32();
                        int yy = r.ReadInt32();

                        if (xx != 0 && yy != 0 && xx > 0x10000)
                        {
                            double xxx = xx / size - Convert.ToDouble(txtX1.Text) / 60;
                            double yyy = yy / size - Convert.ToDouble(txtY1.Text) / 60;

                            //UTC时间 GGA[1]=RMC[1] RMC[9] GGA[1]
                            int k;
                            if (Int32.TryParse(strTempx[0],out k) ==false)
                                strTempx[0] = "2000";
                            if (Int32.TryParse(strTempx[1], out k) == false)
                                strTempx[1] = "01";
                            if (Int32.TryParse(strTempx[2], out k) == false)
                                strTempx[2] = "01";
                            if (Int32.TryParse(strTempx[3], out k) == false)
                                strTempx[3] = "00";
                            if (Int32.TryParse(strTempx[4], out k) == false)
                                strTempx[4] = "00";
                            if (Int32.TryParse(strTempx[5], out k) == false)
                                strTempx[5] = "00";

                            strTemp[i][j].UtcTime = new DateTime(
                                                    Convert.ToInt32(strTempx[0]),
                                                    Convert.ToInt32(strTempx[1]),
                                                    Convert.ToInt32(strTempx[2]),
                                                    Convert.ToInt32(strTempx[3]),
                                                    Convert.ToInt32(strTempx[4]),
                                                    Convert.ToInt32(strTempx[5])
                                                    );
                            strTemp[i][j].UtcTime = strTemp[i][j].UtcTime.AddHours(-8);

                            //经度
                            if (xxx >= 0)
                            {
                                strTemp[i][j].Longitude.Str = "E";
                            }
                            else
                            {
                                strTemp[i][j].Longitude.Str = "W";
                                xxx = 0 - xxx;
                            }
                            strTemp[i][j].Longitude.value = xxx;
                            strTemp[i][j].Longitude.DD = (int)xxx;
                            strTemp[i][j].Longitude.MM = Convert.ToDouble((strTemp[i][j].Longitude.value - strTemp[i][j].Longitude.DD) * 60);


                            //纬度
                            if (yyy >= 0)
                            {
                                strTemp[i][j].Latitude.Str = "N";
                            }
                            else
                            {
                                strTemp[i][j].Latitude.Str = "S";
                                yyy = 0 - yyy;
                            }
                            strTemp[i][j].Latitude.value = yyy;
                            strTemp[i][j].Latitude.DD = (int)yyy;
                            strTemp[i][j].Latitude.MM = Convert.ToDouble((strTemp[i][j].Latitude.value - strTemp[i][j].Latitude.DD) * 60);


                            //单点移动距离
                            if (j != 0)
                            {
                                strTemp[i][j].vV = GetDistance(strTemp[i][j - 1].Latitude.value, strTemp[i][j - 1].Longitude.value, strTemp[i][j].Latitude.value, strTemp[i][j].Longitude.value);
                            }
                            else
                            {
                                strTemp[i][j].vV = 0.0;
                            }

                            //海拔高度 GGA[9]
                            strTemp[i][j].high = 0;
                        }
                        else
                        {
                            yyyy = yy;
                            gpsOut[i] = new GpsLog[j];
                            for (int k = 0; k < j; k++)
                            {
                                gpsOut[i][k] = strTemp[i][k];
                            }
                            break;
                        }
                    }
                    for (int l = 0; l < gpsOut[i].Length; l++)
                    {
                        gpsOut[i][l].UtcTime = gpsOut[i][l].UtcTime.AddSeconds((gpsOut[i].Length - 1 - l) * (-7));
                    }
                }
                sri.Close();
            }
            catch
            {
            }

            return gpsOut;

        }

        private GpsLog[] Log2MessageCSV(string strInputName)
        {
            int z = 0;
            string[][] strIn = new string[0x60 * 60 * 24 * 6][];

            try
            {

                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);

                for (int i = 0; i < strIn.Length; i++)
                {
                    string strRead = sr.ReadLine();
                    /* 修正strIn(2015.9.30)
                    if (strRead.Length != 96 && strRead.Length != 101)
                    {
                        continue;
                    }
                    */
                    string[] strTempa = strRead.Replace("\0", "").Replace(" ", "").Replace("*", ",").Split(',');
                    strTempa[0] = strTempa[0].Remove(0, strTempa[0].IndexOf(';') + 1);

                    if ((strTempa[1] == "T" || strTempa[1] == "C" || strTempa[1] == "V" || strTempa[1] == "G") && (strTempa.Length == 15 || strTempa.Length == 10))
                    {
                        double T1 = 0.0;
                        double T2 = 0.0;
                        try
                        {
                            T1 = Convert.ToDouble(strTempa[4].Remove(strTempa[4].Length - 1, 1));
                            T2 = Convert.ToDouble(strTempa[5].Remove(strTempa[5].Length - 1, 1));
                        }
                        catch { }

                        if (T1 > 30 && T1 < 45 && T2 > 100 & T2 < 130)
                        {
                            strIn[z++] = strTempa;
                        }
                    }
                }
                sr.Close();
            }
            catch { }

            #region 修正strIn(2015.9.30)
            /*
            for (int i = 1; i < z-1; i++)
            {
                try
                {
                    double[,] T1 = new double[2, 3];
                    T1[0, 0] = Convert.ToDouble(strIn[i - 1][4].Remove(strIn[i - 1][4].Length - 1, 1));
                    T1[0, 1] = Convert.ToDouble(strIn[i][4].Remove(strIn[i][4].Length - 1, 1));
                    T1[0, 2] = Convert.ToDouble(strIn[i + 1][4].Remove(strIn[i + 1][4].Length - 1, 1));
                    T1[1, 0] = Convert.ToDouble(strIn[i - 1][5].Remove(strIn[i - 1][5].Length - 1, 1));
                    T1[1, 1] = Convert.ToDouble(strIn[i][5].Remove(strIn[i][5].Length - 1, 1));
                    T1[1, 2] = Convert.ToDouble(strIn[i + 1][5].Remove(strIn[i + 1][5].Length - 1, 1));
                    double[,] T2 = new double[2, 2];
                    T2[0, 0] = Math.Abs(T1[0, 2] - T1[0, 0]);
                    T2[1, 0] = Math.Abs(T1[1, 2] - T1[1, 0]);
                    T2[0, 1] = Math.Abs(T1[0, 1] - T1[0, 0]);
                    T2[1, 1] = Math.Abs(T1[1, 1] - T1[1, 0]);
                    if (T2[0, 1] > 1 || T2[1, 1] > 1)
                    {
                        strIn[i][4] = strIn[i - 1][4];
                        strIn[i][5] = strIn[i - 1][5];
                    }

                    if (T2[1, 1] > T2[1, 0] && T2[0, 1] > T2[0, 0])
                    {
                            double tT1 = T1[0, 1] + (T1[0, 2] - T1[0, 0]) / 2;
                            double tT2 = T1[1, 1] + (T1[1, 2] - T1[1, 0]) / 2;
                            strIn[z][4] = tT1.ToString("00.000000");
                            strIn[z][5] = tT2.ToString("000.000000");

                    }
                }
                catch { }

            }

            */
            #endregion


            #region 修正CVS文件中的BUG(2012.10.18)
            //修正CVS文件中的BUG(2012.10.18)
                for (int i = 0; i < z; i++)
                {
                    try
                    {
                        //Y-01：个别点的TIME值和前一点相同
                        if (z > 3)
                        {
                                if (i == 0) //第一点错误(X,x,x+1)
                                {
                                    if (Convert.ToInt32(strIn[i][3]) == Convert.ToInt32(strIn[i + 1][3]) && Convert.ToInt32(strIn[i][3]) == Convert.ToInt32(strIn[i + 2][3]) - 1)
                                    {
                                        strIn[i][3] = (Convert.ToInt32(strIn[i][3]) - 1).ToString();
                                    }
                                }
                                else if (i < z - 1) //中间点错误
                                {
                                    //(x,X,>=x+2)
                                    if (Convert.ToInt32(strIn[i][3]) == Convert.ToInt32(strIn[i - 1][3]) && Convert.ToInt32(strIn[i][3]) <= Convert.ToInt32(strIn[i + 1][3]) - 2)
                                    {
                                        strIn[i][3] = (Convert.ToInt32(strIn[i][3]) + 1).ToString();

                                        //00(2013.1.17)
                                        if (strIn[i][3].Substring(strIn[i][3].Length - 2, 2) == "60")
                                        {
                                            strIn[i][3] = (Convert.ToInt32(strIn[i][3]) + 40).ToString();
                                        }
                                    }

                                    //(<=x-2,X,x)
                                    if (Convert.ToInt32(strIn[i][3]) == Convert.ToInt32(strIn[i + 1][3]) && Convert.ToInt32(strIn[i][3]) >= Convert.ToInt32(strIn[i - 1][3]) + 2)
                                    {
                                        strIn[i][3] = (Convert.ToInt32(strIn[i][3]) - 1).ToString();

                                        //00(2013.1.17)
                                        if (strIn[i][3].Substring(strIn[i][3].Length - 2, 2) == "99")
                                        {
                                            strIn[i][3] = (Convert.ToInt32(strIn[i][3]) - 40).ToString();
                                        }
                                    }
                                }
                                else if (i == z - 1) //最后点错误(x,X)
                                {
                                    if (Convert.ToInt32(strIn[i][3]) == Convert.ToInt32(strIn[i - 1][3]))
                                    {
                                        strIn[i][3] = (Convert.ToInt32(strIn[i][3]) + 1).ToString();
                                    }
                                }
                        }
                    }
                    catch { }
                    //Y-02：个别点的HEADING值为360
                    strIn[i][8] = strIn[i][8].Replace("360", "0");

                    //X-01：如果CVS文件被Excel编辑过或经过了BUG-1修正，则TIME值可能不满6位(此修正必须在Y-01修正后修正)
                    strIn[i][3] = strIn[i][3].PadLeft(6, '0');
 

                }

            #endregion

            GpsLog[] strTemp = new GpsLog[z];
            int x = 0;
            for (int i = 0; i < z; i++)
            {
                try
                {
                    #region RMC
                    //  0:  "$GPRMC"    推荐定位信息
                    //  1:  UTC时间     hhmmss
                    //  2:  定位状态    A有效定位；V无效定位
                    //  3:  纬度        ddmm.mmmmmm
                    //  4:  纬度半球    N北半球；S南半球
                    //  5:  经度        dddmm.mmmmmm
                    //  6:  经度半球    E东经；W西经
                    //  7:  地面速率    000.0-999.9节
                    //  8:  地面航向    000.0-359.9度
                    //  9:  UTC日期     ddmmyy
                    //  10: 磁偏角      000.0－180.0度
                    //  11: 磁偏角方向  E东；W西
                    //  12: 模式指示    A自主定位；D差分定位；E估算定位；N数据无效
                    //  13: 校验码      
                    strTemp[x].strRMC = new string[14];
                    strTemp[x].strRMC[0] = "$GPRMC"; 
                    strTemp[x].strRMC[1] = strIn[i][3];
                    strTemp[x].strRMC[2] = "A";
                    strTemp[x].strRMC[3] = strIn[i][4].Remove(2, strIn[i][4].Length - 2) + (Convert.ToDouble(strIn[i][4].Remove(strIn[i][4].Length - 1, 1).Remove(0, 2)) * 60).ToString("00.000000");
                    strTemp[x].strRMC[4] = strIn[i][4].Remove(0, strIn[i][4].Length - 1);
                    strTemp[x].strRMC[5] = strIn[i][5].Remove(3, strIn[i][5].Length - 3) + (Convert.ToDouble(strIn[i][5].Remove(strIn[i][5].Length - 1, 1).Remove(0, 3)) * 60).ToString("00.000000");
                    strTemp[x].strRMC[6] = strIn[i][5].Remove(0, strIn[i][5].Length - 1);
                    strTemp[x].strRMC[7] = (Convert.ToDouble(strIn[i][7]) / 1.852).ToString("0.000");
                    strTemp[x].strRMC[8] = strIn[i][8].Replace("360","0");
                    strTemp[x].strRMC[9] = strIn[i][2].Remove(0, 4) + strIn[i][2].Remove(0, 2).Remove(2, 2) + strIn[i][2].Remove(2, 4);
                    strTemp[x].strRMC[10] = "";
                    strTemp[x].strRMC[11] = "";
                    strTemp[x].strRMC[12] = "A";
                    strTemp[x].strRMC[13] = "";
                    #endregion

                    #region GGA
                    strTemp[x].strGGA = new string[16];
                    strTemp[x].strGGA[0] = "$GPGGA";
                    strTemp[x].strGGA[1] = strIn[i][3];
                    strTemp[x].strGGA[2] = strIn[i][4].Remove(2, strIn[i][4].Length - 2) + (Convert.ToDouble(strIn[i][4].Remove(strIn[i][4].Length - 1, 1).Remove(0, 2)) * 60).ToString("00.000000");
                    strTemp[x].strGGA[3] = strIn[i][4].Remove(0, strIn[i][4].Length - 1);
                    strTemp[x].strGGA[4] = strIn[i][5].Remove(3, strIn[i][5].Length - 3) + (Convert.ToDouble(strIn[i][5].Remove(strIn[i][5].Length - 1, 1).Remove(0, 3)) * 60).ToString("00.000000");
                    strTemp[x].strGGA[5] = strIn[i][5].Remove(0, strIn[i][5].Length - 1);

                    if (strIn[i].Length == 15)
                    {
                        if (strIn[i][10] == "SPS")
                        {
                            strTemp[x].strGGA[6] = "1";
                        }
                        else if (strIn[i][10] == "DGPS")
                        {
                            strTemp[x].strGGA[6] = "2";
                        }
                        else if (strIn[i][10] == "PPS")
                        {
                            strTemp[x].strGGA[6] = "3";
                        }
                        else
                        {
                            strTemp[x].strGGA[6] = "0";
                        }
                    }
                    else
                    {
                        strTemp[x].strGGA[6] = "2";
                    }
                    strTemp[x].strGGA[7] = "0";
                    if (strIn[i].Length == 15)
                    {
                        strTemp[x].strGGA[8] = strIn[i][12];
                    }
                    else
                    {
                        strTemp[x].strGGA[8] = "1.0";
                    }

                    strTemp[x].strGGA[9] = strIn[i][6];
                    strTemp[x].strGGA[10] = "M";
                    strTemp[x].strGGA[11] = "0.0";
                    strTemp[x].strGGA[12] = "M";
                    strTemp[x].strGGA[13] = "";
                    strTemp[x].strGGA[14] = "";
                    strTemp[x].strGGA[15] = "";
                    #endregion

                    #region GSA
                    strTemp[x].strGSA = new string[19];
                    strTemp[x].strGSA[0] = "$GPGSA";
                    strTemp[x].strGSA[1] = "A";
                    if (strIn[i].Length == 15)
                    {
                        if (strIn[i][9] == "3D")
                        {
                            strTemp[x].strGSA[2] = "3";
                        }
                        else if (strIn[i][9] == "2D")
                        {
                            strTemp[x].strGSA[2] = "2";
                        }
                        else
                        {
                            strTemp[x].strGSA[2] = "1";
                        }
                    }
                    else
                    {
                        strTemp[x].strGSA[2] = "3";
                    }
                    for (int j = 3; j <= 13; j++)
                    {
                        strTemp[x].strGSA[j] = "";
                    }
                    if (strIn[i].Length == 15)
                    {
                        strTemp[x].strGSA[15] = strIn[i][11];
                        strTemp[x].strGSA[16] = strIn[i][12];
                        strTemp[x].strGSA[17] = strIn[i][13];
                    }
                    else
                    {
                        strTemp[x].strGSA[15] = "1.0";
                        strTemp[x].strGSA[16] = "1.0";
                        strTemp[x].strGSA[17] = "1.0";
                    }
                    strTemp[x].strGSA[18] = "";
                    #endregion

                    if ((strTemp[x].strRMC[2] == "A"))
                    {
                        if (x != 0)
                        {
                            strTemp[x] = ReadData(strTemp[x], strTemp[x - 1], x);
                        }
                        else
                        {
                            strTemp[x] = ReadData(strTemp[x], strTemp[x], x);
                        }

                        x++;
                    }

                }
                catch {}
            }

            GpsLog[] strOut = new GpsLog[x];
            for (int i = 0; i < x; i++)
            {
                strOut[i] = strTemp[i];
            }
            return strOut;
        }

        private GpsLog[] Log2MessageCSV2(string strInputName)
        {
            int z = 0;
            string[][] strIn = new string[0x60 * 60 * 24 * 6][];

            try
            {

                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);

                for (int i = 0; i < strIn.Length; i++)
                {
                    string strRead = sr.ReadLine();
                    string[] strTempa = strRead.Replace("\\", "").Replace("\"", "").Split(',');

                    if (strTempa.Length > 1)
                    {

                        if (strTempa[0] != "名称" && (strTempa[0].Length == 1 || strTempa[0].Length == 2 || strTempa[0].Length == 3))
                        {
                            strIn[z] = strTempa;
                            z++;
                        }
                    }
                }
                sr.Close();
            }
            catch { }

            GpsLog[] strTemp = new GpsLog[z];
            int x = 0;
            for (int i = 0; i < z; i++)
            {
                try
                {
                    #region RMC
                    //  0:  "$GPRMC"    推荐定位信息
                    //  1:  UTC时间     hhmmss
                    //  2:  定位状态    A有效定位；V无效定位
                    //  3:  纬度        ddmm.mmmmmm
                    //  4:  纬度半球    N北半球；S南半球
                    //  5:  经度        dddmm.mmmmmm
                    //  6:  经度半球    E东经；W西经
                    //  7:  地面速率    000.0-999.9节
                    //  8:  地面航向    000.0-359.9度
                    //  9:  UTC日期     ddmmyy
                    //  10: 磁偏角      000.0－180.0度
                    //  11: 磁偏角方向  E东；W西
                    //  12: 模式指示    A自主定位；D差分定位；E估算定位；N数据无效
                    //  13: 校验码      
                    strTemp[x].strRMC = new string[14];
                    strTemp[x].strRMC[0] = "$GPRMC";
                    strTemp[x].strRMC[1] = strIn[i][8].Remove(0,11).Remove(8,5).Replace(":","");
                    strTemp[x].strRMC[2] = "A";
                    strTemp[x].strRMC[3] = strIn[i][2].Remove(2, strIn[i][2].Length - 2) + (Convert.ToDouble(strIn[i][2].Remove(0, 2)) * 60).ToString("00.000000");
                    strTemp[x].strRMC[4] = "N";
                    strTemp[x].strRMC[5] = strIn[i][3].Remove(3, strIn[i][3].Length - 3) + (Convert.ToDouble(strIn[i][3].Remove(0, 3)) * 60).ToString("00.000000");
                    strTemp[x].strRMC[6] = "E";
                    strTemp[x].strRMC[7] = (Convert.ToDouble(strIn[i][7]) *3600 / 1000 / 1.852).ToString("0.000");
                    if (strIn[i][5] != "")
                    {
                        strTemp[x].strRMC[8] = Convert.ToDouble(strIn[i][5]).ToString("0.0");
                    }
                    else
                    {
                        strTemp[x].strRMC[8] = "0.0";
                    }
                    strTemp[x].strRMC[9] = strIn[i][8].Remove(0, 8).Remove(2,14) + strIn[i][8].Remove(0, 5).Remove(2,17) + strIn[i][8].Remove(0, 2).Remove(2,20);
                    strTemp[x].strRMC[10] = "";
                    strTemp[x].strRMC[11] = "";
                    strTemp[x].strRMC[12] = "A";
                    strTemp[x].strRMC[13] = "";
                    #endregion

                    #region GGA
                    strTemp[x].strGGA = new string[16];
                    strTemp[x].strGGA[0] = "$GPGGA";
                    strTemp[x].strGGA[1] = strIn[i][8].Remove(0, 11).Remove(8, 5).Replace(":", "");
                    strTemp[x].strGGA[2] = strIn[i][2].Remove(2, strIn[i][2].Length - 2) + (Convert.ToDouble(strIn[i][2].Remove(0, 2)) * 60).ToString("00.000000");
                    strTemp[x].strGGA[3] = "N";
                    strTemp[x].strGGA[4] = strIn[i][3].Remove(3, strIn[i][3].Length - 3) + (Convert.ToDouble(strIn[i][3].Remove(0, 3)) * 60).ToString("00.000000");
                    strTemp[x].strGGA[5] = "E";
                    strTemp[x].strGGA[6] = "2";
                    strTemp[x].strGGA[7] = "0";
                    strTemp[x].strGGA[8] = strIn[i][6];
                    strTemp[x].strGGA[9] = Convert.ToDouble(strIn[i][4]).ToString("0.0");
                    strTemp[x].strGGA[10] = "M";
                    strTemp[x].strGGA[11] = "0.0";
                    strTemp[x].strGGA[12] = "M";
                    strTemp[x].strGGA[13] = "";
                    strTemp[x].strGGA[14] = "";
                    strTemp[x].strGGA[15] = "";
                    #endregion

                    #region GSA
                    strTemp[x].strGSA = new string[19];
                    strTemp[x].strGSA[0] = "$GPGSA";
                    strTemp[x].strGSA[1] = "A";            
                    strTemp[x].strGSA[2] = "3";
                    for (int j = 3; j <= 13; j++)
                    {
                        strTemp[x].strGSA[j] = "";
                    }
                    strTemp[x].strGSA[15] = strIn[i][6];
                    strTemp[x].strGSA[16] = strIn[i][6];
                    strTemp[x].strGSA[17] = "1.0";
                    strTemp[x].strGSA[18] = "";

                    #endregion

                    if ((strTemp[x].strRMC[2] == "A"))
                    {
                        if (x != 0)
                        {
                            strTemp[x] = ReadData(strTemp[x], strTemp[x - 1], x);
                        }
                        else
                        {
                            strTemp[x] = ReadData(strTemp[x], strTemp[x], x);
                        }

                        x++;
                    }

                }
                catch { }
            }

            GpsLog[] strOut = new GpsLog[x];
            for (int i = 0; i < x; i++)
            {
                strOut[i] = strTemp[i];
            }
            return strOut;
        }

        private GpsLog[] Log2MessageCSV3(string strInputName)
        {
            int z = 0;
            string[][] strIn = new string[0x60 * 60 * 24 * 6][];

            try
            {

                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);

                for (int i = 0; i < strIn.Length; i++)
                {
                    string strRead = sr.ReadLine();
                    string[] strTempa = strRead.Replace("\0", "").Replace(" ", "").Replace("*", ",").Split(',');
                    strTempa[0] = strTempa[0].Remove(0, strTempa[0].IndexOf(';') + 1);

                    if (strTempa.Length == 8)
                    {
                        double T1 = 0.0;
                        double T2 = 0.0;
                        try
                        {
                            T1 = Convert.ToDouble(strTempa[1]);
                            T2 = Convert.ToDouble(strTempa[0]);
                        }
                        catch { }

                        if (T1 > 30 && T1 < 45 && T2 > 100 & T2 < 130)
                        {
                            strIn[z++] = strTempa;
                        }
                    }
                }
                sr.Close();
            }
            catch { }

            GpsLog[] strTemp = new GpsLog[z];
            int x = 0;
            for (int i = 0; i < z; i++)
            {
                try
                {
                    strIn[i][5] = strIn[i][5].PadLeft(6, '0');
                    strIn[i][6] = strIn[i][6].PadLeft(8, '0');
                    #region RMC
                    //  0:  "$GPRMC"    推荐定位信息
                    //  1:  UTC时间     hhmmss
                    //  2:  定位状态    A有效定位；V无效定位
                    //  3:  纬度        ddmm.mmmmmm
                    //  4:  纬度半球    N北半球；S南半球
                    //  5:  经度        dddmm.mmmmmm
                    //  6:  经度半球    E东经；W西经
                    //  7:  地面速率    000.0-999.9节
                    //  8:  地面航向    000.0-359.9度
                    //  9:  UTC日期     ddmmyy
                    //  10: 磁偏角      000.0－180.0度
                    //  11: 磁偏角方向  E东；W西
                    //  12: 模式指示    A自主定位；D差分定位；E估算定位；N数据无效
                    //  13: 校验码      
                    strTemp[x].strRMC = new string[14];
                    strTemp[x].strRMC[0] = "$GPRMC";
                    strTemp[x].strRMC[1] = strIn[i][6].Remove(strIn[i][6].Length -2 ,2);
                    strTemp[x].strRMC[2] = "A";
                    strTemp[x].strRMC[3] = strIn[i][1].Remove(2, strIn[i][1].Length - 2) + (Convert.ToDouble(strIn[i][1].Remove(strIn[i][1].Length - 1, 1).Remove(0, 2)) * 60).ToString("00.000000");
                    strTemp[x].strRMC[4] = "N";
                    strTemp[x].strRMC[5] = strIn[i][0].Remove(3, strIn[i][0].Length - 3) + (Convert.ToDouble(strIn[i][0].Remove(strIn[i][0].Length - 1, 1).Remove(0, 3)) * 60).ToString("00.000000");
                    strTemp[x].strRMC[6] = "E";
                    strTemp[x].strRMC[7] = (Convert.ToDouble(strIn[i][3]) / 1.852).ToString("0.000");
                    strTemp[x].strRMC[8] = strIn[i][4].Replace("360", "0");
                    strTemp[x].strRMC[9] = strIn[i][5];
                    strTemp[x].strRMC[10] = "";
                    strTemp[x].strRMC[11] = "";
                    strTemp[x].strRMC[12] = "A";
                    strTemp[x].strRMC[13] = "";
                    #endregion

                    #region GGA
                    strTemp[x].strGGA = new string[16];
                    strTemp[x].strGGA[0] = "$GPGGA";
                    strTemp[x].strGGA[1] = strIn[i][6].Remove(strIn[i][6].Length - 2, 2);
                    strTemp[x].strGGA[2] = strIn[i][1].Remove(2, strIn[i][1].Length - 2) + (Convert.ToDouble(strIn[i][1].Remove(strIn[i][1].Length - 1, 1).Remove(0, 2)) * 60).ToString("00.000000");
                    strTemp[x].strGGA[3] = "N";
                    strTemp[x].strGGA[4] = strIn[i][0].Remove(3, strIn[i][0].Length - 3) + (Convert.ToDouble(strIn[i][0].Remove(strIn[i][0].Length - 1, 1).Remove(0, 3)) * 60).ToString("00.000000");
                    strTemp[x].strGGA[5] = "E";
                    strTemp[x].strGGA[6] = "1";
                    strTemp[x].strGGA[7] = strIn[i][7];
                    strTemp[x].strGGA[8] = "1.0";
                    strTemp[x].strGGA[9] = strIn[i][2];
                    strTemp[x].strGGA[10] = "M";
                    strTemp[x].strGGA[11] = "0.0";
                    strTemp[x].strGGA[12] = "M";
                    strTemp[x].strGGA[13] = "";
                    strTemp[x].strGGA[14] = "";
                    strTemp[x].strGGA[15] = "";
                    #endregion
                    /*
                    #region GSA
                    strTemp[x].strGSA = new string[19];
                    strTemp[x].strGSA[0] = "$GPGSA";
                    strTemp[x].strGSA[1] = "A";
                    strTemp[x].strGSA[2] = "3";
                    for (int j = 3; j <= 13; j++)
                    {
                        strTemp[x].strGSA[j] = "";
                    }
                    strTemp[x].strGSA[15] = "1.0";
                    strTemp[x].strGSA[16] = "1.0";
                    strTemp[x].strGSA[17] = "1.0";
                    strTemp[x].strGSA[18] = "";
                    #endregion
                    */
                    if ((strTemp[x].strRMC[2] == "A"))
                    {
                        if (x != 0)
                        {
                            strTemp[x] = ReadData(strTemp[x], strTemp[x - 1], x);
                        }
                        else
                        {
                            strTemp[x] = ReadData(strTemp[x], strTemp[x], x);
                        }

                        x++;
                    }

                }
                catch { }
            }

            GpsLog[] strOut = new GpsLog[x];
            for (int i = 0; i < x; i++)
            {
                strOut[i] = strTemp[i];
            }
            return strOut;
        }

        private void Kld2NMEA(string strInputName)
        {
            try
            {
                FileStream sri = new FileStream(strInputName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(sri);
                FileInfo FiInput = new FileInfo(strInputName);
                string strFileName = FiInput.Name.Remove(FiInput.Name.Length - FiInput.Extension.Length);
                int iMax = strOut5.Length;
                txtMessage.Text += "Max:" + iMax.ToString() + "\n";
                //lblMessage1.Refresh();

                for (int i = 1; i <= iMax; i++)
                {
                    StreamWriter myFile = File.CreateText(strFileName + "_" + i.ToString() + ".KLD.log");
                    for (int j = 0;j<strOut5[i-1].Length ;j++)
                    {
                        string[] strRMC = new string[14];
                        DateTime dtTemp = strOut5[i - 1][j].UtcTime.AddSeconds((strOut5[i - 1].Length-1-j)* (-7));//7秒一个点，向前推
                        strRMC[0] = "$GPRMC,";
                        strRMC[1] = dtTemp.Hour.ToString("00") + dtTemp.Minute.ToString("00") + dtTemp.Second.ToString("00") + ",";
                        strRMC[2] = "A,";
                        strRMC[3] = strOut5[i - 1][j].Latitude.DD.ToString() + strOut5[i - 1][j].Latitude.MM.ToString("00.0000") + ",";
                        strRMC[4] = strOut5[i - 1][j].Latitude.Str.ToString() + ",";
                        strRMC[5] = strOut5[i - 1][j].Longitude.DD.ToString() + strOut5[i - 1][j].Longitude.MM.ToString("00.0000") + ",";
                        strRMC[6] = strOut5[i - 1][j].Longitude.Str.ToString() + ",";
                        strRMC[7] = "000.0,";
                        strRMC[8] = "000.0,";
                        strRMC[9] = dtTemp.Day.ToString("00") + dtTemp.Month.ToString("00") + dtTemp.Year.ToString("0000").Remove(0, 2) + ",";
                        strRMC[10] = ",";
                        strRMC[11] = ",";
                        strRMC[12] = "A";

                        string strOut = strRMC[0] + strRMC[1] + strRMC[2] + strRMC[3] + strRMC[4] + strRMC[5] + strRMC[6] + strRMC[7] + strRMC[8] + strRMC[9] + strRMC[10] + strRMC[11] + strRMC[12];
                        strRMC[13] = "*" + myChk(strOut.Substring(1,strOut.Length -1)).PadLeft(2,'0');
                        strOut += strRMC[13];
                        myFile.WriteLine(strOut);
                    }
                    myFile.Close();

                    txtMessage.Text += "Track_" + i.ToString() + "  " + strOut5[i - 1].Length.ToString() + "  \n";
                    
                    //lblMessage1.Refresh();
                }
                sri.Close();
            }
            catch
            {
            }
        }

        private void CSV2NMEA(string strInputName)
        {
            GpsLog[] CsvGpsLog;

            if (sFileMode == "CSV")
            {
                CsvGpsLog = Log2MessageCSV(strInputName);
            }
            else if (sFileMode == "CSV2")
            {
                CsvGpsLog = Log2MessageCSV2(strInputName);
            }
            else
            {
                CsvGpsLog = Log2MessageCSV3(strInputName);
            }
            try
            {
                FileInfo FiInput = new FileInfo(strInputName);
                string strFileName = FiInput.Name.Remove(FiInput.Name.Length - FiInput.Extension.Length);

                StreamWriter myFile = File.CreateText(strFileName + ".CSV.log");
                for (int i = 0; i < CsvGpsLog.Length; i++)
                {
                    string strRMC = "";
                    string strGGA = "";     
                    for (int j = 0; j < CsvGpsLog[i].strRMC.Length - 2; j++)
                    {
                        strRMC += CsvGpsLog[i].strRMC[j] + ",";
                    }
                    strRMC += CsvGpsLog[i].strRMC[CsvGpsLog[i].strRMC.Length - 2];
                    strRMC += "*" + myChk(strRMC.Substring(1, strRMC.Length - 1)).PadLeft(2, '0');

                    for (int j = 0; j < CsvGpsLog[i].strGGA.Length - 2; j++)
                    {
                        strGGA += CsvGpsLog[i].strGGA[j] + ",";
                    }
                    strGGA += CsvGpsLog[i].strGGA[CsvGpsLog[i].strGGA.Length - 2];
                    strGGA += "*" + myChk(strGGA.Substring(1, strGGA.Length - 1)).PadLeft(2, '0');

                    myFile.WriteLine(strRMC);
                    if (chkGGA.Checked)
                    {
                        myFile.WriteLine(strGGA);
                    }

                    if (sFileMode == "CSV" || sFileMode == "CSV2")
                    {
                        string strGSA = "";
                        for (int j = 0; j < CsvGpsLog[i].strGSA.Length - 2; j++)
                        {
                            strGSA += CsvGpsLog[i].strGSA[j] + ",";
                        }
                        strGSA += CsvGpsLog[i].strGSA[CsvGpsLog[i].strGSA.Length - 2];
                        strGSA += "*" + myChk(strGSA.Substring(1, strGSA.Length - 1)).PadLeft(2, '0');
                        if (chkGSA.Checked)
                        {
                            myFile.WriteLine(strGSA);
                        }
                    }
                }
                myFile.Close();

                txtMessage.Text += "共" + CsvGpsLog.Length.ToString() + "点\r\n转换完成\r\n";
                //lblMessage1.Refresh();
            }
            catch
            {
            }
        }

        private GpsLog ReadData(GpsLog gpsIn, GpsLog gpsInHalf, int x)
        {
            //UTC时间 GGA[1]=RMC[1] RMC[9] GGA[1]
            gpsIn.UtcTime = new DateTime(
                                    Convert.ToInt32(gpsIn.strRMC[9].Remove(0, gpsIn.strRMC[9].Length - 2)) + 2000,
                                    Convert.ToInt32(gpsIn.strRMC[9].Remove(0, gpsIn.strRMC[9].Length - 4).Remove(2, 2)),
                                    Convert.ToInt32(gpsIn.strRMC[9].Remove(gpsIn.strRMC[9].Length - 4, 4)),
                                    Convert.ToInt32(gpsIn.strRMC[1].Remove(gpsIn.strRMC[1].Length - 4, 4)),
                                    Convert.ToInt32(gpsIn.strRMC[1].Remove(0, gpsIn.strRMC[1].Length - 4).Remove(2, 2)),
                                    Convert.ToInt32(gpsIn.strRMC[1].Remove(0, gpsIn.strRMC[1].Length - 2))
                                    );

            //地面航向 RMC[8] VTG[3]
            gpsIn.hangxiangT = Convert.ToDouble(gpsIn.strRMC[8]);     //真北
            if (gpsIn.strVTG != null && gpsIn.strVTG[3] != "")
            {
                gpsIn.hangxiangM = Convert.ToDouble(gpsIn.strVTG[3]); //磁北
            }
            else
            {
                if (gpsIn.strRMC[11] == "E")
                {
                    gpsIn.hangxiangM = Convert.ToDouble(gpsIn.strRMC[8]) + Convert.ToDouble(gpsIn.strRMC[10]);  
                }
                else if (gpsIn.strRMC[11] == "W")
                {
                    gpsIn.hangxiangM = Convert.ToDouble(gpsIn.strRMC[8]) - Convert.ToDouble(gpsIn.strRMC[10]);
                }
                else
                {
                    gpsIn.hangxiangM = Convert.ToDouble(gpsIn.strRMC[8]);
                }
            }

            //地面速率 RMC[7] VTG[7] VTG[5]
            gpsIn.speedN = Convert.ToDouble(gpsIn.strRMC[7]);         //节
            if (gpsIn.strVTG != null && gpsIn.strVTG[7] != null)
            {
                gpsIn.speedK = Convert.ToDouble(gpsIn.strVTG[7]);     //千米每小时
            }
            else
            {
                gpsIn.speedK = Convert.ToDouble(gpsIn.strRMC[7]) * 1.852; //计算：1节＝1.852千米每小时
            }

            //经度 GGA[2]=RMC[3] GGA[3]
            gpsIn.Latitude.Str = gpsIn.strRMC[4];
            gpsIn.Latitude.DD = Convert.ToInt32(gpsIn.strRMC[3].Remove(2, gpsIn.strRMC[3].Length - 2));
            gpsIn.Latitude.MM = Convert.ToDouble(gpsIn.strRMC[3].Remove(0, 2));
            gpsIn.Latitude.value = gpsIn.Latitude.DD + gpsIn.Latitude.MM / 60.0;

            //纬度 GGA[4]=RMC[5] GGA[5]
            gpsIn.Longitude.Str = gpsIn.strRMC[6];
            gpsIn.Longitude.DD = Convert.ToInt32(gpsIn.strRMC[5].Remove(3, gpsIn.strRMC[5].Length - 3));
            gpsIn.Longitude.MM = Convert.ToDouble(gpsIn.strRMC[5].Remove(0, 3));
            gpsIn.Longitude.value = gpsIn.Longitude.DD + gpsIn.Longitude.MM / 60.0;

            //单点移动距离
            if (x != 0)
            {
                gpsIn.vV = GetDistance(gpsInHalf.Latitude.value, gpsInHalf.Longitude.value, gpsIn.Latitude.value, gpsIn.Longitude.value);
            }
            else
            {
                gpsIn.vV = 0.0;
            }

            //海拔高度 GGA[9]
            if (gpsIn.strGGA != null)
            {
                gpsIn.high = Convert.ToDouble(gpsIn.strGGA[9]);
            }

            //定位卫星 GGA[7]
            if (gpsIn.strGGA != null && gpsIn.strGSA != null)
            {
                gpsIn.xPoint = new int[Convert.ToInt32(gpsIn.strGGA[7])];
                for (int j = 0; j < gpsIn.xPoint.Length; j++)
                {
                    gpsIn.xPoint[j] = Convert.ToInt32(gpsIn.strGSA[3 + j]);
                }
            }

            return gpsIn;
        }

        private GpsLog[] Log2MessageOzi(string strInputName)
        {

            GpsLog[] strTemp = new GpsLog[0x60 * 60 * 24 * 6];

            int x = 0;
            try
            {
                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);
                for (int i = 0; i < strTemp.Length; i++)
                {
                    string[] strString = sr.ReadLine().Split(',');
                    if ((strString.Length == 5 || strString.Length == 7) && strString[0] != "0")
                    {
                        //UtcTime
                        double myTimes = Convert.ToDouble(strString[4]);
                        int myDays = (int)myTimes;
                        int mySeconds = (int)(Math.Round((myTimes - myDays) * 24 * 60 * 60, 0));
                        strTemp[x].UtcTime = new DateTime(1899, 12, 30).AddDays(myDays).AddSeconds(mySeconds);

                        //Latitude
                        strTemp[x].Latitude.value = Convert.ToDouble(strString[0]);
                        strTemp[x].Latitude.DD = (int)strTemp[x].Latitude.value;
                        strTemp[x].Latitude.MM = (strTemp[x].Latitude.value - (int)strTemp[x].Latitude.value) * 60;
                        strTemp[x].Latitude.Str = "N";

                        //Longitude
                        strTemp[x].Longitude.value = Convert.ToDouble(strString[1]);
                        strTemp[x].Longitude.DD = (int)strTemp[x].Longitude.value;
                        strTemp[x].Longitude.MM = (strTemp[x].Longitude.value - (int)strTemp[x].Longitude.value) * 60;
                        strTemp[x].Longitude.Str = "E";

                        //High
                        strTemp[x].high = Math.Round((Convert.ToDouble(strString[3]) / 3.28084), 2);


                        #region RMC
                        //  0:  "$GPRMC"    推荐定位信息
                        //  1:  UTC时间     hhmmss
                        //  2:  定位状态    A有效定位；V无效定位
                        //  3:  纬度        ddmm.mmmmmm
                        //  4:  纬度半球    N北半球；S南半球
                        //  5:  经度        dddmm.mmmmmm
                        //  6:  经度半球    E东经；W西经
                        //  7:  地面速率    000.0-999.9节
                        //  8:  地面航向    000.0-359.9度
                        //  9:  UTC日期     ddmmyy
                        //  10: 磁偏角      000.0－180.0度
                        //  11: 磁偏角方向  E东；W西
                        //  12: 模式指示    A自主定位；D差分定位；E估算定位；N数据无效
                        //  13: 校验码      

                        strTemp[x].strRMC = new string[14];
                        strTemp[x].strRMC[0] = "$GPRMC";
                        strTemp[x].strRMC[1] = strTemp[x].UtcTime.Hour.ToString().PadLeft(2, '0') + strTemp[x].UtcTime.Minute.ToString().PadLeft(2, '0') + strTemp[x].UtcTime.Second.ToString().PadLeft(2, '0');
                        strTemp[x].strRMC[2] = "A";
                        strTemp[x].strRMC[3] = strTemp[x].Latitude.DD.ToString() + strTemp[x].Latitude.MM.ToString("00.000000");
                        strTemp[x].strRMC[4] = "N";
                        strTemp[x].strRMC[5] = strTemp[x].Longitude.DD.ToString() + strTemp[x].Longitude.MM.ToString("00.000000");
                        strTemp[x].strRMC[6] = "E";
                        strTemp[x].strRMC[7] = "0";
                        strTemp[x].strRMC[8] = "0";
                        strTemp[x].strRMC[9] = strTemp[x].UtcTime.Day.ToString().PadLeft(2, '0') + strTemp[x].UtcTime.Month.ToString().PadLeft(2, '0') + strTemp[x].UtcTime.Year.ToString().Remove(0, 2);
                        strTemp[x].strRMC[10] = "";
                        strTemp[x].strRMC[11] = "";
                        strTemp[x].strRMC[12] = "A";
                        strTemp[x].strRMC[13] = "";
                        
                        #endregion

                        #region GGA
                        strTemp[x].strGGA = new string[16];
                        strTemp[x].strGGA[0] = "$GPGGA";
                        strTemp[x].strGGA[1] = strTemp[x].UtcTime.Hour.ToString().PadLeft(2, '0') + strTemp[x].UtcTime.Minute.ToString().PadLeft(2, '0') + strTemp[x].UtcTime.Second.ToString().PadLeft(2, '0');
                        strTemp[x].strGGA[2] = strTemp[x].Latitude.DD.ToString() + strTemp[x].Latitude.MM.ToString("00.000000");
                        strTemp[x].strGGA[3] = "N";
                        strTemp[x].strGGA[4] = strTemp[x].Longitude.DD.ToString() + strTemp[x].Longitude.MM.ToString("00.000000");
                        strTemp[x].strGGA[5] = "E";
                        strTemp[x].strGGA[6] = "1";
                        strTemp[x].strGGA[7] = "0";
                        strTemp[x].strGGA[8] = "1.0";
                        strTemp[x].strGGA[9] = strTemp[x].high.ToString("0.0");
                        strTemp[x].strGGA[10] = "M";
                        strTemp[x].strGGA[11] = "0.0";
                        strTemp[x].strGGA[12] = "M";
                        strTemp[x].strGGA[13] = "";
                        strTemp[x].strGGA[14] = "";
                        strTemp[x].strGGA[15] = "";
                        #endregion

                        #region GSA
                        strTemp[x].strGSA = new string[19];
                        strTemp[x].strGSA[0] = "$GPGSA";
                        strTemp[x].strGSA[1] = "A";
                        strTemp[x].strGSA[2] = "1";

                        for (int j = 3; j <= 13; j++)
                        {
                            strTemp[x].strGSA[j] = "";
                        }
                       
                        strTemp[x].strGSA[15] = "1.0";
                        strTemp[x].strGSA[16] = "1.0";
                        strTemp[x].strGSA[17] = "1.0";
                        strTemp[x].strGSA[18] = "";
                        #endregion


                        x++;

                    }
                        

                    }
                }
            catch { }

            GpsLog[] strOut = new GpsLog[x];

            for (int i = 0; i < x; i++)
            {
                strOut[i] = strTemp[i];
            }

            return strOut;
        }

        private void Ozi2NMEA(string strInputName)
        {
            GpsLog[] CsvGpsLog = Log2MessageOzi(strInputName);
            try
            {
                FileInfo FiInput = new FileInfo(strInputName);
                string strFileName = FiInput.Name.Remove(FiInput.Name.Length - FiInput.Extension.Length);

                StreamWriter myFile = File.CreateText(strFileName + ".Ozi.log");
                for (int i = 0; i < CsvGpsLog.Length; i++)
                {
                    string strRMC = "";
                    string strGGA = "";
                    string strGSA = "";

                    for (int j = 0; j < CsvGpsLog[i].strRMC.Length - 2; j++)
                    {
                        strRMC += CsvGpsLog[i].strRMC[j] + ",";
                    }
                    strRMC += CsvGpsLog[i].strRMC[CsvGpsLog[i].strRMC.Length - 2];
                    strRMC += "*" + myChk(strRMC.Substring(1, strRMC.Length - 1)).PadLeft(2, '0');

                    for (int j = 0; j < CsvGpsLog[i].strGGA.Length - 2; j++)
                    {
                        strGGA += CsvGpsLog[i].strGGA[j] + ",";
                    }
                    strGGA += CsvGpsLog[i].strGGA[CsvGpsLog[i].strGGA.Length - 2];
                    strGGA += "*" + myChk(strGGA.Substring(1, strGGA.Length - 1)).PadLeft(2, '0');

                    for (int j = 0; j < CsvGpsLog[i].strGSA.Length - 2; j++)
                    {
                        strGSA += CsvGpsLog[i].strGSA[j] + ",";
                    }
                    strGSA += CsvGpsLog[i].strGSA[CsvGpsLog[i].strGSA.Length - 2];
                    strGSA += "*" + myChk(strGSA.Substring(1, strGSA.Length - 1)).PadLeft(2, '0');

                    myFile.WriteLine(strRMC);
                    if (chkGGA.Checked)
                    {
                        myFile.WriteLine(strGGA);
                    }
                    if (chkGSA.Checked)
                    {
                        myFile.WriteLine(strGSA);
                    }
                }
                myFile.Close();

                txtMessage.Text += "共" + CsvGpsLog.Length.ToString() + "点\r\n转换完成\r\n";
                //lblMessage1.Refresh();
            }
            catch
            {
            }
        }

        private void BiJiao(string FileName1)
        {
            int z1 = 0, z2 = 0;
            string[][] strIn1 = new string[0x60 * 60 * 24 * 6][];
            string[][] strIn2 = new string[0x60 * 60 * 24 * 6][];

            string FileName2 = dialogOpen.SafeFileName.ToLower().Replace(".csv", ".nmea");

            var file = new FileInfo(FileName2);

            try
            {
                StreamReader sr1 = new StreamReader(FileName1);

                for (int i = 0; i < strIn1.Length; i++)
                {
                    string strRead = sr1.ReadLine();
                    string[] strTempa = strRead.Replace("\0", "").Split(',');
                    strIn1[i] = strTempa;
                    z1++;
                }
                sr1.Close();
            }
            catch { };

            if (file.Exists)
            {
                try
                {
                    StreamReader sr2 = new StreamReader(FileName2);

                    for (int i = 0; i < strIn2.Length; i++)
                    {
                        string strRead = sr2.ReadLine();
                        string[] strTempa = strRead.Replace("*", ",").Split(',');
                        strIn2[i] = strTempa;
                        z2++;
                    }
                    sr2.Close();
                }
                catch { };
            }

            if (file.Exists)
            {
                try
                {
                    FileInfo FiInput = new FileInfo(FileName1);
                    string strFileName = FiInput.Name.Remove(FiInput.Name.Length - FiInput.Extension.Length);
                    StreamWriter myFile = File.CreateText(strFileName + ".T.txt");

                    int j = 0;
                    int k = 0;
                    int k1 = 0;
                    int k2 = 0;
                    int k3 = 0;
                    int k4 = 1;
                    for (int i = 1; i < z1; i++)
                    {
                        string strT1 = strIn1[i][3];
                        strT1 = strT1.Remove(0, 2);
                        string strT2 = strIn2[j][1];
                        strT2 = strT2.Remove(0, 2).Remove(4, 4);
                        if (strT1 == strT2)
                        {
                            j++;
                        }
                        else
                        {
                            string strTemp = "";
                            if (strIn1[i][3] == strIn1[i - 1][3])
                            {
                                strTemp += " (SimeTime)";
                                k1++;
                            }
                            else if (strIn1[i][8] == "360")
                            {
                                strTemp += " (Heading=360)";
                                k2++;
                            }
                            else if (strTemp == "")
                            {
                                strTemp += " (OtherError)";
                                k3++;
                            }
                            k++;
                            myFile.WriteLine(strIn1[i][0].ToString() + strTemp);
                        }
                    }
                    myFile.Close();
                    txtMessage.Text += "nmea文件有" + (z2).ToString() + "个数据点。\r\n";
                    txtMessage.Text += "CSV文件有" + (z1 - k4).ToString() + "个数据点，其中\r\n";
                    txtMessage.Text += "有" + k.ToString() + "错误数据点：\r\n";
                    txtMessage.Text += " Time相同:\t" + k1.ToString() + "点\r\n";
                    txtMessage.Text += " Heading为360:\t" + k2.ToString() + "点\r\n";
                    txtMessage.Text += " 未知错误:\t" + k3.ToString() + "点\r\n";


                    //lblMessage1.Refresh();
                }
                catch { }
            }

            else
            {
                try
                {
                    FileInfo FiInput = new FileInfo(FileName1);
                    string strFileName = FiInput.Name.Remove(FiInput.Name.Length - FiInput.Extension.Length);
                    StreamWriter myFile = File.CreateText(strFileName + ".T.txt");

                    int k = 0;
                    int k1 = 0;
                    int k2 = 0;
                    int k4 = 1;
                    for (int i = 1; i < z1; i++)
                    {
                        string strTemp = "";
                        if (strIn1[i][3] == strIn1[i - 1][3])
                        {
                            strTemp += " (SimeTime)";
                            k++;
                            k1++;
                            myFile.WriteLine(strIn1[i][0].ToString() + strTemp);
                        }
                        else if (strIn1[i][8] == "360")
                        {
                            strTemp += " (Heading=360)";
                            k++;
                            k2++;
                            myFile.WriteLine(strIn1[i][0].ToString() + strTemp);
                        }
                        else if (strIn1[i][0] == "INDEX")
                        {
                            strTemp += " (No)";
                            k++;
                            k4++;
                            myFile.WriteLine(strIn1[i][0].ToString() + strTemp);
                        }
                    }
                    myFile.Close();
                    txtMessage.Text += "CSV文件有" + z1.ToString() + "行；\r\n";
                    txtMessage.Text += "其中标题行" + k4.ToString() + "行\r\n";
                    txtMessage.Text += "有" + (z1 - k4).ToString() + "个数据点，其中\r\n";
                    txtMessage.Text += "有" + k.ToString() + "错误数据点：\r\n";
                    txtMessage.Text += " Time相同:\t" + k1.ToString() + "点\r\n";
                    txtMessage.Text += " Heading为360:\t" + k2.ToString() + "点\r\n";

                    //lblMessage1.Refresh();
                }
                catch { }
            }
        }

        private void KLDLOG2NMEA(string strInputName)
        {
            GpsLog[] KLDlogGpsLog = Log2MessageKLDLOG(strInputName);

            try
            {
                FileInfo FiInput = new FileInfo(strInputName);
                string strFileName = FiInput.Name.Remove(FiInput.Name.Length - FiInput.Extension.Length);

                StreamWriter myFile = File.CreateText(strFileName + ".KLDLOG.log");
                for (int i = 0; i < KLDlogGpsLog.Length; i++)
                {
                    string strRMC = "";
                    string strGGA = "";
                    //string strGSA = "";

                    for (int j = 0; j < KLDlogGpsLog[i].strRMC.Length - 2; j++)
                    {
                        strRMC += KLDlogGpsLog[i].strRMC[j] + ",";
                    }
                    strRMC += KLDlogGpsLog[i].strRMC[KLDlogGpsLog[i].strRMC.Length - 2];
                    strRMC += "*" + myChk(strRMC.Substring(1, strRMC.Length - 1)).PadLeft(2, '0');

                    for (int j = 0; j < KLDlogGpsLog[i].strGGA.Length - 2; j++)
                    {
                        strGGA += KLDlogGpsLog[i].strGGA[j] + ",";
                    }
                    strGGA += KLDlogGpsLog[i].strGGA[KLDlogGpsLog[i].strGGA.Length - 2];
                    strGGA += "*" + myChk(strGGA.Substring(1, strGGA.Length - 1)).PadLeft(2, '0');

                    myFile.WriteLine(strRMC);
                    if (chkGGA.Checked)
                    {
                        myFile.WriteLine(strGGA);
                    }

                    /*
                    for (int j = 0; j < KLDlogGpsLog[i].strGSA.Length - 2; j++)
                    {
                        strGSA += KLDlogGpsLog[i].strGSA[j] + ",";
                    }
                    strGSA += KLDlogGpsLog[i].strGSA[KLDlogGpsLog[i].strGSA.Length - 2];
                    strGSA += "*" + myChk(strGSA.Substring(1, strGSA.Length - 1)).PadLeft(2, '0');
                     * 
                    if (chkGSA.Checked)
                    {
                        myFile.WriteLine(strGSA);
                    }
                    */
                }
                myFile.Close();

                txtMessage.Text += "共" + KLDlogGpsLog.Length.ToString() + "点\r\n转换完成\r\n";
                //lblMessage1.Refresh();
            }
            catch
            {
            }
        }

        #endregion

        #region Google Map

        public void Map_Load(double Lat, double Lon,int Zcot)//核心代码！将Html读入WinForm中，并传递经纬度参数！  
        {
            string strURL = "<html><head><title>Google Earth定位</title></head><body>" +
                "<iframe width='380' height='380' frameborder='0' scrolling='no' marginheight='0' marginwidth='0'src='http://ditu.google.cn/?ie=UTF8&hq=&ll=" + Lat + "," + Lon + "&spn=1.107711,2.441711&z=" + Zcot + "&output=embed'>" +
                "</iframe><br /><small></body></html>";
            webBrowserMap.DocumentText = strURL;

            webBrowserMap.Navigating += new WebBrowserNavigatingEventHandler(webBrowserMap_Navigating);
            webBrowserMap.ScriptErrorsSuppressed = false;
        }

        private void webBrowserMap_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            System.Windows.Forms.HtmlDocument document = this.webBrowserMap.Document;//定位！
        }

        private void getLatLon(GpsLog[] gpsLogIn)
        {
            try
            {
                double Ymin = gpsLogIn[0].Latitude.value;
                double Xmin = gpsLogIn[0].Longitude.value;
                double Ymax = gpsLogIn[0].Latitude.value;
                double Xmax = gpsLogIn[0].Longitude.value;

                for (int intCouv = 1; intCouv < gpsLogIn.Length; intCouv++)
                {
                    if (gpsLogIn[intCouv].Latitude.value < Ymin)
                    {
                        Ymin = gpsLogIn[intCouv].Latitude.value;
                    }
                    if (gpsLogIn[intCouv].Longitude.value < Xmin)
                    {
                        Xmin = gpsLogIn[intCouv].Longitude.value;
                    }
                    if (gpsLogIn[intCouv].Latitude.value > Ymax)
                    {
                        Ymax = gpsLogIn[intCouv].Latitude.value;
                    }
                    if (gpsLogIn[intCouv].Longitude.value > Xmax)
                    {
                        Xmax = gpsLogIn[intCouv].Longitude.value;
                    }
                }

                double Xcot = Xmax - Xmin;
                double Ycot = Ymax - Ymin;
                double Xpo = Xmax - (Xmax - Xmin) / 2;
                double Ypo = Ymax - (Ymax - Ymin) / 2;
                int Zcot = new int();
                if ((Xcot > Ycot ? Xcot : Ycot) > 0.03)
                {
                    Zcot = 11;
                }
                else if ((Xcot > Ycot ? Xcot : Ycot) < 0.01)
                {
                    Zcot = 13;
                }
                else
                {
                    Zcot = 12;
                }

                if (chkGoogleMap.Checked)
                {
                    Map_Load(Ypo + 0.002, Xpo + 0.005, Zcot);
                }
            }
            catch { }
        }

        #endregion

        private void btnJpg_Click(object sender, EventArgs e)
        {
            if (strOut5[0] != null)
            {
                string[][] strJpg = new string[strOut5[0].Length][];

                for (int i = 0; i < strOut5[0].Length; i++)
                {
                    strJpg[i] = new string[5];
                    strJpg[i][0] = strOut5[0][i].UtcTime.AddHours(8).ToString();
                    strJpg[i][1] =  strOut5[0][i].Latitude.Str.ToString();
                    strJpg[i][2] =  strOut5[0][i].Latitude.value.ToString();
                    strJpg[i][3] =  strOut5[0][i].Longitude.Str.ToString();
                    strJpg[i][4] =  strOut5[0][i].Longitude.value.ToString();
                }
                JpgForm JForm = new JpgForm(strJpg);
                if (JForm.ShowDialog(this) == DialogResult.OK)
                {
                    //We would apply changes here since the user accepted them
                }
                JForm.Dispose();
            }

        }

    }
}

#region  temp

/*
 * 
 *    private string[][] GetInputFileDataxa(string strInputName)
        {
            int x = 0;
            string[][] strIn = new string[0xffff][];

            try
            {
                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);

                for (int i = 0; i < strIn.Length; i++)
                {
                    string strRead = sr.ReadLine();
                    string[] strTemp = strRead.Replace("*", ",").Split(',');

                    if (strTemp[0] == "$GPGGA" || strTemp[0] == "$GPGSA" || strTemp[0] == "$GPGSV" || strTemp[0] == "$GPRMC" || strTemp[0] == "$GPVTG" || strTemp[0] == "$GPGLL")
                    {
                        strIn[x] = strTemp;
                        x++;
                    }
                }
                sr.Close();
            }
            catch { }

            string[][] strOut = new string[x][];
            for (int i = 0; i < x; i++)
            {
                strOut[i] = strIn[i];
            }

            return strOut;

        }
bool isReadOK = false;
for (int k = 0; k < 4; k++)
{
    if (strIn[i + k][0] == "$GPGGA")
    {
        if (strTemp[x].strGGA == null)
        {
            strTemp[x].strGGA = strIn[i + k];
        }
        else
        {
            isReadOK = true;
            break;
        }
    }
    else if (strIn[i + k][0] == "$GPRMC")
    {
        if (strTemp[x].strRMC == null)
        {
            strTemp[x].strRMC = strIn[i + k];
        }
        else
        {
            isReadOK = true;
            break;
        }
    }
    else if (strIn[i + k][0] == "$GPVTG")
    {
        if (strTemp[x].strVTG == null)
        {
            strTemp[x].strVTG = strIn[i + k];
        }
        else
        {
            isReadOK = true;
            break;
        }
    }
    else if (strIn[i + k][0] == "$GPGSA")
    {
        if (strTemp[x].strGSA == null)
        {
            strTemp[x].strGSA = strIn[i + k];
        }
        else
        {
            isReadOK = true;
            break;
        }
    }
}
if (isReadOK)
{
    if ((strTemp[x].strRMC != null && strTemp[x].strGGA != null && strTemp[x].strGSA != null)
        && ((strTemp[x].strGGA[1] == strTemp[x].strRMC[1]) && (strTemp[x].strGGA[2] == strTemp[x].strRMC[3]) && (strTemp[x].strGGA[4] == strTemp[x].strRMC[5])))
    {
        if (strTemp[x].strVTG != null)
        {
            i = i + 3;
        }
        else
        {
            i = i + 2;
        }
    }
    else
    {
        strTemp[x].strRMC = null;
        strTemp[x].strGGA = null;
        strTemp[x].strGSA = null;
        strTemp[x].strVTG = null;
        continue;
    }
}
else
{
    continue;
}
*/

/*
 * 
 * 
         private void buttonRedo_Click(object sender, EventArgs e)
        {
            if ((textBoxLat2.Text.Trim() != "" & textBoxLon2.Text.Trim() != "") & (textBoxLat.Text.Trim() == "" & textBoxLon.Text.Trim() == ""))
            {
                double Lon = Convert.ToDouble(textBoxLon2.Text);
                double Lat = Convert.ToDouble(textBoxLat2.Text);
                Map_Load(Lat, Lon);
                textBoxLat2.Clear(); textBoxLon2.Clear();
            }//获取以度的方式输入的坐标  
            else if (textBoxLat.Text != "" & textBoxLon.Text != "" & textBoxLat2.Text == "" & textBoxLon2.Text == "")
            {
                string LonStr = textBoxLon.Text;
                string LatStr = textBoxLat.Text;
                double Lon = (Convert.ToDouble(LonStr.Substring(LonStr.Length - 2, 2))) / 3600 + (Convert.ToDouble(LonStr.Substring(LonStr.Length - 4, 2))) / 60 + Convert.ToDouble(LonStr.Remove(LonStr.Length - 4, 4));
                double Lat = (Convert.ToDouble(LatStr.Substring(LatStr.Length - 2, 2))) / 3600 + (Convert.ToDouble(LatStr.Substring(LatStr.Length - 4, 2))) / 60 + Convert.ToDouble(LatStr.Remove(LatStr.Length - 4, 4));
                Map_Load(Lat, Lon);
                textBoxLon.Clear(); textBoxLat.Clear();
            }//获取以度分秒输入的坐标信息  
            else
            {
                MessageBox.Show("输入格式有误！请核对输入格式！/n“度分秒”格式如1084530，位数为5~7位。/n“度”格式如35.06，位数小于16。/n北纬为正数，南纬为负数。/n东经为正数，西经为负数。", "出错啦！", MessageBoxButtons.OK);
                textBoxLon2.Clear(); textBoxLon.Clear(); textBoxLat2.Clear(); textBoxLat.Clear();
            }//如果输入格式有误，则清除现有文本框里的内容  
        } 
 * 
 * 
 * 
 * 
 */

#endregion
