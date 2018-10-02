using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary2
{
    class TaskAsyn
    {
        public static void Main()
        {
            Thread.CurrentThread.Name = "MAIN";
            Task taskA = new Task(() => Console.WriteLine("Hello from taskA."));
            taskA.Start();
            Console.WriteLine("Hello from thread '{0}'.",Thread.CurrentThread.Name);
            taskA.Wait();
        }
    }
}
