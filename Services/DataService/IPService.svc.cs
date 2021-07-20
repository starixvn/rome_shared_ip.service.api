using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using IPService.DAL;
using IPService.BLL;

namespace IPService.Services.Data
{
    public class IPService : DataService<IPDBEntities>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(IDataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            config.SetServiceOperationAccessRule("*",
                                      ServiceOperationRights.All);
        }

        [WebGet]
        public IPTable GetIPInfo(string ip)
        {
            return IP.GetIPInfo_Full(ip);
        }

    }
}
