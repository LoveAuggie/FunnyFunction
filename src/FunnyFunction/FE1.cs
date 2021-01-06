using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    class FE1
    {
        /*  ABCDE * ? =EDCBA 计算这些值  */
        public static void Run()
        {
            for (int i = 10000; i <= 99999; i++)
            {
                for (int j = 2; j <= 9; j++)
                {
                    var re = i * j;
                    if (re > 99999)
                        continue;

                    var arr1 = i.ToString().ToArray();
                    var arr2 = re.ToString().ToArray();

                    bool find = true;
                    for (int k = 0; k < 5; k++)
                    {
                        if (arr1[k] != arr2[4 - k])
                        {
                            find = false;
                            break;
                        }
                    }
                    if (!find)
                        continue;
                    else
                    {
                        Console.WriteLine($"{i} * {j} = {re}");
                        break;
                    }
                }
            }
        }
    }
}
