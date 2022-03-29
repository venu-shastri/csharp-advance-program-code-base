using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    public class A
    {
        B obj = new B();
    }
    public class B
    {

    }
    class Program
    {
        static A globalRef;
        static void Main(string[] args)
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
    }
}
