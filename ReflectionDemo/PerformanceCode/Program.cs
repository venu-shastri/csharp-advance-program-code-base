using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceCode
{
    class Program
    {
        static void Main_Data_Parallelism(string[] args)
        {
            Console.WriteLine(System.Environment.ProcessorCount);
            string[] content = { "a", "b", "c", "d", "e", "f", "g", "h","i","j","k","l","m","n" };
           
           
            System.Diagnostics.Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();
            _stopWatch.Start();
           
            //List<string> _encryptedContent =content.AsParallel().Select(item => Encrypt(item)).ToList();
            content.AsParallel().Select(item => Encrypt(item)).ForAll((ei) => {

                Console.WriteLine($"Data Item {ei} , Thread Id : {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            
            });
            _stopWatch.Stop();
            Parallel.Invoke();
           


        }
        static string Encrypt(string item)
        {
            System.Threading.Thread.Sleep(1000);
            return item.ToUpper();
        }

        static void Main()
        {
            Task _asyncTask = new Task(Task1);
            Task _asyncTask2 = new Task(Task2,"Task 2");
            Task<string> _asyncTask3 = new Task<string>(Task3);
            Task<string> _asyncTask4 = new Task<string>(Task4,"Task 3");

            _asyncTask.Start();
            _asyncTask2.Start();
            _asyncTask3.Start();
            _asyncTask4.Start();
            try
            {
                Task.WaitAll(_asyncTask, _asyncTask2, _asyncTask3, _asyncTask4);
                Console.WriteLine(_asyncTask3.Result);
                Console.WriteLine(_asyncTask4.Result);
            }
            catch(AggregateException ex)
            {
                Console.WriteLine("Exception in Tasks");
                var exceptions = ex.Flatten();
                foreach(var exception in exceptions.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }

            }
                
        }
        static void Task1() { 
        
        for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thask 1:Thread ID:{System.Threading.Thread.CurrentThread.ManagedThreadId}" +
                    $":IsThreadPoolThread:{System.Threading.Thread.CurrentThread.IsThreadPoolThread}" +
                    $":IsBackGround Mode Execution:{System.Threading.Thread.CurrentThread.IsBackground}");
                System.Threading.Thread.Sleep(1000);
                if (i == 2) { throw new InvalidOperationException("Task 1"); }
            }
        }
        static void Task2(object obj) {

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thask 2:Thread ID:{System.Threading.Thread.CurrentThread.ManagedThreadId}" +
                    $":IsThreadPoolThread:{System.Threading.Thread.CurrentThread.IsThreadPoolThread}" +
                    $":IsBackGround Mode Execution:{System.Threading.Thread.CurrentThread.IsBackground}");
                System.Threading.Thread.Sleep(1000);
                if (i == 3) { throw new InvalidOperationException("Task 2"); }
            }
        }

        static string Task3() {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Thask 3:Thread ID:{System.Threading.Thread.CurrentThread.ManagedThreadId}" +
                    $":IsThreadPoolThread:{System.Threading.Thread.CurrentThread.IsThreadPoolThread}" +
                    $":IsBackGround Mode Execution:{System.Threading.Thread.CurrentThread.IsBackground}");
                System.Threading.Thread.Sleep(1000);
                if (i == 4) { throw new InvalidOperationException("Task 3"); }
            }
            return "Task 3 Done";
        }
        static string Task4(object obj) {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thask 4:Thread ID:{System.Threading.Thread.CurrentThread.ManagedThreadId}" +
                    $":IsThreadPoolThread:{System.Threading.Thread.CurrentThread.IsThreadPoolThread}" +
                    $":IsBackGround Mode Execution:{System.Threading.Thread.CurrentThread.IsBackground}");
                System.Threading.Thread.Sleep(1000);
                if (i == 8) { throw new InvalidOperationException("Task 4"); }
            }
            return "Task 4 Done";
        }


    }
}
