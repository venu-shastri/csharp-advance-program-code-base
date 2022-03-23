using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closures
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Philips", "Apple", "Siemens", "General Electricals" };
            Func<string, bool> predicateFunction = StringStartsWithPredicateGenerator("s");
            FilterStringUsingAnyPredicate(names, predicateFunction);

            predicateFunction = StringStartsWithPredicateGenerator("u");
            FilterStringUsingAnyPredicate(names, predicateFunction);

            predicateFunction = StringStartsWithPredicateGenerator("v");
            FilterStringUsingAnyPredicate(names, predicateFunction);

            //FilterStringUsingAnyPredicate(names, (string item)=> { return item.StartsWith("s"); }) ;
            //FilterStringUsingAnyPredicate(names, (string item) => { return item.StartsWith("v"); });
            //FilterStringUsingAnyPredicate(names, (string item) => { return item.StartsWith("u"); });
            //FilterStringUsingAnyPredicate(names, (string item) => { return item.StartsWith("x"); });
            //FilterStringUsingAnyPredicate(names, (string item) => { return item.StartsWith("z"); });

        }

        static Func<string, bool> StringStartsWithPredicateGenerator(string startsWith)
        {

            bool FilterMethod(string item)
            {
                return item.StartsWith(startsWith);
            }
            //Func<string, bool> predicateMethod = (string item) => { return item.StartsWith(startsWith); };
            return FilterMethod;
        }
        //static Func<string, bool> StringLengthPredicateGenerator(int length)
        //{

        //    //bool FilterMethod(string item)
        //    //{
        //    //    return item.StartsWith(startsWith);
        //    //}
        //    Func<string, bool> predicateMethod = (string item) => { return item.Length>length };
        //    return predicateMethod;
        //}

        public static List<string> FilterStringUsingAnyPredicate(string[] names,Func<string,bool>   predicateFunction)
        {
            List<string> result = new List<string>();
            //iteration
            for (int i = 0; i < names.Length; i++)
            {
                //startswith predicate 
                if (predicateFunction.Invoke(names[i]))
                {
                    result.Add(names[i]);
                }
            }
            return result;

        }

    }
}
