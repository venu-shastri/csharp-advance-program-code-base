using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
namespace MutiThreading
{
    //[System.Runtime.Remoting.Contexts.Synchronization]
  public  class Singleton //:System.ContextBoundObject
    {
        private System.Threading.Mutex _operationThreeHandle = new System.Threading.Mutex();
        private object _syncObjectOperationOne = new object();
        private object _syncObjectOperationTwo = new object();
        public static readonly Singleton Instance = new Singleton();
        private Singleton() { }
        [MethodImpl(MethodImplOptions.Synchronized)]
        //Monitors
        //fense
        //check object header - has - any thread id
        public void Operation_One(/*this */) {
            try
            {
                System.Threading.Monitor.Enter(_syncObjectOperationOne);
                for (int i = 0; i < 5; i++)
                {

                    Console.WriteLine($"{nameof(Operation_One)} method executed by {System.Threading.Thread.CurrentThread.Name}");
                    System.Threading.Thread.Sleep(1000);
                    if (i == 3) { return; }
                }
            }
            finally
            {
                System.Threading.Monitor.Exit(_syncObjectOperationOne);
            }
        }
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Operation_Two(/* this */) {

            lock (_syncObjectOperationTwo)
            {
                for (int i = 0; i < 10; i++)
                {

                    Console.WriteLine($"{nameof(Operation_One)} method executed by {System.Threading.Thread.CurrentThread.Name}");
                    System.Threading.Thread.Sleep(1000);
                }

            }
            

        }

        public void Operation_Three() {
            try
            {
                this._operationThreeHandle.WaitOne();
                for (int i = 0; i < 15; i++)
                {


                    Console.WriteLine($"{nameof(Operation_Three)} method executed by {System.Threading.Thread.CurrentThread.Name}");
                    System.Threading.Thread.Sleep(1000);
                }
            }
            finally
            {
                this._operationThreeHandle.ReleaseMutex();
            }
        }
        public void Operation_Four() {

            for (int i = 0; i < 20; i++) {


                Console.WriteLine($"{nameof(Operation_Four)} method executed by {System.Threading.Thread.CurrentThread.Name}");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
