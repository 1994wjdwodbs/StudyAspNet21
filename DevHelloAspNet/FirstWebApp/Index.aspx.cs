using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    // Page : ASP.NET 웹 응용 프로그램을 호스트하는 서버에서 요청된 .aspx 파일(Web Forms 페이지라고도 함)을 나타냅니다.
    public partial class Index : System.Web.UI.Page
    {
        // 윈폼, WPF 랑 다른 특성
        // 참조 0개 : aspx 와 맵핑이 되지 않는다!
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnClick_Click(object sender, EventArgs e)
        {
            TxtDisplay.Text += "zzz";
            LblResult.Text = $"안녕햐세요, {TxtDisplay.Text}";
            // Request
            // : System.Web.HttpRequest 요청된 페이지에 대한 개체입니다.
            // Response 
            // : System.Web.HttpResponse 개체와 연결된 System.Web.UI.Page 개체를 가져옵니다. 이 개체를 클라이언트에 HTTP
            //   응답 데이터를 보낼 수 있도록 및 해당 응답에 대 한 정보를 포함 합니다.
            Response.Write("반갑습니다.<br />");
        }
    }
}