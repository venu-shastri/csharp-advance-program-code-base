using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    [Serializable]
    public class ServerData
    {

    }
   public interface IService
    {
        ServerData Operation();
    }
    
    public class Service:MarshalByRefObject, IService
    {
        public Service() {
            Console.WriteLine($"Service Instantiated in -{ System.AppDomain.CurrentDomain.FriendlyName}");
        }
        public ServerData Operation() {

            Console.WriteLine($"Service Operation Executed  in -{ System.AppDomain.CurrentDomain.FriendlyName}");
            return null;
        }

    }
    class Program
    {
        static void Main_(string[] args)
        {
            AppDomain _appDomain=AppDomain.CreateDomain("Server");
            //Service _serviceRef = new Service();
           System.Runtime.Remoting.ObjectHandle _handle= _appDomain.CreateInstance(nameof(ReflectionDemo), "ReflectionDemo.Service");
            Client(_handle);
        }
        static void Client(System.Runtime.Remoting.ObjectHandle serviceHandle)
        {
            Console.WriteLine($"Cleint  Code Executed  in -{ System.AppDomain.CurrentDomain.FriendlyName}");
            // Remote - Ref
             IService objRef=serviceHandle.Unwrap() as IService ;
            objRef.Operation(); // Remote Procedural Call
        }
        static void Main()
        {
            Dictionary<string, string> _themeLibPaths = new Dictionary<string, string>();
            _themeLibPaths.Add("Dark", @"C:\Users\user\source\repos\ReflectionDemo\DarkThemeLib\bin\Debug\DarkThemeLib.dll");
            _themeLibPaths.Add("Light", @"C:\Users\user\source\repos\ReflectionDemo\LightThemeLib\bin\Debug\LightThemeLib.dll");

            Console.WriteLine($"Dark->DarkTheme,Light->LightTheme");
           string theme= Console.ReadLine();
            if (_themeLibPaths.ContainsKey(theme))
            {
                string path = _themeLibPaths[theme];
                System.Reflection.Assembly _themeLib = System.Reflection.Assembly.LoadFile(path);
               System.Type _typeDef= _themeLib.GetType($"{theme}ThemeLib.ThemeType");
                if (_typeDef.IsClass)
                {
                   System.Reflection.MethodInfo _methodDef=
                        _typeDef.GetMethod("GetTheme", System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.Instance);
                   object objRef= System.Activator.CreateInstance(_typeDef);
                     object result=_methodDef.Invoke(objRef, new object[] { });
                    Console.WriteLine(result);
                }

            }
            //Load Library
            
            

        }
    }
}
