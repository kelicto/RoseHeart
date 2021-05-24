using System;
using System.Windows.Forms;

using KeLi.RoseHeart.App.Forms;

namespace KeLi.RoseHeart.App
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}