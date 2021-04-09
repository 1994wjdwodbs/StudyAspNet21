using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strUserId = string.Empty;
            string strPassword = string.Empty;
            string strName = string.Empty;
            string strAge = string.Empty;

            strUserId = Request.QueryString["TxtUserID"]; // GET형식 
            strPassword = Request.Params["TxtPassword"]; // GET/POST 뭐든지 불러옴
            strName = Request.Form["TxtName"]; // POST 형식
            strAge = Request["TxtAge"]; // GET/POST 뭐든지 불러옴

            var result = $"{strUserId}, {strPassword}, {strName}, {strAge}<br />";
            Response.Write(result);

            LblResult.Text = result;
            LblIpAddress.Text = Request.UserHostAddress;
        }
    }
}