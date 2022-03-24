using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutiThreading
{
    [System.Runtime.Remoting.Contexts.Synchronization]
  public  class Singleton:System.ContextBoundObject
    {
        public static readonly Singleton Instance = new Singleton();
        private Singleton() { }
        public void Operation_One() {
        
            for(int i = 0; i < 5; i++) {

                Console.WriteLine($"{nameof(Operation_One)} method executed by {System.Threading.Thread.CurrentThread.Name}");
                System.Threading.Thread.Sleep(1000);
            }
        }
        public void Operation_Two() {
            for (int i = 0; i < 10; i++) {

                Console.WriteLine($"{nameof(Operation_One)} method executed by {System.Threading.Thread.CurrentThread.Name}");
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void Operation_Three() {
            for (int i = 0; i < 15; i++) {


                Console.WriteLine($"{nameof(Operation_Three)} method executed by {System.Threading.Thread.CurrentThread.Name}");
                System.Threading.Thread.Sleep(1000);
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
