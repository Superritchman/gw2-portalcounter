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
            this.cb_inspIX = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_DescOld
            // 
            this.lbl_DescOld.AutoSize = true;
            this.lbl_DescOld.Location = new System.Drawing.Point(9, 9);
            this.lbl_DescOld.Name = "lbl_DescOld";
            this.lbl_DescOld.Size = new System.Drawing.Size(64, 18);
            this.lbl_DescOld.TabIndex = 0;
            this.lbl_DescOld.Text = "Old Key: ";
            // 
            // lbl_DescNew
            // 
            this.lbl_DescNew.AutoSize = true;
            this.lbl_DescNew.Location = new System.Drawing.Point(9, 36);
            this.lbl_DescNew.Name = "lbl_DescNew";
            this.lbl_DescNew.Size = new System.Drawing.Size(72, 18);
            this.lbl_DescNew.TabIndex = 1;
            this.lbl_DescNew.Text = "New Key: ";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Submit.Location = new System.Drawing.Point(0, 92);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(177, 35);
            this.btn_Submit.TabIndex = 2;
            this.btn_Submit.Text = "Ok";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // cb_inspIX
            // 
            this.cb_inspIX.AutoSize = true;
            this.cb_inspIX.Location = new System.Drawing.Point(27, 64);
            this.cb_inspIX.Name = "cb_inspIX";
            this.cb_inspIX.Size = new System.Drawing.Size(114, 22);
            this.cb_inspIX.TabIndex = 4;
            this.cb_inspIX.Text = "Inspiration IX";
            this.cb_inspIX.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AcceptButton = this.btn_Submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 127);
            this.Controls.Add(this.cb_inspIX);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_DescNew);
            this.Controls.Add(this.lbl_DescOld);
            this.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
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
        private System.Windows.Forms.CheckBox cb_inspIX;
    }
}