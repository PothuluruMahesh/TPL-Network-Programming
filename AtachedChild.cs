using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary2
{
    class AtachedChild
    {
        public static void Main()
        {
            var parent = Task.Factory.StartNew(() => {
                Console.WriteLine("Parent task executing.");
                var child = Task.Factory.StartNew(() => {
                    Console.WriteLine("Attached child starting.");
                    Thread.SpinWait(5000000);
                    Console.WriteLine("Attached child completing.");
                }, TaskCreationOptions.AttachedToParent);
            });
            parent.Wait();
            Console.WriteLine("Parent has completed.");
        }
    }
}
