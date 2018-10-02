using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace TaskParallelLibrary2
{
    class TaskFor1
    {
        public static void Main()
        {
            long totalSize = 0;

            String[] args = Environment.GetCommandLineArgs(); //it is static class from System namespace
            if (args.Length == 1)
            {
                Console.WriteLine("There are no command line arguments.");
                return;
            }
            if (!Directory.Exists(args[1]))
            {
                Console.WriteLine("The directory does not exist.");
                return;
            }

            String[] files = Directory.GetFiles(args[1]);
            Parallel.For(0, files.Length,index => 
                         {
                             FileInfo fi = new FileInfo(files[index]);
                             long size = fi.Length;
                             //Provides atomic operations for variables that are shared by multiple threads.
                             Interlocked.Add(ref totalSize, size);
                         });
            Console.WriteLine("Directory '{0}':", args[1]);
            Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
        }
    }
}

