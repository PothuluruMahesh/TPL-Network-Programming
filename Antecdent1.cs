﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParallelLibrary2
{
    public class Antecdent1
    {
        public static void Main()
        {
            List<Task<int>> tasks = new List<Task<int>>();
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                int baseValue = ctr;
                tasks.Add(Task.Factory.StartNew((b) => 
                {
                    int i = (int)b;
                    return i * i;
                }, baseValue));
            }
            var continuation = Task.WhenAll(tasks);

            long sum = 0;
            for (int ctr = 0; ctr <= continuation.Result.Length - 1; ctr++)
            {
                Console.Write("{0} {1} ", continuation.Result[ctr],ctr == continuation.Result.Length - 1 ? "=" : "+");
                sum += continuation.Result[ctr];
            }
            Console.WriteLine(sum);
    
        }
    }
}
