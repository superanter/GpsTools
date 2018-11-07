using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace GpsTools

{
    public partial class OldForm : Form
    {
        public OldForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            double iX1 = 5.928;
            double iY1 = 4.029;
            string sColor = "A00080ff";
            int iWidth = 6;
            int iPastPoint = 4;
            int iGMTime = 8;
            string strIcon1 = "http://maps.google.com/mapfiles/kml/shapes/arrow.png";
            string strIcon2 = "http://maps.google.com/mapfiles/kml/shapes/placemark_circle.png";
            double[][] iPointScale = new double[][] { new double[] { 0.5, 1.0 }, new double[] { 0.3, 0.5 } }; 
            txtX1.Text = iX1.ToString();
            txtY1.Text = iY1.ToString();
            txtTrackColor.Text = sColor;
            txtTrackWidth.Text = iWidth.ToString();
            txtPastPoint.Text = iPastPoint.ToString();
            txt10.Text = strIcon1;
            txt11.Text = iPointScale[0][0].ToString();
            txt12.Text = iPointScale[0][1].ToString();
            txt20.Text = strIcon2;
            txt21.Text = iPointScale[1][0].ToString();
            txt22.Text = iPointScale[1][1].ToString();
            cboAltitudeMode.SelectedIndex = 0;
            txtTime.Text = iGMTime.ToString();


        }

        private void btnResort_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void OpenInputFile()		//打开源文件
        {
            string OpenFilter = "";

            OpenFilter += "All Files(*.*)|*.*";

            dialogOpen.Filter = OpenFilter;

            if (dialogOpen.ShowDialog() == DialogResult.OK)
            {
                //
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenInputFile();

            if (dialogOpen.FileName != "")
            {
                GetInputFileData(dialogOpen.FileName);
            }
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            if (txtTrackColor.Text.Length == 8)
            {
                try
                {
                    int cA = Convert.ToInt32(txtTrackColor.Text.Remove(2), 16);
                    int cB = Convert.ToInt32(txtTrackColor.Text.Remove(0, 2).Remove(2), 16);
                    int cG = Convert.ToInt32(txtTrackColor.Text.Remove(0, 4).Remove(2), 16);
                    int cR = Convert.ToInt32(txtTrackColor.Text.Remove(0, 6), 16);

                    lblColor2.BackColor = System.Drawing.Color.FromArgb(cA, cR, cG, cB);

                    lblColor2.Refresh();
                }
                catch
                { }
            }
        }

        private void GetInputFileData(string strInputName)
        {
            try
            {
                TrackFiles[] MyTrackFile;

                if (chkGpsLog.Checked == true)
                {
                    MyTrackFile = ReadData_LOG(strInputName);

                    lblOut.Text = "GPS LOG Track\n\n";
                    lblOut.Text += "Track: " + MyTrackFile[0].Point.Length.ToString() + "\n";
                    lblOut.Refresh();

                    WriteDate(strInputName, MyTrackFile);

                    lblOut.Text += "\nOK!\n";
                    lblOut.Refresh();

                }
                else
                {

                    FileStream sri = new FileStream(strInputName, FileMode.Open, FileAccess.Read);
                    BinaryReader r = new BinaryReader(sri);

                    string txtString = new string(r.ReadChars(26));
                    r.Close();
                    sri.Close();


                    if (txtString == "Careland Navi HistoryTrack")
                    {
                        MyTrackFile = ReadData_KLD(strInputName);

                        lblOut.Text = "KLD Tracks: " + MyTrackFile.Length.ToString() + "\n\n";
                        for (int i = 0; i < MyTrackFile.Length; i++)
                        {
                            lblOut.Text += "Track " + (i + 1).ToString() + ": " + MyTrackFile[i].Point.Length.ToString() + "\n";
                        }
                        lblOut.Refresh();

                        WriteDate(strInputName, MyTrackFile);

                        lblOut.Text += "\nOK!\n";
                        lblOut.Refresh();
                    }
                    else if (txtString == "OziExplorer Track Point Fi")
                    {
                        MyTrackFile = ReadData_OZI(strInputName);

                        lblOut.Text = "OZI Track\n\n";
                        lblOut.Text += "Track: " + MyTrackFile[0].Point.Length.ToString() + "\n";
                        lblOut.Refresh();

                        WriteDate(strInputName, MyTrackFile);

                        lblOut.Text += "\nOK!\n";
                        lblOut.Refresh();
                    }
                    else if (txtString == "<?xml version=\"1.0\"?><kml ")
                    {
                        MyTrackFile = ReadData_KML_1(strInputName);

                        lblOut.Text = "Kml(GPSLogger)\n\n";
                        lblOut.Text += "Track: " + MyTrackFile[0].Point.Length.ToString() + "\n";
                        lblOut.Refresh();

                        WriteDate(strInputName, MyTrackFile);

                        lblOut.Text += "\nOK!\n";
                        lblOut.Refresh();
                    }
                    else if (txtString == "<?xml version='1.0' encodi")
                    {
                        MyTrackFile = ReadData_KML_2(strInputName);

                        lblOut.Text = "Kml(RMap)\n\n";
                        lblOut.Text += "Track: " + MyTrackFile[0].Point.Length.ToString() + "\n";
                        lblOut.Refresh();

                        WriteDate(strInputName, MyTrackFile);

                        lblOut.Text += "\nOK!\n";
                        lblOut.Refresh();
                    }
                    else
                    {
                        lblOut.Text = "Unkown\n";
                        lblOut.Refresh();
                    }
                }

            }
            catch
            {
            }
        }

        private TrackFiles[] ReadData_KLD(String strInputName)
        {
            TrackFiles[] MyFile;
            double size = 3600000.0;
            int intX = 0;

            try
            {
                FileStream sri = new FileStream(strInputName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(sri);

                r.ReadChars(26);
                r.ReadBytes(30);

                MyFile = new TrackFiles[r.ReadByte()];
                r.ReadBytes(11);

                for (int i = 0; i < MyFile.Length; i++)
                {
                    do
                    {
                        intX = r.ReadInt32();

                    } while (intX == 0);

                    MyFile[i].TrackName = new string(r.ReadChars(40)).Replace("\0", "");

                    string[] strTimeBase = MyFile[i].TrackName.Split('_');

                    MyFile[i].Point = new TrackFiles.point[intX % 0x10000];

                    //数组
                    for (int j = 0; j < MyFile[i].Point.Length; j++)
                    {
                        int xx = r.ReadInt32();
                        int yy = r.ReadInt32();

                        if (xx != 0 && yy != 0)
                        {
                            MyFile[i].Point[j].East = xx / size - Convert.ToDouble(txtX1.Text) / 60;
                            MyFile[i].Point[j].North = yy / size - Convert.ToDouble(txtY1.Text) / 60;
                            MyFile[i].Point[j].High = 0.0;
                            MyFile[i].Point[j].Time = new DateTime(Convert.ToInt32(strTimeBase[0]), Convert.ToInt32(strTimeBase[1]), Convert.ToInt32(strTimeBase[2]), Convert.ToInt32(strTimeBase[3]), Convert.ToInt32(strTimeBase[4]), Convert.ToInt32(strTimeBase[5]));
                        }
                        else
                        {
                            break;
                        }
                    }
                    do
                    {
                        intX = r.ReadInt32();

                    } while (intX != 0);
                }
                r.Close();
                sri.Close();
            }
            catch
            {
                MyFile = new TrackFiles[0];
            }

            return MyFile;
        }

        private TrackFiles[] ReadData_OZI(String strInputName)
        {
            TrackFiles[] MyFileOut =new TrackFiles[1];
            TrackFiles MyTrackTemp = new TrackFiles();
            MyTrackTemp.Point = new TrackFiles.point[0xffff];
            int x = 0;
            try
            {
                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);
                MyFileOut[0].TrackName = FInfo.Name;
                for (int i = 0; i < MyTrackTemp.Point.Length; i++)
                {
                    string[] strString = sr.ReadLine().Split(',');
                    if ((strString.Length == 5 || strString.Length == 7) && strString[0] != "0")
                    {
                        double myTimes = Convert.ToDouble(strString[4]);
                        int myDays = (int)myTimes;
                        int mySeconds = (int)(Math.Round((myTimes - myDays) * 24 * 60 * 60, 0) + Convert.ToInt16(txtTime.Text) * 60 * 60);
                        DateTime numDate = new DateTime(1899, 12, 30).AddDays(myDays).AddSeconds(mySeconds);

                        MyTrackTemp.Point[x].North = Convert.ToDouble(strString[0]);
                        MyTrackTemp.Point[x].East = Convert.ToDouble(strString[1]);
                        MyTrackTemp.Point[x].High = Math.Round((Convert.ToDouble(strString[3]) / 3.28084), 2);
                        MyTrackTemp.Point[x].Time = numDate;
                        x++;
                    }
                }
            }
            catch { }

            MyFileOut[0].Point = new TrackFiles.point[x];

            for (int i = 0; i < x; i++)
            {
                MyFileOut[0].Point[i] = MyTrackTemp.Point[i];
            }

            return MyFileOut;
        }

        private TrackFiles[] ReadData_LOG(String strInputName)
        {
            TrackFiles[] MyFileOut = new TrackFiles[1];
            TrackFiles MyTrackTemp = new TrackFiles();
            MyTrackTemp.Point = new TrackFiles.point[0xffff];
            int x = 0;
            try
            {
                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);
                MyFileOut[0].TrackName = FInfo.Name;
                for (int i = 0; i < MyTrackTemp.Point.Length; i++)
                {
                    string[] strString1 = sr.ReadLine().Split(',');
                    if (strString1[0] == "$GPGGA")
                    {
                        string[] strString2 = sr.ReadLine().Split(',');
                        if (strString2[0] == "$GPRMC")
                        {
                            double MyNorth = Convert.ToInt32(strString1[2].Remove(2, 7)) + Convert.ToDouble(strString1[2].Remove(0, 2)) / 60.0;
                            double MyEast = Convert.ToInt32(strString1[4].Remove(3, 7)) + Convert.ToDouble(strString1[4].Remove(0, 3)) / 60.0;

                            MyTrackTemp.Point[x].North = (strString1[3].ToUpper() != "S" ? MyNorth : 0 - MyNorth);
                            MyTrackTemp.Point[x].East = (strString1[5].ToUpper() != "W" ? MyEast : 0 - MyEast);
                            MyTrackTemp.Point[x].High = Math.Round(Convert.ToDouble(strString1[9]), 2);
                            MyTrackTemp.Point[x].Time = new DateTime(
                                Convert.ToInt32(strString2[9].Remove(0, 4)) + 2000,
                                Convert.ToInt32(strString2[9].Remove(0, 2).Remove(2, 2)),
                                Convert.ToInt32(strString2[9].Remove(2, 4)),
                                Convert.ToInt32(strString1[1].Remove(2, 7)),
                                Convert.ToInt32(strString1[1].Remove(0, 2).Remove(2, 5)),
                                Convert.ToInt32(strString1[1].Remove(0, 4).Remove(2, 3))
                                );
                            MyTrackTemp.Point[x].Time.AddHours(Convert.ToDouble(txtTime.Text));
                            x++;
                        }
                    }
                }
            }
            catch { }

            MyFileOut[0].Point = new TrackFiles.point[x];

            for (int i = 0; i < x; i++)
            {
                MyFileOut[0].Point[i] = MyTrackTemp.Point[i];
            }

            return MyFileOut;
        }

        private TrackFiles[] ReadData_KML_1(String strInputName)
        {
            TrackFiles[] MyFileOut = new TrackFiles[1];
            TrackFiles MyTrackTemp = new TrackFiles();
            MyTrackTemp.Point = new TrackFiles.point[0xffff];
            string[] strString;
            int x = 0;
            try
            {
                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);
                MyFileOut[0].TrackName = FInfo.Name;
                for (int i = 0; i < MyTrackTemp.Point.Length; i++)
                {
                    string sString = sr.ReadLine();
                    sString = sString.Replace("<?xml version=\"1.0\"?><kml xmlns=\"http://www.opengis.net/kml/2.2\"><Document>","");
                    sString = sString.Replace("<Placemark><description>", "");
                    sString = sString.Replace("</description><TimeStamp><when>", ",");
                    sString = sString.Replace("</when></TimeStamp><Point><coordinates>", ",");
                    sString = sString.Replace("</coordinates></Point></Placemark>", ",");
                    sString = sString.Replace("</Document></kml>", "");

                    strString = sString.Split(',');
                    x = strString.Length;

                    for (int j = 0; j < strString.Length / 5; j++)
                    {
                        MyTrackTemp.Point[j].East = Convert.ToDouble(strString[j * 5 + 2]);
                        MyTrackTemp.Point[j].North = Convert.ToDouble(strString[j * 5 + 3]);
                        MyTrackTemp.Point[j].High = Convert.ToDouble(strString[j * 5 + 4]);

                        string[] strTimeTemp = strString[j * 5].Replace("+08:00", "").Replace("-", ",").Replace(":", ",").Replace("T", ",").Split(',');
                        MyTrackTemp.Point[j].Time = new DateTime(Convert.ToInt32(strTimeTemp[0]), Convert.ToInt32(strTimeTemp[1]), Convert.ToInt32(strTimeTemp[2]), Convert.ToInt32(strTimeTemp[3]), Convert.ToInt32(strTimeTemp[4]), Convert.ToInt32(strTimeTemp[5]));
                    }
                }
            }
            catch { }

            MyFileOut[0].Point = new TrackFiles.point[x/5];

            for (int i = 0; i < x/5; i++)
            {
                MyFileOut[0].Point[i] = MyTrackTemp.Point[i];
            }

            return MyFileOut;
        }

        private TrackFiles[] ReadData_KML_2(String strInputName)
        {
            TrackFiles[] MyFileOut = new TrackFiles[1];
            TrackFiles MyTrackTemp = new TrackFiles();
            MyTrackTemp.Point = new TrackFiles.point[0xffff];
            string[] strString;
            int x = 0;
            try
            {
                StreamReader sr = new StreamReader(strInputName);
                FileInfo FInfo = new FileInfo(strInputName);
                MyFileOut[0].TrackName = FInfo.Name;
                for (int i = 0; i < MyTrackTemp.Point.Length; i++)
                {
                    string sString = sr.ReadLine();
                    sString = sString.Replace("<?xml version='1.0' encoding='Utf-8' standalone='yes' ?><kml xmlns=\"http://www.opengis.net/kml/2.2\" xmlns:gx=\"http://www.google.com/kml/ext/2.2\">", "");
                    sString = sString.Replace("<Placemark><name>", "");
                    sString = sString.Replace("</name><desc /><LineString><coordinates>", ",");
                    sString = sString.Replace("</name><desc></desc><LineString><coordinates>", ",");
                    sString = sString.Replace("</coordinates></LineString></Placemark></kml>", ",");
                    sString = sString.Replace("0.0 ", "0.0,");

                    strString = sString.Split(',');
                    x = strString.Length - 2;

                    for (int j = 0; j < strString.Length / 3; j++)
                    {
                        MyTrackTemp.Point[j].East = Convert.ToDouble(strString[j * 3 + 1]);
                        MyTrackTemp.Point[j].North = Convert.ToDouble(strString[j * 3 + 2]);
                        MyTrackTemp.Point[j].High = Convert.ToDouble(strString[j * 3 + 3]);
                        MyTrackTemp.Point[j].Time = FInfo.LastWriteTime;

                        //MyTrackTemp.Point[j].Time= new DateTime(0);
                        //string[] strTimeTemp = strString[j * 5].Replace("+08:00", "").Replace("-", ",").Replace(":", ",").Replace("T", ",").Split(',');
                        //MyTrackTemp.Point[j].Time = new DateTime(Convert.ToInt32(strTimeTemp[0]), Convert.ToInt32(strTimeTemp[1]), Convert.ToInt32(strTimeTemp[2]), Convert.ToInt32(strTimeTemp[3]), Convert.ToInt32(strTimeTemp[4]), Convert.ToInt32(strTimeTemp[5]));
                    }
                }
            }
            catch { }

            MyFileOut[0].Point = new TrackFiles.point[x / 3];

            for (int i = 0; i < x / 3; i++)
            {
                MyFileOut[0].Point[i] = MyTrackTemp.Point[i];
            }

            return MyFileOut;
        }

        private void WriteDate(string strInputName, TrackFiles[] MyFile)
        {
            StreamWriter myFile = File.CreateText(strInputName + ".kml");

            myFile.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            myFile.WriteLine("<kml xmlns=\"http://earth.google.com/kml/2.2\">");
            myFile.WriteLine("  <Document>");
            myFile.WriteLine("    <name>HistTrack(By ANTer)</name>");

            #region   Style

            //Style 1
            myFile.WriteLine("         <Style id=\"sn_placemark_arrow\">");
            myFile.WriteLine("      		<IconStyle>");
            myFile.WriteLine("      		<color>ff00ffff</color>");
            myFile.WriteLine("      			<scale>" + txt11.Text + "</scale>");
            myFile.WriteLine("      			<Icon>");
            myFile.WriteLine("      				<href>" + txt10.Text + "</href>");
            myFile.WriteLine("      			</Icon>");
            myFile.WriteLine("      		</IconStyle>");
            myFile.WriteLine("      		<LabelStyle>");
            myFile.WriteLine("      			<scale>" + txt12.Text + "</scale>");
            myFile.WriteLine("      		</LabelStyle>");
            myFile.WriteLine("      	</Style>");

            //Style 2
            myFile.WriteLine("            <Style id=\"sn_placemark_circle\">");
            myFile.WriteLine("      		<IconStyle>");
            myFile.WriteLine("      			<scale>" + txt21.Text + "</scale>");
            myFile.WriteLine("      			<Icon>");
            myFile.WriteLine("      				<href>" + txt20.Text + "</href>");
            myFile.WriteLine("      			</Icon>");
            myFile.WriteLine("      		</IconStyle>");
            myFile.WriteLine("      		<LabelStyle>");
            myFile.WriteLine("      			<scale>" + txt22.Text + "</scale>");
            myFile.WriteLine("      		</LabelStyle>");
            myFile.WriteLine("      	</Style>");

            //Style 3
            myFile.WriteLine("    <Style id=\"lineStyle\">");
            myFile.WriteLine("      <LineStyle>");
            myFile.WriteLine("        <color>" + txtTrackColor.Text + "</color>");
            myFile.WriteLine("        <width>" + Convert.ToInt16(txtTrackWidth.Text) + "</width>");
            myFile.WriteLine("      </LineStyle>");
            myFile.WriteLine("    </Style>");

            #endregion

            for (int i = 0; i < MyFile.Length; i++)
            {
                myFile.WriteLine("      <Folder>");
                myFile.WriteLine("        <name>" + MyFile[i].TrackName + "</name>");

                #region    写入路径点

                if (chkWathPoint.Checked)
                {

                    //起点
                    WritePointText(myFile, MyFile[i].Point, 0, "sn_placemark_arrow");

                    //中间点
                    myFile.WriteLine("          <Folder>");
                    myFile.WriteLine("            <name>Point</name>");

                    for (int j = 1; j < MyFile[i].Point.Length - 1; j++)
                    {
                        if (MyFile[i].Point[j].East != 0 && MyFile[i].Point[j].North != 0)
                        {
                            if (j % Convert.ToInt16(txtPastPoint.Text) == 0)
                            {
                                WritePointText(myFile, MyFile[i].Point, j, "sn_placemark_circle");
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    myFile.WriteLine("          </Folder>");

                    //终点
                    WritePointText(myFile, MyFile[i].Point, MyFile[i].Point.Length - 1, "sn_placemark_arrow");   //终点
                }
                #endregion

                #region    写入路径

                if (chkWathTrack.Checked)
                {
                    myFile.WriteLine("    <Placemark>");
                    myFile.WriteLine("      <name>Track</name>");
                    myFile.WriteLine("        <styleUrl>lineStyle</styleUrl>");
                    myFile.WriteLine("      <LineString>");
                    myFile.WriteLine("        <coordinates>");

                    for (int j = 0; j < MyFile[i].Point.Length; j++)
                    {
                        if (MyFile[i].Point[j].East == 0 || MyFile[i].Point[j].North == 0)
                            break;
                        myFile.WriteLine(MyFile[i].Point[j].East.ToString().PadRight(16, '0') + "," + MyFile[i].Point[j].North.ToString().PadRight(16, '0') + "," + MyFile[i].Point[j].High);

                    }

                    myFile.WriteLine("        </coordinates>");
                    myFile.WriteLine("      </LineString>");
                    myFile.WriteLine("    </Placemark>");
                }

                #endregion

                myFile.WriteLine("   </Folder>");
            }

            myFile.WriteLine("  </Document>");
            myFile.WriteLine("</kml>");

            myFile.Close();
        }

        private void WritePointText(StreamWriter myFile, TrackFiles.point[] MyTrack, int iWrite, string styleUrl)
        {
            CultureInfo ci = new CultureInfo("en-us");

            string strOut = (iWrite == 0 ? "起点" : (iWrite == MyTrack.Length - 1 ? "终点" : ((iWrite / Convert.ToInt16(txtPastPoint.Text)) + 1).ToString()));

            myFile.WriteLine("      <Placemark>");
            myFile.WriteLine("            <Snippet/>");
            myFile.WriteLine("            <description><![CDATA[");
            myFile.WriteLine("              <table>");
            myFile.WriteLine("                <tr><td>时间：" + MyTrack[iWrite].Time.ToString().Replace('.', '-') + "</td></tr>");
            myFile.WriteLine("                <tr><td>经度：" + MyTrack[iWrite].East.ToString("F06", ci) + "</td></tr>");
            myFile.WriteLine("                <tr><td>纬度：" + MyTrack[iWrite].North.ToString("F06", ci) + "</td></tr>");
            myFile.WriteLine("                <tr><td>高度：" + MyTrack[iWrite].High.ToString("F02", ci) + "</td></tr>");
            myFile.WriteLine("              </table>");
            myFile.WriteLine("            ]]></description>");
            myFile.WriteLine("         <styleUrl>" + styleUrl + "</styleUrl>");
            myFile.WriteLine("         <name>" + strOut + "</name>");

            if (chkTimeStamp.Checked)
            {
                myFile.WriteLine("         <TimeStamp>");
                myFile.WriteLine("            <when>" + MyTrack[iWrite].Time.ToString().Replace('.', '-').Replace(' ', 'T') + "Z" + "</when>");
                myFile.WriteLine("         </TimeStamp>");
            }

            myFile.WriteLine("         <Point>");
            myFile.WriteLine("      <extrude>0</extrude>");

            if (chkTessellate.Checked)
            {
                myFile.WriteLine("      <tessellate>1</tessellate>");
            }
            else
            {
                myFile.WriteLine("      <tessellate>0</tessellate>");
            }

            if (cboAltitudeMode.SelectedIndex == 0)
            {

                myFile.WriteLine("      <altitudeMode>clampedToGround</altitudeMode>");
            }
            else if (cboAltitudeMode.SelectedIndex == 1)
            {

                myFile.WriteLine("      <altitudeMode>relativeToGround</altitudeMode>");
            }
            else if (cboAltitudeMode.SelectedIndex == 2)
            {

                myFile.WriteLine("      <altitudeMode>absolute</altitudeMode>");
            }

            myFile.WriteLine("            <coordinates>" + MyTrack[iWrite].East + "," + MyTrack[iWrite].North + "," + MyTrack[iWrite].High + "</coordinates>");
            myFile.WriteLine("         </Point>");
            myFile.WriteLine("      </Placemark>");

        }

        private struct TrackFiles
        {
            public struct point
            {
                public double East;
                public double North;
                public double High;
                public DateTime Time;
            }
            public string TrackName;
            public point[] Point;
        }
    }
}
