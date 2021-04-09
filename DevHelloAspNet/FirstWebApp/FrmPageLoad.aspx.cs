using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmPageLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "제목변경";
            Page.Title = "또 제목변경";

            // 코드로 CSS 추가하기
            /*HtmlLink cssLink = new HtmlLink();
            cssLink.Href = "Content/main.css";
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");

            HtmlHead htmlHead = Page.Header;
            htmlHead.Controls.Add(cssLink);*/

            // IsPostBack
            //     페이지를 처음으로 렌더링되고 또는 포스트백에 대한 응답으로 로드되고 있는지를 나타내는 값을 가져옵니다.
            //     클라이언트 포스트백에 대한 응답으로 페이지가 로드되면 true, 그렇지 않으면 false합니다.
            if (!Page.IsPostBack)
                Response.Write("[1] 폼 최초 로드 <br />");
            else
                Response.Write("[2] 폼 다시 로드 <br />");

            Response.Write("[3] 항상 실행 <br />");
        }

        protected void BtnPostBack_Click(object sender, EventArgs e)
        {
            var strScript = @"<script> window.alert('PostBack'); </script>";
            // 스크립트 추가 및 실행 방법
            ClientScript.RegisterClientScriptBlock(this.GetType(), "postScript", strScript);
        }

        protected void BtnNewLoad_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmPageLoad.aspx");
        }
    }
}