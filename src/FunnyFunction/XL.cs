using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    public class XL
    {
        // 寻路算法
        /* 思路
         * 1：记录一个线的列表
         * 2：从起点开始，向上下左右，派生新的线，并且将新的线，记录新的列表
         * 3：对于到达同一个终点的线，去除掉已经消费较多的线
         * 4：一直到所有的线，都到达终点，并且保存下到终点费用最低的线
         */

        public static int[,] map;

        public static Line LastLine;

        public static void Run()
        {
            /*
            int[,] map = new int[3,3 ];
            map[0, 0] = 0;
            map[0, 1] = 1;
            map[0, 2] = 3;
            map[1, 0] = 1;
            map[1, 1] = 5;
            map[1, 2] = 1;
            map[2, 0] = 3;
            map[2, 1] = 4;
            map[2, 2] = 0;
            */
            List<Line> list = new List<Line>();

            list.Add(new Line()
            {
                pList = new List<Point>() { new Point() { X = 0, Y = 0, Fee = 0 } },
                CurrentPoint = new Point() { X = 0, Y = 0, Fee = 0 }
            }) ;
            // 记录到达每个点的最短Fee
            Dictionary<Point, Line> pDic = new Dictionary<Point, Line>();
            while (true)
            {
                var oldLines = list.ToArray();
                list.Clear();
                foreach (var ol in oldLines)
                {
                    list.AddRange(ol.Go(map));
                }
                // 先将到达同一个点的line给分类一下，剔除到耗费较大的线（相同的也只保留一个）
                var gp = list.GroupBy(t => t.CurrentPoint);
                list = gp.Select(t => t.OrderBy(l => l.CurrentFee).First()).ToList();
                // 然后和记录中的比较，剔除掉比之前的线耗费大的线
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    var line = list[i];
                    if (pDic.ContainsKey(line.CurrentPoint))
                    {
                        if (pDic[line.CurrentPoint].CurrentFee < line.CurrentFee)
                        {
                            if (list.Count > 1)
                            {
                                list.RemoveAt(i);
                            }
                            continue;
                        }
                    }
                    pDic[line.CurrentPoint] = line;
                }
                // 若只保留一个，就是到达终点的线
                if (list.Count <= 1)
                    break;
            }
            LastLine = list.First();
        }
    }

    public class Line
    {
        public List<Point> pList = new List<Point>();

        public int CurrentFee = 0;

        public Point PrePoint;

        public Point CurrentPoint;

        int[,] map;

        public List<Line> Go(int[,] _map)
        {
            map = _map;

            List<Line> list = new List<Line>();
            if (CurrentPoint.X == map.GetLength(0) - 1 && CurrentPoint.Y == map.GetLength(1) - 1)
            {
                // 已经到了终点，返回自己即可
                list.Add(this);
                return list;
            }

            var sp = new Point() { X = CurrentPoint.X, Y = CurrentPoint.Y - 1 };
            if (CanGo(sp))
            {
                list.Add(NewLine(sp));
            }
            var dp = new Point() { X = CurrentPoint.X, Y = CurrentPoint.Y + 1 };
            if (CanGo(dp))
            {
                list.Add(NewLine(dp));
            }
            var zp = new Point() { X = CurrentPoint.X - 1, Y = CurrentPoint.Y};
            if (CanGo(zp))
            {
                list.Add(NewLine(zp));
            }
            var yp = new Point() { X = CurrentPoint.X + 1, Y = CurrentPoint.Y};
            if (CanGo(yp))
            {
                list.Add(NewLine(yp));
            }
            return list;
        }

        private Line NewLine(Point np)
        {
            var line = new Line()
            {
                pList = this.pList.ToArray().ToList(),
                PrePoint = this.CurrentPoint,
                CurrentPoint = np,
                CurrentFee = this.CurrentFee + map[np.X, np.Y]
            };
            line.pList.Add(np);
            return line;
        }

        private bool CanGo(Point sp)
        {
            if ((sp.X < 0 || sp.X >= map.GetLength(0) || sp.Y >= map.GetLength(1) || sp.Y < 0)
                || pList.Contains(sp))
            {
                return false;
            }
            return true;
        }
    }

    public struct Point
    {
        public int X;

        public int Y;

        public int Fee;
    }
}
