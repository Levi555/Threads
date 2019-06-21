using System;
using System.IO;

namespace StreamDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader reader = new StreamReader("/Users/xiangxingxing/Downloads/xxx.txt");
            //string msg=reader.ReadToEnd();

            //Console.WriteLine(msg);
            for (int i = 1; i < 20; i++)
            {
                Console.Write(Recursive(i)+"  ");
            }
            Console.ReadKey();
        }

        static int Recursive(int n)
        {
            if (n < 3) return 1;
            return Recursive(n - 1) + Recursive(n - 2);
        }
    }
}
