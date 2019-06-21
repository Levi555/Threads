using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClient webClient = new WebClient();
            //var result=webClient.DownloadString("http://www.daochuzhao.com/sample-page");
            //Console.WriteLine(result);
            Task task = new Task(Dosth);
            task.ContinueWith(task2 => {
                task2 = new Task(Dosth2);
                task2.Start();
                });
            task.Start();
            Console.WriteLine("main");
            Console.ReadKey();
        }
         static void Dosth2()
        {
            Console.WriteLine("1执行完成后开始");
        }
        static void Dosth()
        {
            Thread.Sleep(1000);
            Console.WriteLine("this is a task");
        }
    }
}
