using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using KeLi.RoseHeart.App.Properties;

namespace KeLi.RoseHeart.App
{
    public class RoseHelper
    {
        private static string[,] _data;

        private Dictionary<int, int[]> _randomData;

        private readonly Form _form;

        private Size _itemSize;

        private Point _startPoint;

        public RoseHelper(Form form)
        {
            _form = form;
            _startPoint = new Point(form.Location.X + 10, form.Location.Y + 10);
            _itemSize = new Size((form.Width - 20) / 35, (form.Height - 20) / 13);

            if (_data is null)
                InitLoveData();

            _randomData = CreateRadomLoveData();
        }

        public void CreateItem()
        {
            if (_randomData.Count == 0)
            {
                _form.Controls.Clear();
                _randomData = CreateRadomLoveData();
            }

            var index = _randomData.FirstOrDefault();
            var content = _data[index.Value[0], index.Value[1]];

            if (content == "@")
            {
                var pictureBox = new PictureBox
                {
                    Size = _itemSize,
                    Image = Resources.Rose,
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location = ComputeLocation(index.Value[0], index.Value[1])
                };

                _form.Controls.Add(pictureBox);
            }

            else
            {
                var lable = new Label
                {
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    ForeColor = ComputeColor(),
                    Font = new Font("STCaiyun", 36, FontStyle.Regular, GraphicsUnit.Point, 134),
                    Location = ComputeLocation(index.Value[0], index.Value[1]),
                    Text = content
                };

                _form.Controls.Add(lable);
            }

            _randomData.Remove(index.Key);
        }

        private Point ComputeLocation(int row, int column)
        {
            return new Point(_startPoint.X + column * _itemSize.Width, _startPoint.Y + row * _itemSize.Height);
        }

        private Color ComputeColor()
        {
            var dict = new Dictionary<int, Color>
            {
                { 0, Color.LightCoral },
                { 1, Color.DarkOrchid },
                { 2, Color.DarkGoldenrod },
                { 3, Color.DeepPink },
                { 4, Color.DarkRed },
                { 5, Color.Blue },
                { 6, Color.DarkOrange },
                { 7, Color.ForestGreen },
                { 8, Color.DeepSkyBlue },
                { 9, Color.Magenta }
            };

            var index = new Random(Guid.NewGuid().GetHashCode()).Next(0, 10);

            return dict[index];
        }

        private Dictionary<int, int[]> CreateRadomLoveData()
        {
            var rawDict = new Dictionary<int, int[]>();

            for (var i = 0; i < _data.GetLength(0); i++)
            {
                for (var j = 0; j < _data.GetLength(1); j++)
                {
                    if (_data[i, j] == null)
                        continue;

                    rawDict.Add(rawDict.Keys.Count, new[] { i, j });
                }
            }

            var randomDict = new Dictionary<int, int[]>();
            var keys = rawDict.Keys.ToList();

            for (var i = 0; i < rawDict.Keys.Count; i++)
            {
                var flag = false;

                while (!flag)
                {
                    var key = keys[new Random(Guid.NewGuid().GetHashCode()).Next(0, keys.Count)];

                    if (!randomDict.ContainsKey(key))
                    {
                        randomDict.Add(key, rawDict[key]);
                        flag = true;
                    }
                }
            }

            return randomDict;
        }

        private static void InitLoveData()
        {
            _data = new string[13, 35];

            _data[0, 5] = "@";
            _data[0, 7] = "@";
            _data[0, 9] = "@";
            _data[0, 25] = "@";
            _data[0, 27] = "@";
            _data[0, 29] = "@";

            _data[1, 3] = "@";
            _data[1, 11] = "@";
            _data[1, 23] = "@";
            _data[1, 31] = "@";

            _data[2, 1] = "@";
            _data[2, 13] = "@";
            _data[2, 21] = "@";
            _data[2, 33] = "@";

            _data[3, 0] = "@";
            _data[3, 15] = "@";
            _data[3, 19] = "@";
            _data[3, 34] = "@";

            _data[4, 0] = "@";
            _data[4, 17] = "@";
            _data[4, 34] = "@";

            _data[5, 1] = "@";
            _data[5, 33] = "@";

            _data[6, 3] = "@";
            _data[6, 10] = "I";
            _data[6, 14] = "L";
            _data[6, 16] = "O";
            _data[6, 18] = "V";
            _data[6, 20] = "E";
            _data[6, 24] = "U";
            _data[6, 31] = "@";

            _data[7, 5] = "@";
            _data[7, 29] = "@";

            _data[8, 7] = "@";
            _data[8, 27] = "@";

            _data[9, 9] = "@";
            _data[9, 25] = "@";

            _data[10, 11] = "@";
            _data[10, 23] = "@";

            _data[11, 14] = "@";
            _data[11, 20] = "@";

            _data[12, 16] = "@";
            _data[12, 18] = "@";
        }
    }
}