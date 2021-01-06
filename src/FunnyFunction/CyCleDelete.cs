using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    class CyCleDelete
    {
        public static void Run()
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= 17; i++)
                list.Add(i);

            int st = 0;
            while (list.Count>2)
            {
                st += 2;
                if (st >= list.Count)
                {
                    st = st - list.Count;
                }
                Console.WriteLine("Remove => " + list[st]);
                list.RemoveAt(st);
            }

            Console.WriteLine("Remain: " + string.Join(",", list));
        }
    }
}
