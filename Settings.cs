using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PortalCounter
{
    public partial class Settings : Form
    {
        private Keys newKey;

        public Settings()
        {
            InitializeComponent();
            Keys oldKey = PortalCounter.Properties.Settings.Default.HotKey;
            this.lbl_DescOld.Text = "Old Key: " + normalizeKeyValue(oldKey);
        }

        private void Settings_KeyUp(object sender, KeyEventArgs e)
        {
            newKey = e.KeyCode;
            this.lbl_DescNew.Text = "New Key: " + normalizeKeyValue(newKey);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!newKey.Equals(Keys.None))
                PortalCounter.Properties.Settings.Default.HotKey = newKey;
            PortalCounter.Properties.Settings.Default.InspIX = this.cb_inspIX.Checked;
            this.Close();
        }

        private String normalizeKeyValue(Keys key)
        {
            String normString = key.ToString();
            if (!String.IsNullOrEmpty(normString) && normString.Any(char.IsDigit))
            {                
                normString = normString.TrimStart('D');
            }

            return normString;
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
