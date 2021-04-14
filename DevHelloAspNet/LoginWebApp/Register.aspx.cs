using LoginWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            Repository repo = new Repository();
            if(repo.AddUser(TxtUserID.Text, TxtPassword.Text) == 1)
            {
                // javascript를 이용한 리다이렉트
                var strScript = @"<script>
                                    alert('가입완료');
                                    location.href='Default.aspx';
                                  </script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alertJS", strScript);
            }
        }
    }
}