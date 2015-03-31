namespace PortalCounter
{
    partial class Settings
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
            this.lbl_DescOld = new System.Windows.Forms.Label();
            this.lbl_DescNew = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_DescOld
            // 
            this.lbl_DescOld.AutoSize = true;
            this.lbl_DescOld.Location = new System.Drawing.Point(12, 18);
            this.lbl_DescOld.Name = "lbl_DescOld";
            this.lbl_DescOld.Size = new System.Drawing.Size(66, 17);
            this.lbl_DescOld.TabIndex = 0;
            this.lbl_DescOld.Text = "Old Key: ";
            // 
            // lbl_DescNew
            // 
            this.lbl_DescNew.AutoSize = true;
            this.lbl_DescNew.Location = new System.Drawing.Point(12, 53);
            this.lbl_DescNew.Name = "lbl_DescNew";
            this.lbl_DescNew.Size = new System.Drawing.Size(71, 17);
            this.lbl_DescNew.TabIndex = 1;
            this.lbl_DescNew.Text = "New Key: ";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(50, 73);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(89, 31);
            this.btn_Submit.TabIndex = 2;
            this.btn_Submit.Text = "Ok";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.btn_Submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 107);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_DescNew);
            this.Controls.Add(this.lbl_DescOld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_DescOld;
        private System.Windows.Forms.Label lbl_DescNew;
        private System.Windows.Forms.Button btn_Submit;
    }
}