using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskParallelLibrary2
{
    class TaskForEach1
    {
        static void Main(string[] args)
        {
            List<string> li = new List<string>();
            li.Add("Apple");
            li.Add("Banana");
            li.Add("Bilberry");
            li.Add("Blackberry");
            li.Add("Blackcurrant");
            li.Add("Blueberry");
            li.Add("Cherry");
            li.Add("Coconut");
            li.Add("Cranberry");
            li.Add("Date");
            li.Add("Fig");
            li.Add("Grape");
            li.Add("Guava");
            li.Add("Jack-fruit");
            li.Add("Kiwi fruit");
            li.Add("Lemon");
            li.Add("Lime");
            li.Add("Lychee");
            li.Add("Mango");
            li.Add("Melon");
            li.Add("Olive");
            li.Add("Orange");
            li.Add("Papaya");
            li.Add("Plum");
            li.Add("Pineapple");
            li.Add("Pomegranate");

            Console.WriteLine("Printing list using foreach loop\n");

            var stopWatch = Stopwatch.StartNew();
            foreach (string fruit in li)
            {
                Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("foreach loop execution time = {0} seconds\n", stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("Printing list using Parallel.ForEach");


            stopWatch = Stopwatch.StartNew();
            Parallel.ForEach(li, fruit =>
            {
                Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);

            }
            );
            Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);
        }
    }
}
