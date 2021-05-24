using System;
using System.Runtime.InteropServices;

namespace KeLi.RoseHeart.App.Utils
{
    public class User32Importer
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public const int MOUSEWHEEL = 0x020A;

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern bool ReleaseCapture();

    }
}