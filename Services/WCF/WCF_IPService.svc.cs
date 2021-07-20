using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;
using IPService.BLL;
using IPService.DAL;

namespace IPService.Services.WCF
{
    
    [AspNetCompatibilityRequirements (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class IPService : IWCF_IPService
    {   
        public IPTable GetIPInfo(string ip)
        {
            return IP.GetIPInfo_Full(ip);            
        }

        //[WebGet(ResponseFormat = WebMessageFormat.Json)]
        //public string GetIPInfoByJSON(string ip)
        //{
        //    IPTable ipInfo = GetIPInfo(ip);
        //    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IPTable));
        //}
    }

    //public class CustomHostFactory : ServiceHostFactory
    //{
    //    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    //    {
    //        CustomHost customServiceHost =
    //          new CustomHost(serviceType, baseAddresses[1]);
    //        return customServiceHost;
    //    }
    //}

    //public class CustomHost : ServiceHost
    //{
    //    public CustomHost(Type serviceType, params Uri[] baseAddresses)
    //        : base(serviceType, baseAddresses)
    //    { }
    //    protected override void ApplyConfiguration()
    //    {
    //        base.ApplyConfiguration();
    //    }
    //}
}
