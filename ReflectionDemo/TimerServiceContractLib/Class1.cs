using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerServiceContractLib
{
    [System.ServiceModel.ServiceContract]
    public interface ITimerService
    {
        [System.ServiceModel.OperationContract]
        string GetServerTimeStamp();
    }
}
