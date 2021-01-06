using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FunnyFunction;

namespace DemoForm
{
    public partial class XLForm : Form
    {
        private int[,] Map;
        private int width;
        private int height;
        private Button[,] buttons;
        public XLForm(int[,] map)
        {
            Map = map;
            InitializeComponent();

            width = map.GetLength(0);
            height = map.GetLength(1);

            this.Width = width * 25 + 100;
            this.Height = height * 25 + 80;
            InitMap();
        }

        private void InitMap()
        {
           buttons = new Button[width,height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Button button = new Button();
                    button.Text = Map[i, j].ToString();
                    if (i == 0 && j == 0)
                    {
                        button.Text = "S";
                    }
                    if (i == width - 1 && j == height - 1)
                    {
                        button.Text = "E";
                    }
                    button.Location = new System.Drawing.Point(5 + i * 25, 5 + j * 25);
                    button.Size = new Size(24, 24);
                    buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            XL.map = Map;
            XL.Run();

            var line = XL.LastLine;
            lblResult.Text = $"到达终点，步数：{line.pList.Count}, 耗费：{line.CurrentFee}";
            foreach (var p in line.pList)
            {
                buttons[p.X, p.Y].BackColor = Color.Green;
            }
        }
    }
}
