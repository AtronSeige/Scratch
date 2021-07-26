using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ScratchThreading
{
    internal class Program
    {
        
        public static void Main()
        {
            Console.WriteLine("Starting Task");

            var backgroundTasks = new[]
                {
                    Task.Run(() => ThreadProc("1", 10)),
                    Task.Run(() => ThreadProc("2", 10)),
                    Task.Run(() => ThreadProc("3", 10)),
                    Task.Run(() => ThreadProc("4", 10)),
                    Task.Run(() => ThreadProc("5", 10)),
                    Task.Run(() => ThreadProc("6", 10)),
                    Task.Run(() => ThreadProc("7", 10)),
                    Task.Run(() => ThreadProc("8", 10)),
                    Task.Run(() => ThreadProc("9", 10))
                };

            Console.WriteLine("Something");

            // wait synchronously

            //Task.WaitAny(backgroundTasks);
            Task.WaitAll(backgroundTasks);
            Console.WriteLine("All done");
            //// wait asynchronously
            //await Task.WhenAny(backgroundTasks);
            //await Task.WhenAll(backgroundTasks);


            //var result = new List<RetVal>();
            ////create multiple threads
            //for (int i = 1; i < 10; i++)
            //{
            //    Console.WriteLine("Loop " + i.ToString());
            //    //var backgroundTask = Task.Run(() => ThreadProc(i, 5));
            //    var backgroundTask = Task.Run(() => ThreadProc(i));
            //    // do other work
            //    result.AddRange(backgroundTask.Result);
            //}

            ////create a single thread of the task
            //var backgroundTask = Task.Run(() => ThreadProc(5, 10));
            //// do other work
            //var result = backgroundTask.Result;
            //Console.WriteLine($"Completed {result.Count} iterations");



            Console.ReadLine();
        }

        // The ThreadProc method is called when the thread starts.
        // It loops ten times, writing to the console and yielding 
        // the rest of its time slice each time, and then ends.
        public List<RetVal> ThreadProc()
        {
            return ThreadProc("single", 10);
        }

        //public List<RetVal> ThreadProc(int count)
        //{
        //    return ThreadProc(count, 1);
        //}

        public static List<RetVal> ThreadProc(string name, int count)
        {
            var result = new List<RetVal>();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"ThreadProc: {name} {i}");
                result.Add(new RetVal(i, i));
                // Yield the rest of the time slice.
                Thread.Sleep(0);
            }

            return result;
        }

        public static List<RetVal> ThreadProc(int count, int enumeration)
        {
            var result = new List<RetVal>();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < enumeration; j++)
                {
                    Console.WriteLine("ThreadProc: {0} Enum {1}", i, j);
                    result.Add(new RetVal(i, j));
                    // Yield the rest of the time slice.
                    Thread.Sleep(0);
                }
            }

            return result;
        }


        //public static void Main()
        //{
        //    //Console.WriteLine("Main thread: Start a second thread.");
        //    //// The constructor for the Thread class requires a ThreadStart 
        //    //// delegate that represents the method to be executed on the 
        //    //// thread.  C# simplifies the creation of this delegate.
        //    //Thread t = new Thread(new ThreadStart(ThreadProc));

        //    //// Start ThreadProc.  Note that on a uniprocessor, the new 
        //    //// thread does not get any processor time until the main thread 
        //    //// is preempted or yields.  Uncomment the Thread.Sleep that 
        //    //// follows t.Start() to see the difference.
        //    //t.Start();
        //    //Thread.Sleep(0);

        //    //for (int i = 0; i < 4; i++)
        //    //{
        //    //    Console.WriteLine("Main thread: Do some work.");
        //    //    Thread.Sleep(0);
        //    //}

        //    //Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
        //    //t.Join();
        //    //Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
        //    Console.ReadLine();
        //}


        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(WriteX);
        //    t.Start();

        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.Write("O");
        //    }


        //    Console.WriteLine("All Done!");

        //    Console.ReadLine();
        //}

        //static void WriteX()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.Write("x");
        //    }
        //}
    }

    public class RetVal
    {
        public int ThreadNo { get; set; }
        public int ExecutionNo { get; set; }
        public string Name { get; set; }

        public RetVal(int threadNo, int executionNo)
        {
            this.ThreadNo = this.ThreadNo;
            this.ExecutionNo = executionNo;
        }

        public RetVal(string name, int threadNo)
        {
            this.ThreadNo = this.ThreadNo;
            this.Name = name;
        }
    }
}
