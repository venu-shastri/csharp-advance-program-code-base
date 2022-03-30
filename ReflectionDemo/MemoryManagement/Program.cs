using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    public enum ResourceState
    {
        FREE,BUSY
    }
    public  class Resource
    {
        public  static readonly Resource Instance = new Resource();
        public ResourceState State = ResourceState.FREE;
        
    }
    public class A:IDisposable
    {
        
        public static System.Threading.AutoResetEvent _handle = new System.Threading.AutoResetEvent(false);
        public A()
           
        {
            lock (A._handle)
            {
                if (Resource.Instance.State == ResourceState.FREE)
                {
                    Console.WriteLine($"Resource Owned By {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                }
                else
                {
                    Console.WriteLine($"Resource Awaited By {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    //wait
                    _handle.WaitOne();
                    Console.WriteLine($"Resource Owned By {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                }
               
                Resource.Instance.State = ResourceState.BUSY;
            }
        }

        bool isDisposed = false;
       protected void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                if (!isDisposed)
                {
                    isDisposed = true;
                    GC.SuppressFinalize(this);
                    Resource.Instance.State = ResourceState.FREE;
                    Console.WriteLine($"Resource Released usig Dispose() By {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    A._handle.Set();
                }
               
            }
            else
            {
                Resource.Instance.State = ResourceState.FREE;
                Console.WriteLine($"Resource Released usig Finalize() By {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                A._handle.Set();
            }
        }

        //Finalize
        ~A()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            
        }
        public void UseResource()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Resource Used By {System.Threading.Thread.CurrentThread.ManagedThreadId}");
                System.Threading.Thread.Sleep(1000);
            }

        }
    }
    public class B
    {

    }
    class Program
    {
        static A globalRef;
        static void Main_(string[] args)
        {
            Allocate();
            globalRef = null;
            GC.Collect();//yes
        }
        static void Allocate()
        {
            A obj = new A();//0
            Console.WriteLine(GC.GetGeneration(obj));
            List<A> _collections = new List<A>();
            _collections.Add(obj);
            Program.globalRef = obj;
            GC.Collect();//No
            Console.WriteLine(GC.GetGeneration(obj)); // 1
            obj = null;
            GC.Collect();//No
            Console.WriteLine(GC.GetGeneration(_collections[0]));//2
            _collections.Clear();
            GC.Collect();//No
            Console.WriteLine(GC.GetGeneration(globalRef)); //2

        }

        static void Main()
        {
            new System.Threading.Thread(Client).Start();
            new System.Threading.Thread(Client).Start();
        }
        static void Client()
        {
            A obj = null;
            try
            {
                obj = new A();
                obj.UseResource();
               // obj.Dispose();
            }
            catch(Exception e)
            {
                //obj.Dispose();
            }
            finally
            {
                if (obj is IDisposable)
                {
                   // obj.Dispose();
                }
            }

            obj = null; // mark for collection
                        //using(A obj=new A())
                        //{
                        //    obj.UseResource();
                        //}

            GC.Collect();
            GC.WaitForPendingFinalizers();

        }
    }
}
