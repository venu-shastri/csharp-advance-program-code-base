using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            System.ServiceModel.ServiceHost _wcfRuntime =
                new System.ServiceModel.ServiceHost(typeof(TimerServiceLib.TimerService));
            _wcfRuntime.Open();
            Console.WriteLine("Server Started");
            Console.ReadKey();
        }
    }
}
