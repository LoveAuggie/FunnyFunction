using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    public class BQBJ
    {
        /*百钱百鸡  公鸡：5钱  母鸡：3钱  小鸡 1钱3只*/
        public static void Run()
        {
            for (int i = 0; i <= 20; i++)
            {
                for (int j = 0; j <= 30; j++)
                {
                    var z = 100 - i - j;

                    if ((z % 3 == 0)
                        && (5 * i + 3 * j + z / 3 == 100))
                    {
                        Console.WriteLine($"公鸡：{i}, 母鸡：{j}，小鸡：{z}");   
                    }
                }
            }
        }
    }
}
