using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IPService.DAL;

namespace IPService.Services.WCF
{    
    [ServiceContract]
    public interface IWCF_IPService
    {        
        [OperationContract]
        IPTable GetIPInfo(string ip);
    }
}   
