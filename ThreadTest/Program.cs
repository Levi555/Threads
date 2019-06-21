using System;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Action a =  WasteTime;
            a.BeginInvoke(ar =>
            {
                Console.WriteLine("  Done!!!");
            }, null);
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        static void WasteTime()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
        }
    }
}
