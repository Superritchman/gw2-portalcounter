using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace PortalCounter
{
    public partial class Settings : Form
    {
        private Keys newKey;
        private ComponentResourceManager resources = new ComponentResourceManager(typeof(Settings));
        private CultureInfo ci;

        public Settings()
        {
            InitializeComponent();

            // set language
            string lang = Properties.Settings.Default.Language;
            if (String.IsNullOrEmpty(lang))
                lang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName;
            
            switch (lang)
            {
                case "de":
                case "fr":
                case "es": Properties.Settings.Default.Language = lang;
                    break;
                default: Properties.Settings.Default.Language = "en";
                    break;
            }
            this.cb_Language.SelectedItem = Properties.Settings.Default.Language;
        }

        private void Settings_KeyUp(object sender, KeyEventArgs e)
        {
            newKey = e.KeyCode;
            this.lbl_DescNew.Text = resources.GetString("lbl_DescNew.Text", ci) + normalizeKeyValue(newKey);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!newKey.Equals(Keys.None))
                Properties.Settings.Default.HotKey = newKey;
            Properties.Settings.Default.InspIX = this.cb_inspIX.Checked;
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

        private void cb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            string langcode = this.cb_Language.SelectedItem.ToString();
            Properties.Settings.Default.Language = langcode;
            ci = new CultureInfo(langcode);
            // translate Components            
            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name, ci);
            }
            // translate this form
            resources.ApplyResources(this, "$this", ci);

            // recreate oldKey value
            Keys oldKey = Properties.Settings.Default.HotKey;
            this.lbl_DescOld.Text += normalizeKeyValue(oldKey);
            if (!newKey.Equals(Keys.None))
                this.lbl_DescNew.Text += normalizeKeyValue(newKey);
        }

        private void cb_Language_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0)
            {
                int index = il_Flags.Images.IndexOfKey(cb_Language.Items[e.Index].ToString());
                this.il_Flags.Draw(e.Graphics, e.Bounds.Left, e.Bounds.Top, index);
            }
        }

        private void cb_Language_DropDownClosed(object sender, EventArgs e)
        {
            // remove focus to prevent toggling language on setting hotkey
            this.lbl_DescNew.Focus();
        }
    }
}
