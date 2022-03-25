using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutiThreading
{
    
    class Program
    {
        static void Main_(string[] args)
        {
            int x, y;
            System.Threading.ThreadPool.GetMaxThreads(out x, out y);
            Console.WriteLine($"{x}, {y}");
            Console.WriteLine($"Main Executed By {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            //New Thread
            //System.Threading.Thread _taskThreadObj =
            //    new System.Threading.Thread(new System.Threading.ThreadStart(Task)) { IsBackground = true };

            //System.Threading.Thread _newTaskThreadObj =
            //    new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(NewTask)) { IsBackground = true };

            //_taskThreadObj.Start();
            //_newTaskThreadObj.Start(null);

            System.Threading.WaitCallback _taskAddress = new System.Threading.WaitCallback((obj) => { Task(); });
            System.Threading.WaitCallback _newTaskAddress = new System.Threading.WaitCallback(NewTask);

            //ThreadPool Manager
            System.Threading.ThreadPool.QueueUserWorkItem(_taskAddress, null);
            System.Threading.ThreadPool.QueueUserWorkItem(_newTaskAddress, null);

            Console.ReadLine();
        }
        static void Task()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Task Executed By {System.Threading.Thread.CurrentThread.ManagedThreadId}, Forground Mode : {!System.Threading.Thread.CurrentThread.IsBackground}, ThreadPool Thread:{System.Threading.Thread.CurrentThread.IsThreadPoolThread}");
                System.Threading.Thread.Sleep(1000);
                if (i == 6)
                {
                    Console.ReadLine();
                }
            }
        }
        static void NewTask(object data)
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"NewTask Executed By {System.Threading.Thread.CurrentThread.ManagedThreadId},Forground Mode : {!System.Threading.Thread.CurrentThread.IsBackground},ThreadPool Thread:{System.Threading.Thread.CurrentThread.IsThreadPoolThread}");
            }
        }

        static void Main()
        {
            /*
             * T1/T2 ,T3,T4,T5
             * T1,T3,T4,T5
             * T2,T3,T4,T5
             */ 
           // new System.Threading.Thread(Singleton.Instance.Operation_One) {Name="T1" }.Start();
           // new System.Threading.Thread(Singleton.Instance.Operation_One) { Name = "T2" }.Start();
           // new System.Threading.Thread(Singleton.Instance.Operation_Two) { Name = "T3" }.Start();
            //new System.Threading.Thread(Singleton.Instance.Operation_Two) { Name = "T4" }.Start();
            new System.Threading.Thread(Singleton.Instance.Operation_Three) { Name = "T5" }.Start();
            new System.Threading.Thread(Singleton.Instance.Operation_Three) { Name = "T6" }.Start();
            //new System.Threading.Thread(Singleton.Instance.Operation_Four) { Name="T6"}.Start();
        }

    }
}
