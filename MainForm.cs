using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PortalCounter
{
    public partial class MainForm : Form
    {
        // Drag n Drop
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Some settings
        private const int S_LONGTIME = 60;
        private const int S_SHORTTIME = 10;

        // timer states
        private const int T_TIMER_STOPPED = 0;
        private const int T_SHORT_TIMER = 1;
        private const int T_LONG_TIMER = 2;

        private int timerstate = T_TIMER_STOPPED;
        private int tickTimer = S_LONGTIME;        

        public MainForm()
        {
            InitializeComponent();
        }

        public void startTimer()
        {
            switch (timerstate)
            {
                case T_TIMER_STOPPED:    // first portal
                    timerstate = T_LONG_TIMER;
                    this.ti_CountDown.Stop();
                    tickTimer = S_LONGTIME;
                    this.ti_CountDown.Start();
                    break;
                case T_LONG_TIMER:     // second portal (open to port)
                    timerstate = T_SHORT_TIMER;
                    this.ti_CountDown.Stop();
                    tickTimer = S_SHORTTIME;
                    this.ti_CountDown.Start();
                    break;
                default:    // reset
                    timerstate = T_TIMER_STOPPED;
                    this.ti_CountDown.Stop();
                    tickTimer = S_LONGTIME;
                    break;
            }
            updateLabel();
        }

        private void updateLabel()
        {
            //Color.White;  Default - 60s
            //Color.Red;    Default - 10s
            //Color.Blue;   Open    - 10s
            //Color.Purple; Open    - 5s

            // Short
            if (timerstate == T_SHORT_TIMER)
            {
                // normal
                if (tickTimer > 5)
                    this.lbl_Time.ForeColor = Color.Blue;
                else
                    this.lbl_Time.ForeColor = Color.Purple;              
            }
            else
            {
                // normal
                if (tickTimer > 10)
                    this.lbl_Time.ForeColor = Color.White;
                else
                    this.lbl_Time.ForeColor = Color.Red;

            }

            this.lbl_Time.Text = ""+tickTimer;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(--tickTimer < 0)
                startTimer();
            updateLabel();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                Settings formSettings = new Settings();
                formSettings.ShowDialog(this);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {                        
            if (e.Button == MouseButtons.Right)            
                Application.Exit();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            this.lbl_Time.BackColor = Color.LightGray;            
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            this.lbl_Time.BackColor = System.Drawing.SystemColors.Control;
            this.BringToFront();
        }
    }
}
