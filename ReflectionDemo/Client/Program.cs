using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //Channel 
            //Endpoint (Contract,Binding,Address)
          TimerServiceContractLib.ITimerService _proxyRef=  System.ServiceModel.ChannelFactory<TimerServiceContractLib.ITimerService>.
                CreateChannel(
                new System.ServiceModel.NetNamedPipeBinding(), 
                new System.ServiceModel.EndpointAddress("net.pipe://localhost/pipe"));
             string result=_proxyRef.GetServerTimeStamp();//SOAP Message
            Console.WriteLine(result);

        }
    }
}
