using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardWrite : System.Web.UI.Page
    {
        // 기본값 : 글쓰기
        public BoardWriteFormType FormType { get; set; } = BoardWriteFormType.Write;

        private string _Id; // 리스트에서 넘겨주는 번호

        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request["Id"]; // GET/POST 모두 다 받음

            if(!Page.IsPostBack) // 페이지 최초 로드 시
            {
                switch (FormType)
                {
                    case BoardWriteFormType.Write :
                        LblTitleDescription.Text = "글쓰기 - 다음 필드들을 입력하세요";
                        break;

                    case BoardWriteFormType.Modify :
                        LblTitleDescription.Text = "글수정 - 다음 필드들을 수정하세요";
                        DisplayDataForModify();
                        break;

                    case BoardWriteFormType.Reply :
                        LblTitleDescription.Text = "글답변 - 다음 필드들을 입력하세요";
                        DisplayDataForReply();
                        break;
                }
            }
        }

        private void DisplayDataForReply()
        {
            throw new NotImplementedException();
        }

        private void DisplayDataForModify()
        {
            throw new NotImplementedException();
        }

        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                // TODO : 파일업로드

                Note note = new Note();
                // Write 모드에서는 Id값이 필요없지만 Modify, Reply 모드는 필요함!
                note.Id = Convert.ToInt32(_Id); // 없으면 0
                note.Name = txtName.Text; // 필수
                note.Email = txtEmail.Text; // 필수
                note.Title = txtTitle.Text; // 필수, 추가할 것!
                note.Homepage = txtHomepage.Text;
                note.Content = txtContent.Text; // 필수
                note.FileName = "";
                note.FileSize = 0;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue; // Text, HTML, Mixed

                DbRepository repo = new DbRepository();

                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    case BoardWriteFormType.Modify:
                        break;
                    case BoardWriteFormType.Reply:
                        break;
                    default:
                        break;
                }

            }
            else
            {
                lblError.Text = "보안코드가 틀립니다. 다시 입력하세요.";
            }
        }

        private bool IsImageTextCorrect()
        {
            if(Page.User.Identity.IsAuthenticated) // 이미 로그인된 상황
            {
                return true;
            }
            else
            {
                // 클라이언트마다 나오는 보안코드 값이 다름
                if (Session["ImageText"] != null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }

                return false; // 보안코드 값 불일치
            }
        }
    }
}