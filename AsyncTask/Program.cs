using System;
using System.Net;

namespace AsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            var result=webClient.DownloadString("http://www.daochuzhao.com/sample-page");
            Console.WriteLine(result);
        }
    }
}
