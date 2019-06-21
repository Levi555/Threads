using System;
namespace AsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //WebClient webClient = new WebClient();
            //var result=webClient.DownloadString("http://www.daochuzhao.com/sample-page");
            //Console.WriteLine(result);
            Rectangle rectangle = new Rectangle(10.4f, 12.4f);
            rectangle.Deconstruct(out var width, out var height);
            Console.WriteLine($"{width}, {height}");
            Console.ReadKey();
        }
    }
    public class Rectangle    {        public readonly float Width, Height;        public Rectangle(float width, float height)        {            Width = width;            Height = height;        }
        //在该类型内部声明析构函数
        //public void Deconstruct(out float width,out float height)
        //{
        //    width = Width;
        //    height = Height;
        //}
    }
    //k扩展方法声明类型的析构函数
    public static class Extension    {        public static void Deconstruct(this Rectangle rect, out float width, out float height)        {            width = rect.Width;            height = rect.Height;        }    }
}
