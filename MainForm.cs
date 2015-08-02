using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;
using Gw2Mem;

namespace PortalCounter
{
    public partial class MainForm : Form
    {
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        // Drag n Drop
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        // Some settings
        private const int S_LONGTIME = 60;

        // timer states
        private const int T_TIMER_STOPPED = 0;
        private const int T_SHORT_TIMER = 1;
        private const int T_LONG_TIMER = 2;
        private const int T_TIMER_EXPIRED = 3;

        private int timerstate = T_TIMER_STOPPED;
        private int tickTimer = S_LONGTIME;        

        // mumble
        private MumbleLink ml;
        private MumbleLink.Coordinate start_position;

        public MainForm()
        {
            InitializeComponent();            
        }

        public void startTimer()
        {
            switch (timerstate)
            {
                case T_TIMER_STOPPED:    // first portal
                    String winTitle = GetActiveWindowTitle();
                    if ("Guild Wars 2".Equals(winTitle))
                    {
                        timerstate = T_LONG_TIMER;
                        this.ti_CountDown.Stop();
                        tickTimer = S_LONGTIME;
                        this.ti_CountDown.Start();

                        try {
                            if (ml != null)
                                ml.Dispose();
                            ml = new MumbleLink();
                            start_position = ml.GetCoordinates();
                            ti_Update.Start();
                        }
                        catch (Exception ex)
                        {
                            ti_Update.Stop();
                            lbl_Distance.Text = "ERROR";
                            Console.WriteLine(ex);
                        }
                    }
                    break;
                case T_LONG_TIMER:     // second portal (open to port)
                    timerstate = T_SHORT_TIMER;
                    this.ti_CountDown.Stop();
                    tickTimer = PortalCounter.Properties.Settings.Default.InspIX ? 12 : 10;
                    this.ti_CountDown.Start();

                    lbl_Distance.Text = "5000";
                    ti_Update.Stop();
                    break;
                default:    // reset
                    timerstate = T_TIMER_STOPPED;
                    this.ti_CountDown.Stop();
                    tickTimer = S_LONGTIME;

                    lbl_Distance.Text = "5000";
                    ti_Update.Stop();
                    break;
            }
            updateLabel();
        }

        private void updateLabel()
        {
            // Short
            if (timerstate == T_SHORT_TIMER)
            {
                // normal
                if (tickTimer > 5)
                    this.lbl_Time.ForeColor = Color.LightBlue;
                else
                    this.lbl_Time.ForeColor = Color.MediumPurple;              
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

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(--tickTimer < 0)
            {
                if (timerstate == T_LONG_TIMER)
                    timerstate = T_TIMER_EXPIRED;
                startTimer();                
            }
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
                SettingsForm formSettings = new SettingsForm();
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
            this.BackColor = Color.LightGray;            
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.BringToFront();
        }

        private void ti_Update_Tick(object sender, EventArgs e)
        {            
            MumbleLink.Coordinate coord = ml.GetCoordinates();

            Console.WriteLine(start_position.x + " " + start_position.y + " " + start_position.z);

            lbl_Distance.Text = (5000 - (int)(distance(start_position, coord) + 1.5)).ToString();

            if (start_position.map_id != coord.map_id)
            {
                lbl_Distance.Text = "5000";
                ti_Update.Stop();
            }
        }

        private double distance(MumbleLink.Coordinate p, MumbleLink.Coordinate q)
        {
            double distance = 0;

            double sum = Math.Pow((q.x - p.x), 2) + Math.Pow((q.y - p.y), 2) + Math.Pow((q.z - p.z), 2);
            distance = Math.Sqrt(sum);

            return distance;
        }

        private void lbl_Distance_TextChanged(object sender, EventArgs e)
        {
            int valDis = Convert.ToInt32(this.lbl_Distance.Text);
            if (valDis < 0)
                lbl_Distance.ForeColor = Color.OrangeRed;
            else if (valDis < 500)
                lbl_Distance.ForeColor = Color.ForestGreen;
            else
                lbl_Distance.ForeColor = Color.White;
        }
    }
}
