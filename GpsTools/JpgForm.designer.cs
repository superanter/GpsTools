namespace GpsTools
{
    partial class JpgForm
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
            this.btnJpgOpen = new System.Windows.Forms.Button();
            this.lblJpgMes = new System.Windows.Forms.Label();
            this.OpenJpg = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnJpgOpen
            // 
            this.btnJpgOpen.Location = new System.Drawing.Point(76, 212);
            this.btnJpgOpen.Name = "btnJpgOpen";
            this.btnJpgOpen.Size = new System.Drawing.Size(113, 32);
            this.btnJpgOpen.TabIndex = 0;
            this.btnJpgOpen.Text = "打开图片";
            this.btnJpgOpen.UseVisualStyleBackColor = true;
            this.btnJpgOpen.Click += new System.EventHandler(this.btnJpgOpen_Click);
            // 
            // lblJpgMes
            // 
            this.lblJpgMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJpgMes.Location = new System.Drawing.Point(25, 19);
            this.lblJpgMes.Name = "lblJpgMes";
            this.lblJpgMes.Size = new System.Drawing.Size(219, 172);
            this.lblJpgMes.TabIndex = 1;
            // 
            // JpgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 266);
            this.Controls.Add(this.lblJpgMes);
            this.Controls.Add(this.btnJpgOpen);
            this.Name = "JpgForm";
            this.Text = "JpgForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnJpgOpen;
        private System.Windows.Forms.Label lblJpgMes;
        private System.Windows.Forms.OpenFileDialog OpenJpg;
    }
}