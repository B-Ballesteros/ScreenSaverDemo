using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ScreenSaver
{
    public partial class SettingsForm : Form
    {
        int col;
        private void SaveSettings()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\NumericToAcsii_ScreenSaver");
            key.SetValue("Color", colorDialog1.Color.ToArgb());
        }
        private void LoadSettings()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\NumericToAcsii_ScreenSaver");
            if (key == null)
                colorDialog1.Color = Color.Lime;
            else
               col = (Int32)key.GetValue("Color");
            colorDialog1.Color = Color.FromArgb(col);
        }
        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }
    }
}
