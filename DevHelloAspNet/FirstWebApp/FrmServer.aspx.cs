using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblServerPath.Text = Server.MapPath(".");
            LblRequestPath.Text = Request.ServerVariables["SCRIPT_NAME"];
            Application["Example"]
                = 1;
        }
    }
}