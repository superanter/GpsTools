namespace GpsTools
{
    partial class KCodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtKCode = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.lblKCode = new System.Windows.Forms.Label();
            this.lblJing = new System.Windows.Forms.Label();
            this.lblWei = new System.Windows.Forms.Label();
            this.btnK2NS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKCode
            // 
            this.txtKCode.Location = new System.Drawing.Point(75, 33);
            this.txtKCode.Name = "txtKCode";
            this.txtKCode.Size = new System.Drawing.Size(73, 21);
            this.txtKCode.TabIndex = 0;
            this.txtKCode.Text = "84kca8ztx";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(62, 86);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(86, 21);
            this.txtY.TabIndex = 1;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(62, 57);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(86, 21);
            this.txtX.TabIndex = 2;
            // 
            // lblKCode
            // 
            this.lblKCode.Location = new System.Drawing.Point(12, 33);
            this.lblKCode.Name = "lblKCode";
            this.lblKCode.Size = new System.Drawing.Size(43, 21);
            this.lblKCode.TabIndex = 3;
            this.lblKCode.Text = "K码";
            this.lblKCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJing
            // 
            this.lblJing.Location = new System.Drawing.Point(11, 57);
            this.lblJing.Name = "lblJing";
            this.lblJing.Size = new System.Drawing.Size(43, 21);
            this.lblJing.TabIndex = 4;
            this.lblJing.Text = "经度";
            this.lblJing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWei
            // 
            this.lblWei.Location = new System.Drawing.Point(12, 86);
            this.lblWei.Name = "lblWei";
            this.lblWei.Size = new System.Drawing.Size(43, 21);
            this.lblWei.TabIndex = 5;
            this.lblWei.Text = "纬度";
            this.lblWei.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnK2NS
            // 
            this.btnK2NS.Location = new System.Drawing.Point(14, 135);
            this.btnK2NS.Name = "btnK2NS";
            this.btnK2NS.Size = new System.Drawing.Size(51, 23);
            this.btnK2NS.TabIndex = 6;
            this.btnK2NS.Text = "K2NS";
            this.btnK2NS.UseVisualStyleBackColor = true;
            this.btnK2NS.Click += new System.EventHandler(this.btnK2NS_Click);
            // 
            // KCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 170);
            this.Controls.Add(this.btnK2NS);
            this.Controls.Add(this.lblWei);
            this.Controls.Add(this.lblJing);
            this.Controls.Add(this.lblKCode);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtKCode);
            this.Name = "KCodeForm";
            this.Text = "KCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKCode;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label lblKCode;
        private System.Windows.Forms.Label lblJing;
        private System.Windows.Forms.Label lblWei;
        private System.Windows.Forms.Button btnK2NS;
    }
}