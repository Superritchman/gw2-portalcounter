namespace PortalCounter
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbl_Time = new System.Windows.Forms.Label();
            this.ti_CountDown = new System.Windows.Forms.Timer(this.components);
            this.lbl_Distance = new System.Windows.Forms.Label();
            this.ti_Update = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_Time
            // 
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Time.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Time.ForeColor = System.Drawing.Color.White;
            this.lbl_Time.Location = new System.Drawing.Point(0, 0);
            this.lbl_Time.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_Time.Size = new System.Drawing.Size(47, 31);
            this.lbl_Time.TabIndex = 0;
            this.lbl_Time.Text = "60";
            this.lbl_Time.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.lbl_Time.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // ti_CountDown
            // 
            this.ti_CountDown.Interval = 1000;
            this.ti_CountDown.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_Distance
            // 
            this.lbl_Distance.AutoSize = true;
            this.lbl_Distance.Font = new System.Drawing.Font("Impact", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Distance.Location = new System.Drawing.Point(12, 24);
            this.lbl_Distance.MinimumSize = new System.Drawing.Size(30, 0);
            this.lbl_Distance.Name = "lbl_Distance";
            this.lbl_Distance.Size = new System.Drawing.Size(31, 15);
            this.lbl_Distance.TabIndex = 1;
            this.lbl_Distance.Text = "5000";
            this.lbl_Distance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_Distance.TextChanged += new System.EventHandler(this.lbl_Distance_TextChanged);
            this.lbl_Distance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.lbl_Distance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            // 
            // ti_Update
            // 
            this.ti_Update.Tick += new System.EventHandler(this.ti_Update_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(47, 48);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Distance);
            this.Controls.Add(this.lbl_Time);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(40, 40);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Portal Counter";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Timer ti_CountDown;
        private System.Windows.Forms.Label lbl_Distance;
        private System.Windows.Forms.Timer ti_Update;
    }
}

