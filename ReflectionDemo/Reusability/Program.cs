using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reusability
{
    //public interface IStringPredicate
    //{
    //    bool Filter(string item);
    //}

    //public class CheckStringStartsWithAny : IStringPredicate
    //{
    //    string key;
    //    public CheckStringStartsWithAny(string key)
    //    {
    //        this.key = key;
    //    }
    //    public bool Filter(string item)
    //    {
    //        return item.StartsWith(this.key);
    //    }
    //}
    //public class CheckStringEndsWithAny : IStringPredicate
    //{
    //    string key;
    //    public CheckStringEndsWithAny(string key)
    //    {
    //        this.key = key;
    //    }
    //    public bool Filter(string item)
    //    {
    //        return item.EndsWith(this.key);
    //    }
    //}



    //Command Pattern

    /* Command - > Encapsulate Request
     * Command -> delegate calls
     * */
    //public class MethodWrapper_Returns_Boolean_Accepts_StringAsArgument
    //{
    //    System.Type  target;
    //    string methodName;
    //    public MethodWrapper_Returns_Boolean_Accepts_StringAsArgument(System.Type target, string methodName)
    //    {
    //        this.target = target;
    //        this.methodName = methodName;
    //    }
    //    public bool Invoke(string item)
    //    {
    //        bool result = default(bool);
    //        //Reflection
    //       System.Reflection.MethodInfo _method= target.GetMethod(this.methodName, 
    //            System.Reflection.BindingFlags.Instance | 
    //            System.Reflection.BindingFlags.Static |
    //            System.Reflection.BindingFlags.Public | 
    //            System.Reflection.BindingFlags.NonPublic);
    //        if(_method.ReturnType==typeof(bool) && _method.GetParameters().Length ==1 && _method.GetParameters()[0].ParameterType == typeof(string))
    //        {
    //            result=(bool)_method.Invoke(this.target, new object[] { item });

    //        }
    //        else
    //        {
    //            throw new InvalidOperationException("Signature Mismatch");
    //        }
    //        return result;

    //    }


    //}

    public delegate bool MethodWrapper_Returns_Boolean_Accepts_StringAsArgument(string item);
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Philips", "Apple", "Siemens", "General Electricals" };
            //List<string> result = FilterStringUsingAnyPredicate(names, new CheckStringStartsWithAny("s"));
            // result = FilterStringUsingAnyPredicate(names, new CheckStringStartsWithAny("v"));
            // result = FilterStringUsingAnyPredicate(names, new CheckStringEndsWithAny("a"));

            //MethodWrapper_Returns_Boolean_Accepts_StringAsArgument _functionObject = 
            //    new MethodWrapper_Returns_Boolean_Accepts_StringAsArgument(typeof(Program), "CheckStringStartsWith_s");
            //List<string> result = FilterStringUsingAnyPredicate(names, _functionObject);

            //_functionObject = new MethodWrapper_Returns_Boolean_Accepts_StringAsArgument(typeof(Program),nameof(CheckStringEndWith_s));
            //result = FilterStringUsingAnyPredicate(names, _functionObject);

            MethodWrapper_Returns_Boolean_Accepts_StringAsArgument _functionObject =
                Program.CheckStringStartsWithAny("p");
            List<string> result = FilterStringUsingAnyPredicate(names, _functionObject);

            _functionObject = Program.CheckStringStartsWithAny("s");
             result = FilterStringUsingAnyPredicate(names, _functionObject);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }
        public static MethodWrapper_Returns_Boolean_Accepts_StringAsArgument CheckStringStartsWithAny(string key)
        {
            //bool CheckStringStartsWithString(string item)
            //{
            //    return item.StartsWith(key);
            //}
            //Lamda
           MethodWrapper_Returns_Boolean_Accepts_StringAsArgument functionObject= (string item) => { return item.StartsWith(key); };
            return functionObject;
        }
        public static bool CheckStringStartsWith_p(string item)
        {
            return item.StartsWith("p");
        }
        public static bool CheckStringEndWith_s(string item,string key)
        {
            return item.EndsWith("s");
        }
        public static bool CheckStrinLengthGreaterThan_3(string item,string length)
        {
            return item.Length > 3;
        }
        //public static List<string> FilterStringUsingAnyPredicate(string[] names,
        //    IStringPredicate predicateFunction)
        //{
        //    List<string> result = new List<string>();
        //    //iteration
        //    for (int i = 0; i < names.Length; i++)
        //    {
        //        //startswith predicate 
        //        if (predicateFunction.Filter(names[i]))
        //        {
        //            result.Add(names[i]);
        //        }
        //    }
        //    return result;

        //}

        public static List<string> FilterStringUsingAnyPredicate(string[] names,
          MethodWrapper_Returns_Boolean_Accepts_StringAsArgument predicateFunction)
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
