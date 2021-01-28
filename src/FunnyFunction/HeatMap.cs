using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FunnyFunction
{
    public class HeatMap
    {
        public static void DrawDefaultMap()
        {
            Bitmap map = new Bitmap(450, 400);

            Graphics g = Graphics.FromImage(map);
            g.DrawLine(new Pen(color: Color.White, 400), 0, 200, 450, 200);

            Font font = new Font("宋体", 10, FontStyle.Regular);
            Font bf = new Font("宋体", 12, FontStyle.Bold);
            Brush b = new SolidBrush(Color.Black);
            Pen p = new Pen(b, 1);
            // 绘制标题
            g.DrawString("HeatMap", new Font("宋体", 20, FontStyle.Bold), b, new PointF(20, 20));

            // 绘制坐标系
            g.DrawRectangle(p,50, 100, 255, 255);
            g.DrawString("X", bf,b, 305, 344);
            g.DrawString("Y", bf, b, 42, 83);

            for (int i = 0; i < 255; i += 50)
            {
                g.DrawLine(p, 46, i + 100, 50, i + 100);
                g.DrawString(i.ToString(), font, b, 23 + (i>99?0:(i==0?14:7)), i + 95);

                g.DrawLine(p, i + 50, 355, i + 50, 359);
                g.DrawString(i.ToString(), font, b, i + 43 - (i > 99 ? 7 : (i == 0 ? -3 : 0)), 360);
            }

            // 绘制热力表
            g.DrawRectangle(p, 359, 99, 21, 256);
            var cb = new LinearGradientBrush(new Rectangle(370,100, 20, 256), Color.Red, Color.Yellow, LinearGradientMode.Vertical);
            g.DrawLine(new Pen(cb,20), new PointF(370, 355), new PointF(370, 100));

            for (int i = 0; i < 255; i += 50)
            {
                g.DrawLine(p, 380, i + 105, 384, i + 105);
                g.DrawString((250-i).ToString(), font, b, 385, i + 98);
            }

            map.Save("E:\\heat.png");
        }

        public static void DrawPoints(List<PInfo> pList)
        {
            var image = Image.FromFile("E:\\heat.png");
            Bitmap bm = new Bitmap(image);
            var g = Graphics.FromImage(bm);

            foreach (var p in pList)
            {
                var x = (p.X + 128) * 255 / 510 + 50;
                var y = p.Y * 255 / 510 + 100;

                var color = bm.GetPixel(370, 100 + 255 - p.N);

                g.DrawRectangle(new Pen(color, 1), x, y, 1, 1);
            }
            bm.Save("E:\\heat2.png");
        }
    }

    public class PInfo
    {
        public int X;
        public int Y;
        public int N;
    }
}
