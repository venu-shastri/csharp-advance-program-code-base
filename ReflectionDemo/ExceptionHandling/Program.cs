using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
           
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
           System.Threading.Thread _t1 = new System.Threading.Thread(Test);
            
            Test();
        }

        private static void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
         
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
           
        }

        static void Test()
        {
            Foo();
        }
        static void Foo()
        {
            try
            {
                Fun();
            }
            catch(System.Runtime.InteropServices.COMException e)
            {
                Console.WriteLine("bla....");
            }
            
           

        }
        static void Fun()
        {
            throw new InvalidOperationException("Fun");
            
                
        }

    }
}
