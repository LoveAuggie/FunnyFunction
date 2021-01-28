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
                }) ;
            }
            HeatMap.DrawPoints(plist);
            //MyEvent.Test();

            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
