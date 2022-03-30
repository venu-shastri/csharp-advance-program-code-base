using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerServiceLib
{
    public class TimerService:TimerServiceContractLib.ITimerService
    {
        public TimerService()
        {
            Console.WriteLine($"{nameof(TimerService)}Instantiated ");
        }
        public string GetServerTimeStamp()

        {
            Console.WriteLine($"Service Operation {nameof(GetServerTimeStamp)} invoked ");
            return System.DateTime.Now.ToString();
        }
    }
}
