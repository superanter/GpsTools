using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GpsTools
{
    public partial class KCodeForm : Form
    {
        public KCodeForm()
        {
            InitializeComponent();
        }

        string strDec34 = "0123456789abcdefghjklmnpqrstuvwxyz";

        private void btnK2NS_Click(object sender, EventArgs e)
        {
            string strKcodeX = txtKCode.Text.Substring(1, 4);
            string strKcodeY = txtKCode.Text.Substring(5, 4);
            string strKcodeZ = txtKCode.Text.Substring(0, 1);
            int intX = strDec34.IndexOf(strKcodeX.Substring(3, 1)) * 34 * 34 * 34 + strDec34.IndexOf(strKcodeX.Substring(2, 1)) * 34 * 34 + strDec34.IndexOf(strKcodeX.Substring(1, 1)) * 34 + strDec34.IndexOf(strKcodeX.Substring(0, 1));
            int intY = strDec34.IndexOf(strKcodeY.Substring(3, 1)) * 34 * 34 * 34 + strDec34.IndexOf(strKcodeY.Substring(2, 1)) * 34 * 34 + strDec34.IndexOf(strKcodeY.Substring(1, 1)) * 34 + strDec34.IndexOf(strKcodeX.Substring(0, 1));
            int intX1 = intX / 36000;
            int intY1 = intY / 36000;
            int intX2 = (intX - intX1 * 36000) / 600;
            int intY2 = (intY - intY1 * 36000) / 600;
            int intX3 = (intX - intX1 * 36000 - intX2 * 600) / 10;
            int intY3 = (intY - intY1 * 36000 - intY2 * 600) / 10;
            
            if (strKcodeZ == "5")
            {
                intX1 += 105;
                intY1 += 40;
            }
            else if (strKcodeZ == "6")
            {
                intX1 += 70;
                intY1 += 40;
            }
            else if (strKcodeZ == "7")
            {
                intX1 += 70;
                intY1 += 5;
            }
            else if (strKcodeZ == "8")
            {
                intX1 += 105;
                intY1 += 5;
            }
            txtX.Text = intX1.ToString() + " " + intX2.ToString() + " " + intX3.ToString();
            txtY.Text = intY1.ToString() + " " + intY2.ToString() + " " + intY3.ToString();
        }
    }
}
