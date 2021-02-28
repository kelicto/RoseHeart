using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace KeLi.RoseHeart.App
{
    public partial class MainForm : Form
    {
        private bool _flag = true;

        private readonly RoseHelper _helper;

        public MainForm()
        {
            MusicUtil.PlayMusic("Resources/The_Ruins_of_Love.mp3");

            InitializeComponent();

            _helper = new RoseHelper(this);
        }

        public sealed override Color BackColor
        {
            get => base.BackColor;

            set => base.BackColor = value;
        }

        private void TmrTime_Tick(object sender, EventArgs e)
        {
            if (_flag)
            {
                Thread.Sleep(3000);
                _flag = false;
            }

            tmrTime.Interval = new Random().Next(100, 300);
            _helper.CreateItem();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WinApi.ReleaseCapture();
                WinApi.SendMessage(Handle, WinApi.WM_NCLBUTTONDOWN, WinApi.HT_CAPTION, 0);
            }
        }
    }
}