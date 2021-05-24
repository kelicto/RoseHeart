using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using KeLi.RoseHeart.App.Utils;

namespace KeLi.RoseHeart.App.Forms
{
    public partial class MainForm : Form
    {
        private bool _flag = true;

        private readonly RoseHelper _helper;

        public MainForm()
        {
            InitializeComponent();

            MusicUtil.PlayMusic("Resources/Music.mp3");
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
                User32Importer.ReleaseCapture();
                User32Importer.SendMessage(Handle, User32Importer.WM_NCLBUTTONDOWN, User32Importer.HT_CAPTION, 0);
            }
        }
    }
}