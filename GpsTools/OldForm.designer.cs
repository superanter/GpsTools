namespace GpsTools
{
    partial class OldForm
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
            this.btnResort = new System.Windows.Forms.Button();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtY1 = new System.Windows.Forms.TextBox();
            this.dialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblOut = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblTrackColor = new System.Windows.Forms.Label();
            this.txtTrackColor = new System.Windows.Forms.TextBox();
            this.lblTrackWidth = new System.Windows.Forms.Label();
            this.txtTrackWidth = new System.Windows.Forms.TextBox();
            this.lblPastPoint = new System.Windows.Forms.Label();
            this.txtPastPoint = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblColor2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt20 = new System.Windows.Forms.TextBox();
            this.txt10 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt22 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt21 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt12 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt11 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboAltitudeMode = new System.Windows.Forms.ComboBox();
            this.chkTessellate = new System.Windows.Forms.CheckBox();
            this.chkTimeStamp = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkWathTrack = new System.Windows.Forms.CheckBox();
            this.chkWathPoint = new System.Windows.Forms.CheckBox();
            this.chkGpsLog = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(390, 311);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(63, 25);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnResort
            // 
            this.btnResort.Location = new System.Drawing.Point(470, 312);
            this.btnResort.Name = "btnResort";
            this.btnResort.Size = new System.Drawing.Size(63, 25);
            this.btnResort.TabIndex = 2;
            this.btnResort.Text = "重置";
            this.btnResort.UseVisualStyleBackColor = true;
            this.btnResort.Click += new System.EventHandler(this.btnResort_Click);
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(47, 18);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(61, 21);
            this.txtX1.TabIndex = 3;
            // 
            // txtY1
            // 
            this.txtY1.Location = new System.Drawing.Point(47, 48);
            this.txtY1.Name = "txtY1";
            this.txtY1.Size = new System.Drawing.Size(61, 21);
            this.txtY1.TabIndex = 5;
            // 
            // lblOut
            // 
            this.lblOut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOut.Location = new System.Drawing.Point(438, 169);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(107, 136);
            this.lblOut.TabIndex = 6;
            // 
            // lblX
            // 
            this.lblX.Location = new System.Drawing.Point(9, 17);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(32, 21);
            this.lblX.TabIndex = 7;
            this.lblX.Text = "经度";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblY
            // 
            this.lblY.Location = new System.Drawing.Point(9, 48);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(32, 21);
            this.lblY.TabIndex = 8;
            this.lblY.Text = "纬度";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrackColor
            // 
            this.lblTrackColor.Location = new System.Drawing.Point(9, 21);
            this.lblTrackColor.Name = "lblTrackColor";
            this.lblTrackColor.Size = new System.Drawing.Size(53, 21);
            this.lblTrackColor.TabIndex = 10;
            this.lblTrackColor.Text = "轨迹颜色";
            this.lblTrackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrackColor
            // 
            this.txtTrackColor.Location = new System.Drawing.Point(69, 20);
            this.txtTrackColor.Name = "txtTrackColor";
            this.txtTrackColor.Size = new System.Drawing.Size(64, 21);
            this.txtTrackColor.TabIndex = 9;
            this.txtTrackColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // lblTrackWidth
            // 
            this.lblTrackWidth.Location = new System.Drawing.Point(9, 49);
            this.lblTrackWidth.Name = "lblTrackWidth";
            this.lblTrackWidth.Size = new System.Drawing.Size(53, 21);
            this.lblTrackWidth.TabIndex = 12;
            this.lblTrackWidth.Text = "轨迹宽度";
            this.lblTrackWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTrackWidth
            // 
            this.txtTrackWidth.Location = new System.Drawing.Point(69, 49);
            this.txtTrackWidth.Name = "txtTrackWidth";
            this.txtTrackWidth.Size = new System.Drawing.Size(27, 21);
            this.txtTrackWidth.TabIndex = 11;
            // 
            // lblPastPoint
            // 
            this.lblPastPoint.Location = new System.Drawing.Point(120, 17);
            this.lblPastPoint.Name = "lblPastPoint";
            this.lblPastPoint.Size = new System.Drawing.Size(107, 22);
            this.lblPastPoint.TabIndex = 14;
            this.lblPastPoint.Text = "航点产生比率1/x";
            this.lblPastPoint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPastPoint
            // 
            this.txtPastPoint.Location = new System.Drawing.Point(228, 17);
            this.txtPastPoint.Name = "txtPastPoint";
            this.txtPastPoint.Size = new System.Drawing.Size(22, 21);
            this.txtPastPoint.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblX);
            this.groupBox1.Controls.Add(this.txtX1);
            this.groupBox1.Controls.Add(this.lblY);
            this.groupBox1.Controls.Add(this.txtY1);
            this.groupBox1.Location = new System.Drawing.Point(12, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 79);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "经纬偏移(\')";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblColor2);
            this.groupBox2.Controls.Add(this.lblTrackWidth);
            this.groupBox2.Controls.Add(this.lblTrackColor);
            this.groupBox2.Controls.Add(this.txtTrackWidth);
            this.groupBox2.Controls.Add(this.txtTrackColor);
            this.groupBox2.Location = new System.Drawing.Point(12, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(147, 79);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轨迹属性";
            // 
            // lblColor2
            // 
            this.lblColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColor2.Location = new System.Drawing.Point(102, 49);
            this.lblColor2.Name = "lblColor2";
            this.lblColor2.Size = new System.Drawing.Size(31, 21);
            this.lblColor2.TabIndex = 13;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt20);
            this.groupBox3.Controls.Add(this.txt10);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txt22);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt21);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txt12);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txt11);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(550, 151);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "航标点属性";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 15);
            this.label13.TabIndex = 28;
            this.label13.Text = "中间点";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 15);
            this.label12.TabIndex = 27;
            this.label12.Text = "起终点";
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(447, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 21);
            this.label11.TabIndex = 26;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(377, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 21);
            this.textBox2.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(447, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 21);
            this.label7.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(314, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "字体颜色";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(377, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(64, 21);
            this.textBox1.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(314, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "字体颜色";
            // 
            // txt20
            // 
            this.txt20.Location = new System.Drawing.Point(119, 86);
            this.txt20.Name = "txt20";
            this.txt20.Size = new System.Drawing.Size(420, 21);
            this.txt20.TabIndex = 22;
            // 
            // txt10
            // 
            this.txt10.Location = new System.Drawing.Point(119, 13);
            this.txt10.Name = "txt10";
            this.txt10.Size = new System.Drawing.Size(420, 21);
            this.txt10.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(184, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "字体缩放";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt22
            // 
            this.txt22.Location = new System.Drawing.Point(249, 113);
            this.txt22.Name = "txt22";
            this.txt22.Size = new System.Drawing.Size(45, 21);
            this.txt22.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(57, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 18;
            this.label3.Text = "图标缩放";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(57, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "航标图标";
            // 
            // txt21
            // 
            this.txt21.Location = new System.Drawing.Point(119, 113);
            this.txt21.Name = "txt21";
            this.txt21.Size = new System.Drawing.Size(45, 21);
            this.txt21.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(57, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "航标图标";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(184, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 16;
            this.label2.Text = "字体缩放";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt12
            // 
            this.txt12.Location = new System.Drawing.Point(249, 40);
            this.txt12.Name = "txt12";
            this.txt12.Size = new System.Drawing.Size(45, 21);
            this.txt12.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(57, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "图标缩放";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt11
            // 
            this.txt11.Location = new System.Drawing.Point(119, 40);
            this.txt11.Name = "txt11";
            this.txt11.Size = new System.Drawing.Size(45, 21);
            this.txt11.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTime);
            this.groupBox4.Controls.Add(this.lblTime);
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cboAltitudeMode);
            this.groupBox4.Controls.Add(this.chkTessellate);
            this.groupBox4.Controls.Add(this.chkTimeStamp);
            this.groupBox4.Controls.Add(this.lblPastPoint);
            this.groupBox4.Controls.Add(this.txtPastPoint);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.chkWathTrack);
            this.groupBox4.Controls.Add(this.chkWathPoint);
            this.groupBox4.Location = new System.Drawing.Point(165, 169);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 136);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "其他设置";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(220, 63);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(30, 21);
            this.txtTime.TabIndex = 23;
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(125, 66);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(78, 15);
            this.lblTime.TabIndex = 13;
            this.lblTime.Text = "时区(GMT+/-)";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 109);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(108, 16);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "画延伸线至地面";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(125, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "高度模式";
            // 
            // cboAltitudeMode
            // 
            this.cboAltitudeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAltitudeMode.FormattingEnabled = true;
            this.cboAltitudeMode.Items.AddRange(new object[] {
            "贴地",
            "相对",
            "绝对"});
            this.cboAltitudeMode.Location = new System.Drawing.Point(189, 39);
            this.cboAltitudeMode.Name = "cboAltitudeMode";
            this.cboAltitudeMode.Size = new System.Drawing.Size(61, 20);
            this.cboAltitudeMode.TabIndex = 10;
            // 
            // chkTessellate
            // 
            this.chkTessellate.AutoSize = true;
            this.chkTessellate.Location = new System.Drawing.Point(6, 87);
            this.chkTessellate.Name = "chkTessellate";
            this.chkTessellate.Size = new System.Drawing.Size(144, 16);
            this.chkTessellate.TabIndex = 9;
            this.chkTessellate.Text = "根据地形自动调整线条";
            this.chkTessellate.UseVisualStyleBackColor = true;
            // 
            // chkTimeStamp
            // 
            this.chkTimeStamp.AutoSize = true;
            this.chkTimeStamp.Checked = true;
            this.chkTimeStamp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTimeStamp.Location = new System.Drawing.Point(6, 65);
            this.chkTimeStamp.Name = "chkTimeStamp";
            this.chkTimeStamp.Size = new System.Drawing.Size(84, 16);
            this.chkTimeStamp.TabIndex = 8;
            this.chkTimeStamp.Text = "启用时间轴";
            this.chkTimeStamp.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(151, 87);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "时间平滑方式";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chkWathTrack
            // 
            this.chkWathTrack.AutoSize = true;
            this.chkWathTrack.Checked = true;
            this.chkWathTrack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWathTrack.Location = new System.Drawing.Point(6, 43);
            this.chkWathTrack.Name = "chkWathTrack";
            this.chkWathTrack.Size = new System.Drawing.Size(108, 16);
            this.chkWathTrack.TabIndex = 2;
            this.chkWathTrack.Text = "包含轨迹(航迹)";
            this.chkWathTrack.UseVisualStyleBackColor = true;
            // 
            // chkWathPoint
            // 
            this.chkWathPoint.AutoSize = true;
            this.chkWathPoint.Checked = true;
            this.chkWathPoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWathPoint.Location = new System.Drawing.Point(6, 20);
            this.chkWathPoint.Name = "chkWathPoint";
            this.chkWathPoint.Size = new System.Drawing.Size(108, 16);
            this.chkWathPoint.TabIndex = 1;
            this.chkWathPoint.Text = "包含地标(航点)";
            this.chkWathPoint.UseVisualStyleBackColor = true;
            // 
            // chkGpsLog
            // 
            this.chkGpsLog.AutoSize = true;
            this.chkGpsLog.Location = new System.Drawing.Point(190, 322);
            this.chkGpsLog.Name = "chkGpsLog";
            this.chkGpsLog.Size = new System.Drawing.Size(114, 16);
            this.chkGpsLog.TabIndex = 19;
            this.chkGpsLog.Text = "标准GPS log文件";
            this.chkGpsLog.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 349);
            this.Controls.Add(this.chkGpsLog);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblOut);
            this.Controls.Add(this.btnResort);
            this.Controls.Add(this.btnOpen);
            this.Name = "OldForm";
            this.Text = "-> Google KML";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnResort;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtY1;
        private System.Windows.Forms.OpenFileDialog dialogOpen;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblTrackColor;
        private System.Windows.Forms.TextBox txtTrackColor;
        private System.Windows.Forms.Label lblTrackWidth;
        private System.Windows.Forms.TextBox txtTrackWidth;
        private System.Windows.Forms.Label lblPastPoint;
        private System.Windows.Forms.TextBox txtPastPoint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblColor2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt22;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkWathTrack;
        private System.Windows.Forms.CheckBox chkWathPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkTimeStamp;
        private System.Windows.Forms.TextBox txt20;
        private System.Windows.Forms.TextBox txt10;
        private System.Windows.Forms.CheckBox chkTessellate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboAltitudeMode;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkGpsLog;

    }
}

