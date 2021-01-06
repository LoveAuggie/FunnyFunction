using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    public class HD1
    {
        /*81人排成一排，每次跳出2的N次方(N>=0)的人杀掉，最后剩余的排在多少*/
        public static void Run()
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= 81; i++)
            {
                list.Add(i);
            }

            while (list.Count > 1)
            {
                List<int> rList = new List<int>();
                int num = 0;
                while (true)
                {
                    var index = (int)Math.Pow(2, num++);
                    if (index <= list.Count)
                    {
                        rList.Add(index - 1);
                    }
                    else
                        break;
                }
                if (rList.Count > 0)
                {
                    for (int i = rList.Count - 1; i >= 0; i--)
                    {
                        list.RemoveAt(rList[i]);
                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Winner: " + list[0]);
        }
    }
}
