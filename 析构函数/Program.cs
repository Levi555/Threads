using System;

namespace 析构函数
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 10);
            rect.Deconstruct(out float width, out float height);
            Console.WriteLine($"Hello{width},{height} World!");
            Console.ReadKey();
        }
    }

    public class Rectangle
    {
        internal  readonly float Width, Height;
        public Rectangle(float width,float height)
        {
              Width = width;
                Height = height;
        }
    }
    public static class Extension
    {
        public static void Deconstruct(this Rectangle rectangle,out float width,out float height)
        {
            width = rectangle.Width;
            height = rectangle.Height;

        }
    }
}
