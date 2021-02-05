using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            //HD1.Run();
            //FE1.Run();
            //BQBJ.Run();
            //XL.Run();
            //CyCleDelete.Run();
            //MyEvent.Test();
            int[] arr = new int[] { 5, 19, 23, 59, 18, 47, 92, 10, 57, 23 };
            Console.WriteLine("Be: " + string.Join(",", arr));
            //Sort.BubbleSort(arr);
            //arr= Sort.InsertSort(arr);
            //List<int> l = arr.ToList();
            //List<int> r = Sort.SelectSort(l);
            //arr = r.ToArray();
            //Sort.ShellSort(arr);
            //Sort.HeapSort(arr);
            arr= Sort.MergeSort(arr);
            Console.WriteLine("Af: " + string.Join(",", arr));


            Console.WriteLine("End");
            Console.ReadLine();
        }

        static void HeatMapTest()
        {
            //HeatMap.DrawDefaultMap();
            Random rand = new Random();
            List<PInfo> plist = new List<PInfo>();
            for (int i = 0; i < 50; i++)
            {
                plist.Add(new PInfo()
                {
                    X = rand.Next(-128, 128),
                    Y = rand.Next(0, 510),
                    N = rand.Next(0, 255)
                });
            }
            HeatMap.DrawPoints(plist);
        }
    }
}
