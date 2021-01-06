﻿using System;
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
    }
}
