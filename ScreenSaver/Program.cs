using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ScreenSaver
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                {
                    secondArgument = args[1];
                }
                if (firstArgument == "/c")
                {
                    Application.Run(new SettingsForm());
                }
                else if (firstArgument == "/p")
                {
                    if(secondArgument==null)
                    {
                        MessageBox.Show("Sin vista previa","ScreenSaver",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }
                    IntPtr previewWndHandle=new IntPtr(long.Parse(secondArgument));
                    Application.Run(new ScreenSaverForm(previewWndHandle));
                }
                else if (firstArgument == "/s")
                {
                    ShowScreenSaver();
                    Application.Run();
                }
                else
                {
                    MessageBox.Show("Argumento invalido", "ScreenSaver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                Application.Run(new SettingsForm());
            }
        }
        static void ShowScreenSaver()
        {
            foreach(Screen screen in Screen.AllScreens)
            {
                ScreenSaverForm screensaver = new ScreenSaverForm(screen.Bounds);
                screensaver.Show();
            }
        }
    }
}
