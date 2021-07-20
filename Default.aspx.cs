using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPService.BLL;

namespace IPService
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            //IPService.DAL.IPTable ipInfo = IP.GetIPInfo_Full(this.txtIP.Text);
            //this.lblInfo.Text = ipInfo.countryLONG;            
        }
    }
}
