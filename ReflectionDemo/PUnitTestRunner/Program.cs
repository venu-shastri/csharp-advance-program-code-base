using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUnitTestRunner
{
    class Program
    {
        static string codeUnderTestLibPath;
        static void Main(string[] args)
        {
            codeUnderTestLibPath = args[0];
            string testCodePath = args[1];
            
            var testCode = System.Reflection.Assembly.LoadFile(testCodePath);
            System.AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

           var types= testCode.GetTypes();
            foreach(System.Type type in types)
            {
                if(type.IsClass && type.IsPublic && !type.IsAbstract)
                {
                  var attributes=  type.GetCustomAttributes(typeof(PUnitTestFxLib.TestSuiteAttribute), true) as PUnitTestFxLib.TestSuiteAttribute[];
                    if(attributes.Length > 0)
                    {
                        Type testSuiteClass = type;
                        object objRef = System.Activator.CreateInstance(testSuiteClass);
                        //Search For Unit Test Methods
                       var methods= testSuiteClass.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                        foreach(var method in methods)
                        {
                            if(method.GetParameters().Length==0 && method.ReturnType == typeof(void))
                            {
                              var testAttributes=  method.GetCustomAttributes(typeof(PUnitTestFxLib.TestAttribute), true) as PUnitTestFxLib.TestAttribute[];
                                if(testAttributes.Length > 0)
                                {
                                    method.Invoke(objRef, new object[] { });
                                }
                            }
                        }

                    }
                }
            }





        }

        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Console.WriteLine($"{ args.Name} , {args.RequestingAssembly}");
            var codeUnderTestLib = System.Reflection.Assembly.LoadFile(codeUnderTestLibPath);
            return codeUnderTestLib;
        }
    }
}
