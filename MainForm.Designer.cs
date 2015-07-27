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
            this.lbl_Time.Size = new System.Drawing.Size(40, 30);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(40, 40);
            this.ControlBox = false;
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

        }

        #endregion

        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Timer ti_CountDown;
    }
}

