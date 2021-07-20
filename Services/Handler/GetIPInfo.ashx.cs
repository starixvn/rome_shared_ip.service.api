using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IPService.BLL;
using IPService.DAL;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Specialized;

//Provide IP Information
//Created: Ryan

namespace IPService.Services.Handler
{
    /// <summary>
    /// Handler to return ip infomation
    /// </summary>
    public class GetIPInfo : IHttpHandler
    {
        const string XML = "xml"; 
        const string JSON = "json";
        
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest contextRequest = context.Request;
            string ip = contextRequest.QueryString["ip"];
            string output = contextRequest.QueryString["output"];            

            if (String.IsNullOrEmpty(output)) output = XML;

            if (!String.IsNullOrEmpty(ip))
            {
                ResponseData(context, ip, output);
            }
        }

        private void ResponseData(HttpContext context, string ip, string output)
        {            
            IPTable ipInfo = IP.GetIPInfo_Full(ip);

            string result = String.Empty;
            context.Response.Charset = "UTF-8";
            if (output.Equals(JSON))
            {
                context.Response.ContentType = "text/json";
                result = GenerateIPByJSON(ipInfo);
            }
            else
            {
                context.Response.ContentType = "text/html";
                result = GenerateIPByXml(ipInfo);
            }

            context.Response.Write(result);
        }

        public string GenerateIPByXml(IPTable ipInfo)
        {
            string xmlReturn = "<?xml version='1.0' encoding='UTF-8'?>" +
                                   "<Response>" +                                   
                                   String.Format("<CountryCode>{0}</CountryCode>", ipInfo.countrySHORT) +
                                   String.Format("<CountryName>{0}</CountryName>", ipInfo.countryLONG) +
                                   String.Format("<RegionName>{0}</RegionName>", ipInfo.ipRegion) +
                                   String.Format("<City>{0}</City>", ipInfo.ipCity) +                                   
                                   String.Format("<FlagPath>{0}/Flags/{1}.gif</FlagPath>", this.GetSiteRoot(), ipInfo.countrySHORT) +
                                   "</Response>";
            return xmlReturn;
        }

        public string GenerateIPByJSON(IPTable ipInfo)
        {
            string xmlReturn = "{" +                                 
                                   String.Format("\"CountryCode\":\"{0}\", ", ipInfo.countrySHORT) +
                                   String.Format("\"CountryName\":\"{0}\", ", ipInfo.countryLONG) +
                                   String.Format("\"RegionName\":\"{0}\", ", ipInfo.ipRegion) +
                                   String.Format("\"City\":\"{0}\", ", ipInfo.ipCity) +                                   
                                   String.Format("\"FlagPath\":\"{0}/Flags/{1}.gif\" ", this.GetSiteRoot(), ipInfo.countrySHORT) +
                               "}";

            string callBackFunc = HttpContext.Current.Request.QueryString["callback"];

            if (!String.IsNullOrEmpty(callBackFunc))
                return String.Format("{0} ( {1} )", callBackFunc, xmlReturn);
            return xmlReturn;
        }

        public string GetSiteRoot()
        {
            if (string.IsNullOrEmpty(IP.PathFlag()))
            {
                Uri url = new Uri(HttpContext.Current.Request.Url.OriginalString);
                return String.Format("{0}://{1}{2}{3}",
                    url.Scheme,
                    url.Host,
                    url.IsDefaultPort ? "" : ":" + url.Port,
                    HttpContext.Current.Request.ApplicationPath.Equals("/") ? "" : HttpContext.Current.Request.ApplicationPath);
            }
            else
            {
                return IP.PathFlag();
            }           
        }        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #region saved code
        //public string ObjectToXml(object obj)
        //{
        //    XmlSerializer xmlTrans = new XmlSerializer(obj.GetType());
        //    MemoryStream memory = new MemoryStream();
        //    XmlTextWriter xmlWriter = new XmlTextWriter(memory, Encoding.UTF8);
        //    xmlTrans.Serialize(xmlWriter, obj);
        //    memory = (MemoryStream)xmlWriter.BaseStream;
        //    string result = UTF8ByteArrayToString(memory.ToArray());
        //    return result;
        //}

        //private String UTF8ByteArrayToString(Byte[] characters)
        //{
        //    UTF8Encoding encoding = new UTF8Encoding();
        //    String constructedString = encoding.GetString(characters);
        //    return (constructedString);
        //}
        #endregion 

    }
}
