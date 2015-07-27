namespace PortalCounter
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lbl_DescOld = new System.Windows.Forms.Label();
            this.lbl_DescNew = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.cb_inspIX = new System.Windows.Forms.CheckBox();
            this.cb_Language = new System.Windows.Forms.ComboBox();
            this.il_Flags = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // lbl_DescOld
            // 
            this.lbl_DescOld.AutoSize = true;
            this.lbl_DescOld.Location = new System.Drawing.Point(9, 9);
            this.lbl_DescOld.Name = "lbl_DescOld";
            this.lbl_DescOld.Size = new System.Drawing.Size(50, 13);
            this.lbl_DescOld.TabIndex = 0;
            this.lbl_DescOld.Text = "Old Key: ";
            // 
            // lbl_DescNew
            // 
            this.lbl_DescNew.AutoSize = true;
            this.lbl_DescNew.Location = new System.Drawing.Point(9, 36);
            this.lbl_DescNew.Name = "lbl_DescNew";
            this.lbl_DescNew.Size = new System.Drawing.Size(56, 13);
            this.lbl_DescNew.TabIndex = 1;
            this.lbl_DescNew.Text = "New Key: ";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_Submit.Location = new System.Drawing.Point(0, 90);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(228, 35);
            this.btn_Submit.TabIndex = 2;
            this.btn_Submit.TabStop = false;
            this.btn_Submit.Text = "Ok";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // cb_inspIX
            // 
            this.cb_inspIX.AutoSize = true;
            this.cb_inspIX.Location = new System.Drawing.Point(12, 67);
            this.cb_inspIX.Name = "cb_inspIX";
            this.cb_inspIX.Size = new System.Drawing.Size(179, 17);
            this.cb_inspIX.TabIndex = 4;
            this.cb_inspIX.TabStop = false;
            this.cb_inspIX.Text = "Temporal Enchanter (Inspiration)";
            this.cb_inspIX.UseVisualStyleBackColor = true;
            // 
            // cb_Language
            // 
            this.cb_Language.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Language.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Language.DropDownWidth = 20;
            this.cb_Language.Enabled = false;
            this.cb_Language.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Language.FormattingEnabled = true;
            this.cb_Language.Items.AddRange(new object[] {
            "en",
            "de",
            "es",
            "fr"});
            this.cb_Language.Location = new System.Drawing.Point(174, 12);
            this.cb_Language.Name = "cb_Language";
            this.cb_Language.Size = new System.Drawing.Size(42, 21);
            this.cb_Language.TabIndex = 4;
            this.cb_Language.Visible = false;
            this.cb_Language.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cb_Language_DrawItem);
            this.cb_Language.SelectedIndexChanged += new System.EventHandler(this.cb_Language_SelectedIndexChanged);
            this.cb_Language.DropDownClosed += new System.EventHandler(this.cb_Language_DropDownClosed);
            // 
            // il_Flags
            // 
            this.il_Flags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il_Flags.ImageStream")));
            this.il_Flags.TransparentColor = System.Drawing.Color.Transparent;
            this.il_Flags.Images.SetKeyName(0, "en");
            this.il_Flags.Images.SetKeyName(1, "de");
            this.il_Flags.Images.SetKeyName(2, "es");
            this.il_Flags.Images.SetKeyName(3, "fr");
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(228, 125);
            this.Controls.Add(this.cb_Language);
            this.Controls.Add(this.cb_inspIX);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lbl_DescNew);
            this.Controls.Add(this.lbl_DescOld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_DescOld;
        private System.Windows.Forms.Label lbl_DescNew;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.CheckBox cb_inspIX;
        private System.Windows.Forms.ComboBox cb_Language;
        private System.Windows.Forms.ImageList il_Flags;
    }
}