using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        Int32 col;
        int width;
        int height;
        int o;
        int wth = 0;
        int hgth = 0;
        int mul = 0;
        int max = 0;
        int cnt = 0;
        int color = 0;
        int color2 = 0;
        Random rnd = new Random(DateTime.Now.Millisecond);
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        public ScreenSaverForm(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }
        private bool previewMode = false;

        public ScreenSaverForm(IntPtr PreviewWndHandle)
        {
            InitializeComponent();
            SetParent(this.Handle, PreviewWndHandle);
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);
            richTextBox1.Font = new Font("Lucida Console", 6);
            previewMode = true;
        }
        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\NumericToAcsii_ScreenSaver");
            if (key == null)
                col=Color.Lime.ToArgb();
            else
                col = (int)key.GetValue("Color");
            richTextBox1.ForeColor = Color.FromArgb(col);
            width = Bounds.Width;
            height = Bounds.Height;
            wth = width - 50;
            hgth = height - 50;
            mul = wth * hgth;
            max = mul / (19 * 11);
            Cursor.Hide();
            TopMost = true;
            richTextBox1.Location = new Point(30, 30);
            richTextBox1.Size = new Size(wth, hgth);
            richTextBox1.MaxLength = max;
            timmer.Interval = 100;
            timmer.Tick += new EventHandler(timmer_Tick);
            timmer.Start();
            for (cnt = 0; cnt < max-117; cnt++)
            {
                o = rnd.Next(0, 2);
                richTextBox1.Text += o;
            }
        }
        private Point mouseLocation;
        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                if(!previewMode)
                    if (Math.Abs(mouseLocation.X - e.X) > 5 || Math.Abs(mouseLocation.Y - e.Y) > 5)
                    { Application.Exit(); }

            }
            mouseLocation = e.Location;
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void timmer_Tick(object sender, EventArgs e)
        {
                int u = rnd.Next(0, 2);
                int v = rnd.Next(0, 2);
                int w = rnd.Next(0, 2);
                int x = rnd.Next(0, 2);
                //char l = (char)u;
                //char m = (char)v;
                //char n = (char)w;
                //char o = (char)x;
                int g = rnd.Next(0, richTextBox1.Text.Length);
                int f = rnd.Next(0, richTextBox1.Text.Length);
                int h = rnd.Next(0, richTextBox1.Text.Length);
                int i = rnd.Next(0, richTextBox1.Text.Length);
                string a = u.ToString();
                string b = v.ToString();
                string c = w.ToString();
                string d = x.ToString();
                richTextBox1.SelectionStart = f;
                richTextBox1.SelectionLength = 1;
                if (color == 1)
                {
                    richTextBox1.SelectionColor = Color.WhiteSmoke;
                    color = 0;
                    color2 = 1;
                }
                else
                {
                    richTextBox1.SelectionColor = Color.FromArgb(col);
                    color = 1;
                    color2 = 0;
                }
                richTextBox1.SelectedText=a;
                richTextBox1.SelectionStart = g;
                richTextBox1.SelectionLength = 1;
                if (color2 == 1)
                {
                    richTextBox1.SelectionColor = Color.WhiteSmoke;
                }
                else
                {
                    richTextBox1.SelectionColor = Color.FromArgb(col);
                }
                richTextBox1.SelectedText = b;
                richTextBox1.SelectionStart = h;
                richTextBox1.SelectionLength = 1;
                if (color == 1)
                {
                    richTextBox1.SelectionColor = Color.WhiteSmoke;
                }
                else
                {
                    richTextBox1.SelectionColor = Color.FromArgb(col);
                }
                richTextBox1.SelectedText = c;
                richTextBox1.SelectionStart = i;
                richTextBox1.SelectionLength = 1;
                if (color2 == 1)
                {
                    richTextBox1.SelectionColor = Color.WhiteSmoke;
                }
                else
                {
                    richTextBox1.SelectionColor = Color.FromArgb(col);
                }
                richTextBox1.SelectedText = d;
        }

        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                if (!previewMode)
                    if (Math.Abs(mouseLocation.X - e.X) > 5 || Math.Abs(mouseLocation.Y - e.Y) > 5)
                    { Application.Exit(); }

            }
            mouseLocation = e.Location;
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }
    }
}
