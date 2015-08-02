using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace PortalCounter
{
    public partial class SettingsForm : Form
    {
        private Keys newKey;
        private Keys modifier;
        private SingleAssemblyComponentResourceManager resources = new SingleAssemblyComponentResourceManager(typeof(SettingsForm));
        private CultureInfo ci;

        public SettingsForm()
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
                case "es":
                    Properties.Settings.Default.Language = lang;
                    break;
                default:
                    Properties.Settings.Default.Language = "en";
                    break;
            }
            this.cb_Language.SelectedItem = Properties.Settings.Default.Language;

            this.cb_inspIX.Checked = Properties.Settings.Default.InspIX;
        }

        private String normalizeKeyValue(Keys key)
        {
            if (key.Equals(Keys.Menu))
                return "Alt";

            String normString = key.ToString();
            if (!String.IsNullOrEmpty(normString) && normString.Any(char.IsDigit))
            {
                normString = normString.TrimStart('D');
            }
            return normString;
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            newKey = e.KeyCode;

            String mod = "";
            if (e.Shift || e.Control || e.Alt)
            {

                if (!(e.KeyCode.Equals(Keys.ShiftKey) || e.KeyCode.Equals(Keys.ControlKey) || e.KeyCode.Equals(Keys.Menu)))
                {
                    modifier = Control.ModifierKeys;
                    if (e.Shift)
                        mod += "Shift + ";
                    if (e.Control)
                        mod += "Ctrl + ";
                    if (e.Alt)
                        mod += "Alt + ";
                }
            }

            this.lbl_DescNew.Text = resources.GetString("lbl_DescNew.Text", ci) + mod + normalizeKeyValue(newKey);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            if (!newKey.Equals(Keys.None))
                Properties.Settings.Default.HotKey = newKey;

            if (!modifier.Equals(Keys.None))
                Properties.Settings.Default.Modifier = modifier;

            Properties.Settings.Default.InspIX = this.cb_inspIX.Checked;
            this.Close();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.hook = true;
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            Program.hook = false;
        }

        private void cb_Language_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0)
            {
                int imgIndex = il_Flags.Images.IndexOfKey(cb_Language.Items[e.Index].ToString());
                e.Graphics.DrawImage(il_Flags.Images[imgIndex], e.Bounds.Left, e.Bounds.Top);
            }
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
            String mod = "";
            if (!Properties.Settings.Default.Modifier.Equals(Keys.None))
            {
                if ((Properties.Settings.Default.Modifier & Keys.Shift) > 0)
                    mod += "Shift + ";
                if ((Properties.Settings.Default.Modifier & Keys.Control) > 0)
                    mod += "Ctrl + ";
                if ((Properties.Settings.Default.Modifier & Keys.Alt) > 0)
                    mod += "Alt + ";
            }
            this.lbl_DescOld.Text += mod + normalizeKeyValue(oldKey);


            if (!newKey.Equals(Keys.None))
                this.lbl_DescNew.Text += normalizeKeyValue(newKey);
        }

        private void cb_Language_DropDownClosed(object sender, EventArgs e)
        {
            // prevent language-change on hotkey-changing
            this.lbl_DescOld.Focus();
        }
    }
}
