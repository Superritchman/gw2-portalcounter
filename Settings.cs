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
        private Keys newKey;

        public Settings()
        {
            InitializeComponent();
            this.lbl_DescOld.Text = "Old Key: " + PortalCounter.Properties.Settings.Default.HotKey;
        }

        private void Settings_KeyUp(object sender, KeyEventArgs e)
        {
            newKey = e.KeyCode;
            this.lbl_DescNew.Text = "New Key: " + e.KeyCode;
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!newKey.Equals(Keys.None))
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
