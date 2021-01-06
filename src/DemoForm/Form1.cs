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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            /*
            string maps = 
              @"0,1,5,2,4,5,8,2,1
                1,5,2,4,5,8,2,9,5
                2,7,5,2,4,5,9,2,1
                2,1,3,2,9,0,8,7,3
                2,1,5,1,9,5,2,2,1
                4,8,4,3,4,2,8,2,3
                2,1,5,6,4,5,7,4,1
                2,8,7,2,4,5,8,2,1
                1,5,5,4,5,6,2,2,0";
            */
            string maps =
              @"0,1,1,1,1,1,8,2,1
                9,9,9,4,5,1,9,9,5
                2,7,5,2,4,1,9,2,1
                9,9,3,1,1,1,8,7,3
                9,1,1,1,9,9,9,2,1
                9,1,9,9,9,9,8,9,3
                2,1,1,1,4,1,1,1,1
                2,8,7,1,4,1,8,2,1
                1,5,5,1,1,1,2,2,0";

            var arr1 = maps.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var tr = arr1[0].Split(',');
            int[,] map= new int[tr.Length, arr1.Length];

            for (int j = 0; j < arr1.Length; j++)
            {
                var arr = arr1[j];
                tr = arr.Split(',');
                for (int i = 0; i < tr.Length; i++)
                {
                    map[i, j] = int.Parse(tr[i].Trim());
                }
            }

            XLForm frm = new XLForm(map);
            frm.ShowDialog();
        }

        private void btnXL2_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int[,] map = new int[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if ((i == 0 && j == 0) || (i == 19 && j == 19))
                    {
                        map[i, j] = 0;
                    }
                    else 
                    {
                        map[i, j] = rand.Next(1, 100) % 10;
                    }
                }
            }
            XLForm frm = new XLForm(map);
            frm.ShowDialog();
        }
    }
}
