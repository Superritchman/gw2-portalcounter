using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortalCounter
{
    public partial class Settings : Form
    {
        private char newKey;

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_KeyPress(object sender, KeyPressEventArgs e)
        {
            newKey = e.KeyChar;
            this.lbl_DescNew.Text = "New Key: " + Char.ToUpper(newKey);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            PortalCounter.Properties.Settings.Default.HotKey = newKey;
            this.Close();
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.hook = true;
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            Program.hook = false;
        }
    }
}
