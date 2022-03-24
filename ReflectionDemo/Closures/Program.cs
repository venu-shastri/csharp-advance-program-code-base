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
            List<string> nameList = names.ToList();
            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            Func<string, bool> predicateFunction = StringStartsWithPredicateGenerator("s");
            FilterStringUsingAnyPredicate(names, predicateFunction);

            predicateFunction = StringStartsWithPredicateGenerator("u");
            FilterStringUsingAnyPredicate<string>(names, predicateFunction);

            predicateFunction = StringStartsWithPredicateGenerator("v");
            FilterStringUsingAnyPredicate<string>(nameList, predicateFunction);

            

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

        //public static IEnumerable<TypeParameter> Where(IEnumerable<TypeParameter> source,Func<TypeParameter,bool>   predicateFunction)
        public static IEnumerable<TypeParameter> FilterIEnumerableSourceUsingAnyPredicate<TypeParameter>(IEnumerable<TypeParameter> source,Func<TypeParameter,bool>   predicateFunction)
        {
            List<TypeParameter> result = new List<TypeParameter>();
            //iteration interaction Code

            //IEnumerator<TypeParameter> iterator = source.GetEnumerator();
            //try{
            //while (iterator.MoveNext())
            //{
            //   TypeParameter item= iterator.Current;
            //    if (predicateFunction.Invoke(item))
            //    {
            //        result.Add(item);
            //    }
            //}
            //}
            //finally
            //{
              //  if(iterator is IDisposable)
                //{
                  //  iterator.Dispose();
               // }
            //}
            foreach(TypeParameter item in source)
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
