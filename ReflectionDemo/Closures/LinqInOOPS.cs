using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures
{
   public  class LinqInOOPS
    {
        //pure function 
        //Add(10,20)..........................n
        //Parallelism ................N threads
        //High Performance- cache
        public static   int Add(int x,int y)
        {
            return x+y;
        }
        public  IEnumerable<TypeParameter> FilterIEnumerableSourceUsingAnyPredicate<TypeParameter>(IEnumerable<TypeParameter> source, Func<TypeParameter, bool> predicateFunction)
        {
            List<TypeParameter> result = new List<TypeParameter>();
            foreach (TypeParameter item in source)
            {
                if (predicateFunction.Invoke(item))
                {
                    result.Add(item);
                }
            }

            return result;

        }


    }
}
