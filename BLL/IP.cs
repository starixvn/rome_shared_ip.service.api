using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPService.DAL;
using DNAide.Data;

/*
 * Provide IP Services from database
 * Created: Ryan
 */
namespace IPService.BLL
{
    public class IP
    {
        public IP() { }

        public static IPTable GetIPInfo_Full(string ip)
        {
            using (var db = new IPDBEntities(IP.GetEFConnectionString()))
            {                
                List<IPTable> ips = db.GetIPInfo_Full(ip).ToList();                
                if (ips.Count == 0) return null;
                return ips[0];
            }
        }

        public static string GetEFConnectionString()
        {
            return DbConnSettings.GetEFConnectionString("IPDBEntities");
        }
        public static string PathFlag()
        {
            return System.Configuration.ConfigurationManager.AppSettings["pathFlag"].ToString(); 
        }
    
    }
}
