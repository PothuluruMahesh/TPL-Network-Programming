using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary2
{
    class DetachedChild
    {
        public static void Main()
        {
            var parent = Task.Factory.StartNew(() => 
            {
                Console.WriteLine("Parent task executing.");

                var child = Task.Factory.StartNew(() => 
                {
                    Console.WriteLine("Child task starting.");
                    Thread.SpinWait(500000);
                    Console.WriteLine("Chiild task completing.");
                });
            });

            parent.Wait();
            Console.WriteLine("Parent has completed.");
        }
    }
}
