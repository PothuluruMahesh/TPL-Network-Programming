using System;
using System.Collections.Generic;
using System.Text;

//Sample 01: Required Namespace
using System.Threading;

namespace TaskParallelLibrary2
{
    class ThreadPool1
    {
        private static void TaskCallBack(Object ThreadNumber)
        {
            string ThreadName = "Thread " + ThreadNumber.ToString();
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(ThreadName + ": " + i.ToString());
            }
            Console.WriteLine(ThreadName + "Finished...");
        }

        static void Main(string[] args)
        {
            for (int task = 1; task < 26; task++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(TaskCallBack), task);
            }
            Thread.Sleep(10000);
        }
    }
}