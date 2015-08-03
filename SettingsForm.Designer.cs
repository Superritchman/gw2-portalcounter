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
            SingleAssemblyComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(SettingsForm));
            this.lbl_DescOld = new System.Windows.Forms.Label();
            this.lbl_DescNew = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.cb_inspIX = new System.Windows.Forms.CheckBox();
            this.cb_Language = new System.Windows.Forms.ComboBox();
            this.il_Flags = new System.Windows.Forms.ImageList(this.components);
            this.cb_ProtectChat = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_DescOld
            // 
            resources.ApplyResources(this.lbl_DescOld, "lbl_DescOld");
            this.lbl_DescOld.Name = "lbl_DescOld";
            // 
            // lbl_DescNew
            // 
            resources.ApplyResources(this.lbl_DescNew, "lbl_DescNew");
            this.lbl_DescNew.Name = "lbl_DescNew";
            // 
            // btn_Submit
            // 
            resources.ApplyResources(this.btn_Submit, "btn_Submit");
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.TabStop = false;
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // cb_inspIX
            // 
            resources.ApplyResources(this.cb_inspIX, "cb_inspIX");
            this.cb_inspIX.Name = "cb_inspIX";
            this.cb_inspIX.TabStop = false;
            this.cb_inspIX.UseVisualStyleBackColor = true;
            // 
            // cb_Language
            // 
            resources.ApplyResources(this.cb_Language, "cb_Language");
            this.cb_Language.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Language.DropDownWidth = 20;
            this.cb_Language.FormattingEnabled = true;
            this.cb_Language.Items.AddRange(new object[] {
            resources.GetString("cb_Language.Items"),
            resources.GetString("cb_Language.Items1"),
            resources.GetString("cb_Language.Items2"),
            resources.GetString("cb_Language.Items3")});
            this.cb_Language.Name = "cb_Language";
            this.cb_Language.TabStop = false;
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
            // cb_ProtectChat
            // 
            resources.ApplyResources(this.cb_ProtectChat, "cb_ProtectChat");
            this.cb_ProtectChat.Name = "cb_ProtectChat";
            this.cb_ProtectChat.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.cb_ProtectChat);
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
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
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
        private System.Windows.Forms.CheckBox cb_ProtectChat;
    }
}