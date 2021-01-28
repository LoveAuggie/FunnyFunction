using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyFunction
{
    public delegate void CallDelegate(string str);
    class MyEvent
    {
        public event CallDelegate call;

        public void DpCall(string str)
        {
            this.call?.Invoke(str);
        }

        public static void Test()
        {
            MyEvent me = new MyEvent();
            me.call += Me_call1;
            me.call += Me_call2;

            me.DpCall("sss");
        }

        private static void Me_call1(string str)
        {
            Console.WriteLine("call1:" + str);
        }
        private static void Me_call2(string str)
        {
            Console.WriteLine("call2:" + str);
        }
    }
}
