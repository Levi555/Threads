using System;
using System.Collections;
using System.Collections.Generic;

namespace 排序
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayList array = new ArrayList();
            Random ran = new Random();
            List<int> list = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(ran.Next(1, 100));
            }
            Console.WriteLine("排序前:");
            foreach (var item in list)
            {
                Console.Write(item+"  ");
            }
            Console.WriteLine();
            QuickSort(list, 0, list.Count-1);
            Console.WriteLine("排序后:");
            foreach (var item in list)
            {
                Console.Write(item + "  ");
            }
            //Console.WriteLine("Hello World!");
        }
        static void QuickSort(List<int> a,int left,int right)
        {
            if (left < right)
            {
                var pivot = GetPivot(a, left, right);
                QuickSort(a, left, pivot-1);
                QuickSort(a, pivot + 1, right);
            }
        }
        static int GetPivot(List<int> a,int left,int right)
        {
            int temp = a[left];
            while (left<right)
            {
                while (left<right)
                {
                    if(a[right] < temp)
                    {
                        a[left] = a[right];
                        break;
                    }
                    right--;
                }
                while (left<right)
                {
                    if(a[left] > temp)
                    {
                        a[right] = a[left];
                        break;
                    }
                    left++;
                }
            }
            a[left] = temp;
            return left;
        }
    }
}
