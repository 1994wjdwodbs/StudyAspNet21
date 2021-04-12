using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWebApp
{
    public partial class FrmButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // IsPostBack :
            //     Gets a value that indicates whether the page is being rendered for the first
            //     time or is being loaded in response to a postback.
            
            // PostBack :
            //     이벤트를 처리하기 위하여 페이지 자체적으로 페이지를 다시 로드하여 처리하게 되는데 이걸 포스트백(PostBack)이라고 한다.
            //     submit 같은 버튼을 통해 다시 자신에 페이지가 새로 고침이 일어나는 현상
            //     Page.IsPostBack : 포스트백이 일어난 것인지 판단하는 속성, 
            //     !Page.IsPostBack 이라고 묻는것은 페이지가 처음 로드 되었는지를 확인하는 것
            if (!IsPostBack) // 포스트백이 아니면
            // Page.IsPostBack
                TxtNum.Text = "0";
        }

        protected void BtnInc_Click(object sender, EventArgs e)
        {
            TxtNum.Text = $"{(int.Parse(TxtNum.Text) + 1)}";
        }

        protected void BtnDec_Click(object sender, EventArgs e)
        {
            TxtNum.Text = $"{(int.Parse(TxtNum.Text) - 1)}";
        }

        protected void BtnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.naver.com");
        }

        protected void BtnImage_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}