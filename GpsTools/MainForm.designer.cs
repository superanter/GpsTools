namespace GpsTools
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.txtOut2 = new System.Windows.Forms.Label();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtOut1 = new System.Windows.Forms.Label();
            this.btnPre100 = new System.Windows.Forms.Button();
            this.btnNext100 = new System.Windows.Forms.Button();
            this.lblRound = new System.Windows.Forms.Label();
            this.txtOut3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblOut5 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.webBrowserMap = new System.Windows.Forms.WebBrowser();
            this.btnDownMap = new System.Windows.Forms.Button();
            this.btnUpMap = new System.Windows.Forms.Button();
            this.lblX1 = new System.Windows.Forms.Label();
            this.lblY1 = new System.Windows.Forms.Label();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpKLD = new System.Windows.Forms.GroupBox();
            this.rdo5 = new System.Windows.Forms.RadioButton();
            this.rdo4 = new System.Windows.Forms.RadioButton();
            this.rdo3 = new System.Windows.Forms.RadioButton();
            this.rdo2 = new System.Windows.Forms.RadioButton();
            this.rdo1 = new System.Windows.Forms.RadioButton();
            this.lblKLD = new System.Windows.Forms.Label();
            this.grpDH = new System.Windows.Forms.GroupBox();
            this.btnKCode = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkGGA = new System.Windows.Forms.CheckBox();
            this.chkGSA = new System.Windows.Forms.CheckBox();
            this.chkGoogleMap = new System.Windows.Forms.CheckBox();
            this.btnOld = new System.Windows.Forms.Button();
            this.dialogOpenNmea = new System.Windows.Forms.OpenFileDialog();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnJpg = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.grpKLD.SuspendLayout();
            this.grpDH.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 442);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(50, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnPre
            // 
            this.btnPre.Enabled = false;
            this.btnPre.Location = new System.Drawing.Point(21, 18);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(55, 25);
            this.btnPre.TabIndex = 1;
            this.btnPre.Text = "上一条";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(78, 18);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(55, 25);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "下一条";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(317, 442);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 30);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtOut2
            // 
            this.txtOut2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOut2.Location = new System.Drawing.Point(12, 9);
            this.txtOut2.Name = "txtOut2";
            this.txtOut2.Size = new System.Drawing.Size(342, 172);
            this.txtOut2.TabIndex = 8;
            // 
            // btnFirst
            // 
            this.btnFirst.Enabled = false;
            this.btnFirst.Location = new System.Drawing.Point(78, 60);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(55, 23);
            this.btnFirst.TabIndex = 9;
            this.btnFirst.Text = "第一条";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Location = new System.Drawing.Point(136, 60);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(55, 23);
            this.btnLast.TabIndex = 10;
            this.btnLast.Text = "最后条";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.BtnLast_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(829, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel3.Text = "数据格式";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "无数据";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel2.Text = "未打开文件";
            // 
            // txtOut1
            // 
            this.txtOut1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOut1.Location = new System.Drawing.Point(305, 293);
            this.txtOut1.Name = "txtOut1";
            this.txtOut1.Size = new System.Drawing.Size(114, 139);
            this.txtOut1.TabIndex = 12;
            // 
            // btnPre100
            // 
            this.btnPre100.Enabled = false;
            this.btnPre100.Location = new System.Drawing.Point(134, 20);
            this.btnPre100.Name = "btnPre100";
            this.btnPre100.Size = new System.Drawing.Size(55, 23);
            this.btnPre100.TabIndex = 13;
            this.btnPre100.Text = "上100条";
            this.btnPre100.UseVisualStyleBackColor = true;
            this.btnPre100.Click += new System.EventHandler(this.btnPre100_Click);
            // 
            // btnNext100
            // 
            this.btnNext100.Enabled = false;
            this.btnNext100.Location = new System.Drawing.Point(192, 19);
            this.btnNext100.Name = "btnNext100";
            this.btnNext100.Size = new System.Drawing.Size(55, 23);
            this.btnNext100.TabIndex = 14;
            this.btnNext100.Text = "下100条";
            this.btnNext100.UseVisualStyleBackColor = true;
            this.btnNext100.Click += new System.EventHandler(this.btnNext100_Click);
            // 
            // lblRound
            // 
            this.lblRound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRound.Location = new System.Drawing.Point(3, 3);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(430, 428);
            this.lblRound.TabIndex = 15;
            this.lblRound.Paint += new System.Windows.Forms.PaintEventHandler(this.lblRound_Paint);
            // 
            // txtOut3
            // 
            this.txtOut3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOut3.Location = new System.Drawing.Point(6, 3);
            this.txtOut3.Name = "txtOut3";
            this.txtOut3.Size = new System.Drawing.Size(114, 429);
            this.txtOut3.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(373, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(444, 460);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblRound);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(436, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "路径图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtOut1);
            this.tabPage2.Controls.Add(this.lblOut5);
            this.tabPage2.Controls.Add(this.txtOut3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(436, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "卫星图";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblOut5
            // 
            this.lblOut5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOut5.Location = new System.Drawing.Point(152, 26);
            this.lblOut5.Name = "lblOut5";
            this.lblOut5.Size = new System.Drawing.Size(250, 250);
            this.lblOut5.TabIndex = 16;
            this.lblOut5.Paint += new System.Windows.Forms.PaintEventHandler(this.lblOut5_Paint);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.webBrowserMap);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(436, 434);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Google";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // webBrowserMap
            // 
            this.webBrowserMap.Location = new System.Drawing.Point(4, 7);
            this.webBrowserMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMap.Name = "webBrowserMap";
            this.webBrowserMap.Size = new System.Drawing.Size(317, 303);
            this.webBrowserMap.TabIndex = 0;
            this.webBrowserMap.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowserMap_Navigating);
            // 
            // btnDownMap
            // 
            this.btnDownMap.Enabled = false;
            this.btnDownMap.Location = new System.Drawing.Point(192, 60);
            this.btnDownMap.Name = "btnDownMap";
            this.btnDownMap.Size = new System.Drawing.Size(73, 23);
            this.btnDownMap.TabIndex = 18;
            this.btnDownMap.Text = "下一星图";
            this.btnDownMap.UseVisualStyleBackColor = true;
            this.btnDownMap.Click += new System.EventHandler(this.btnDownMap_Click);
            // 
            // btnUpMap
            // 
            this.btnUpMap.Enabled = false;
            this.btnUpMap.Location = new System.Drawing.Point(5, 60);
            this.btnUpMap.Name = "btnUpMap";
            this.btnUpMap.Size = new System.Drawing.Size(73, 23);
            this.btnUpMap.TabIndex = 19;
            this.btnUpMap.Text = "上一星图";
            this.btnUpMap.UseVisualStyleBackColor = true;
            this.btnUpMap.Click += new System.EventHandler(this.btnUpMap_Click);
            // 
            // lblX1
            // 
            this.lblX1.Location = new System.Drawing.Point(6, 27);
            this.lblX1.Name = "lblX1";
            this.lblX1.Size = new System.Drawing.Size(78, 13);
            this.lblX1.TabIndex = 20;
            this.lblX1.Text = "东西方向偏移";
            // 
            // lblY1
            // 
            this.lblY1.Location = new System.Drawing.Point(7, 53);
            this.lblY1.Name = "lblY1";
            this.lblY1.Size = new System.Drawing.Size(78, 14);
            this.lblY1.TabIndex = 21;
            this.lblY1.Text = "南北方向偏移";
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(90, 19);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(46, 21);
            this.txtX1.TabIndex = 24;
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(91, 47);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(46, 21);
            this.txtY1.TabIndex = 25;
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(69, 442);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(50, 30);
            this.btnRun.TabIndex = 28;
            this.btnRun.Text = "转换";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(124, 442);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(50, 30);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpKLD
            // 
            this.grpKLD.Controls.Add(this.rdo5);
            this.grpKLD.Controls.Add(this.rdo4);
            this.grpKLD.Controls.Add(this.rdo3);
            this.grpKLD.Controls.Add(this.rdo2);
            this.grpKLD.Controls.Add(this.rdo1);
            this.grpKLD.Controls.Add(this.lblKLD);
            this.grpKLD.Controls.Add(this.lblX1);
            this.grpKLD.Controls.Add(this.lblY1);
            this.grpKLD.Controls.Add(this.txtX1);
            this.grpKLD.Controls.Add(this.txtY1);
            this.grpKLD.Enabled = false;
            this.grpKLD.Location = new System.Drawing.Point(8, 290);
            this.grpKLD.Name = "grpKLD";
            this.grpKLD.Size = new System.Drawing.Size(156, 130);
            this.grpKLD.TabIndex = 30;
            this.grpKLD.TabStop = false;
            this.grpKLD.Text = "凯立德";
            // 
            // rdo5
            // 
            this.rdo5.AutoSize = true;
            this.rdo5.Enabled = false;
            this.rdo5.Location = new System.Drawing.Point(116, 98);
            this.rdo5.Name = "rdo5";
            this.rdo5.Size = new System.Drawing.Size(29, 16);
            this.rdo5.TabIndex = 33;
            this.rdo5.TabStop = true;
            this.rdo5.Text = "5";
            this.rdo5.UseVisualStyleBackColor = true;
            this.rdo5.CheckedChanged += new System.EventHandler(this.rdo5_CheckedChanged);
            // 
            // rdo4
            // 
            this.rdo4.AutoSize = true;
            this.rdo4.Enabled = false;
            this.rdo4.Location = new System.Drawing.Point(81, 98);
            this.rdo4.Name = "rdo4";
            this.rdo4.Size = new System.Drawing.Size(29, 16);
            this.rdo4.TabIndex = 32;
            this.rdo4.TabStop = true;
            this.rdo4.Text = "4";
            this.rdo4.UseVisualStyleBackColor = true;
            this.rdo4.CheckedChanged += new System.EventHandler(this.rdo4_CheckedChanged);
            // 
            // rdo3
            // 
            this.rdo3.AutoSize = true;
            this.rdo3.Enabled = false;
            this.rdo3.Location = new System.Drawing.Point(46, 98);
            this.rdo3.Name = "rdo3";
            this.rdo3.Size = new System.Drawing.Size(29, 16);
            this.rdo3.TabIndex = 31;
            this.rdo3.TabStop = true;
            this.rdo3.Text = "3";
            this.rdo3.UseVisualStyleBackColor = true;
            this.rdo3.CheckedChanged += new System.EventHandler(this.rdo3_CheckedChanged);
            // 
            // rdo2
            // 
            this.rdo2.AutoSize = true;
            this.rdo2.Enabled = false;
            this.rdo2.Location = new System.Drawing.Point(104, 77);
            this.rdo2.Name = "rdo2";
            this.rdo2.Size = new System.Drawing.Size(29, 16);
            this.rdo2.TabIndex = 30;
            this.rdo2.TabStop = true;
            this.rdo2.Text = "2";
            this.rdo2.UseVisualStyleBackColor = true;
            this.rdo2.CheckedChanged += new System.EventHandler(this.rdo2_CheckedChanged);
            // 
            // rdo1
            // 
            this.rdo1.AutoSize = true;
            this.rdo1.Enabled = false;
            this.rdo1.Location = new System.Drawing.Point(69, 77);
            this.rdo1.Name = "rdo1";
            this.rdo1.Size = new System.Drawing.Size(29, 16);
            this.rdo1.TabIndex = 29;
            this.rdo1.TabStop = true;
            this.rdo1.Text = "1";
            this.rdo1.UseVisualStyleBackColor = true;
            this.rdo1.CheckedChanged += new System.EventHandler(this.rdo1_CheckedChanged);
            // 
            // lblKLD
            // 
            this.lblKLD.Location = new System.Drawing.Point(7, 79);
            this.lblKLD.Name = "lblKLD";
            this.lblKLD.Size = new System.Drawing.Size(56, 21);
            this.lblKLD.TabIndex = 28;
            this.lblKLD.Text = "当前轨迹";
            // 
            // grpDH
            // 
            this.grpDH.Controls.Add(this.btnDownMap);
            this.grpDH.Controls.Add(this.btnLast);
            this.grpDH.Controls.Add(this.btnFirst);
            this.grpDH.Controls.Add(this.btnUpMap);
            this.grpDH.Controls.Add(this.btnNext100);
            this.grpDH.Controls.Add(this.btnPre100);
            this.grpDH.Controls.Add(this.btnNext);
            this.grpDH.Controls.Add(this.btnPre);
            this.grpDH.Location = new System.Drawing.Point(41, 184);
            this.grpDH.Name = "grpDH";
            this.grpDH.Size = new System.Drawing.Size(273, 100);
            this.grpDH.TabIndex = 35;
            this.grpDH.TabStop = false;
            // 
            // btnKCode
            // 
            this.btnKCode.Location = new System.Drawing.Point(218, 397);
            this.btnKCode.Name = "btnKCode";
            this.btnKCode.Size = new System.Drawing.Size(35, 30);
            this.btnKCode.TabIndex = 36;
            this.btnKCode.Text = "K码";
            this.btnKCode.UseVisualStyleBackColor = true;
            this.btnKCode.Click += new System.EventHandler(this.btnKCode_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(436, 435);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "路径图";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 420);
            this.label1.TabIndex = 15;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(436, 435);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "卫星图";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(305, 293);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 139);
            this.label2.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(152, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(250, 250);
            this.label3.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 429);
            this.label4.TabIndex = 16;
            // 
            // chkGGA
            // 
            this.chkGGA.AutoSize = true;
            this.chkGGA.Checked = true;
            this.chkGGA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGGA.Location = new System.Drawing.Point(170, 397);
            this.chkGGA.Name = "chkGGA";
            this.chkGGA.Size = new System.Drawing.Size(42, 16);
            this.chkGGA.TabIndex = 36;
            this.chkGGA.Text = "GGA";
            this.chkGGA.UseVisualStyleBackColor = true;
            // 
            // chkGSA
            // 
            this.chkGSA.AutoSize = true;
            this.chkGSA.Checked = true;
            this.chkGSA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGSA.Location = new System.Drawing.Point(170, 413);
            this.chkGSA.Name = "chkGSA";
            this.chkGSA.Size = new System.Drawing.Size(42, 16);
            this.chkGSA.TabIndex = 37;
            this.chkGSA.Text = "GSA";
            this.chkGSA.UseVisualStyleBackColor = true;
            // 
            // chkGoogleMap
            // 
            this.chkGoogleMap.AutoSize = true;
            this.chkGoogleMap.Location = new System.Drawing.Point(259, 405);
            this.chkGoogleMap.Name = "chkGoogleMap";
            this.chkGoogleMap.Size = new System.Drawing.Size(36, 16);
            this.chkGoogleMap.TabIndex = 38;
            this.chkGoogleMap.Text = "GM";
            this.chkGoogleMap.UseVisualStyleBackColor = true;
            // 
            // btnOld
            // 
            this.btnOld.Location = new System.Drawing.Point(314, 401);
            this.btnOld.Name = "btnOld";
            this.btnOld.Size = new System.Drawing.Size(53, 28);
            this.btnOld.TabIndex = 40;
            this.btnOld.Text = "旧软件";
            this.btnOld.UseVisualStyleBackColor = true;
            this.btnOld.Click += new System.EventHandler(this.btnOld_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(180, 442);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(70, 28);
            this.btnTest.TabIndex = 43;
            this.btnTest.Text = "检测CSV";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnJpg
            // 
            this.btnJpg.Location = new System.Drawing.Point(259, 442);
            this.btnJpg.Name = "btnJpg";
            this.btnJpg.Size = new System.Drawing.Size(47, 30);
            this.btnJpg.TabIndex = 44;
            this.btnJpg.Text = "图片";
            this.btnJpg.UseVisualStyleBackColor = true;
            this.btnJpg.Click += new System.EventHandler(this.btnJpg_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(170, 296);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(184, 87);
            this.txtMessage.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 524);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnJpg);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnOld);
            this.Controls.Add(this.chkGoogleMap);
            this.Controls.Add(this.btnKCode);
            this.Controls.Add(this.chkGSA);
            this.Controls.Add(this.chkGGA);
            this.Controls.Add(this.grpDH);
            this.Controls.Add(this.grpKLD);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtOut2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPS Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.grpKLD.ResumeLayout(false);
            this.grpKLD.PerformLayout();
            this.grpDH.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog dialogOpen;
        private System.Windows.Forms.Label txtOut2;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Label txtOut1;
        private System.Windows.Forms.Button btnPre100;
        private System.Windows.Forms.Button btnNext100;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label txtOut3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblOut5;
        private System.Windows.Forms.Button btnDownMap;
        private System.Windows.Forms.Button btnUpMap;
        private System.Windows.Forms.Label lblX1;
        private System.Windows.Forms.Label lblY1;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpKLD;
        private System.Windows.Forms.RadioButton rdo5;
        private System.Windows.Forms.RadioButton rdo4;
        private System.Windows.Forms.RadioButton rdo3;
        private System.Windows.Forms.RadioButton rdo2;
        private System.Windows.Forms.RadioButton rdo1;
        private System.Windows.Forms.Label lblKLD;
        private System.Windows.Forms.GroupBox grpDH;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Button btnKCode;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.WebBrowser webBrowserMap;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkGGA;
        private System.Windows.Forms.CheckBox chkGSA;
        private System.Windows.Forms.CheckBox chkGoogleMap;
        private System.Windows.Forms.Button btnOld;
        private System.Windows.Forms.OpenFileDialog dialogOpenNmea;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnJpg;
        private System.Windows.Forms.TextBox txtMessage;
    }
}

