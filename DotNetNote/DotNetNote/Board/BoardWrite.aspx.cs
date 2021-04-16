using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helpers;
using System.IO;

namespace DotNetNote.Board
{
    public partial class BoardWrite : System.Web.UI.Page
    {
        // 기본값 : 글쓰기
        public BoardWriteFormType FormType { get; set; } = BoardWriteFormType.Write;

        private string _Id; // 리스트에서 넘겨주는 번호
        // public string _Mode; // 뷰에서 넘겨주는 모드값 (Mode : Edit, Reply)

        private string _BaseDir = string.Empty; // GitRepository\StudyASPNET21\... Files
        private string _FileName = string.Empty; // 파일 이름
        private int _FileSize = 0; // 파일 사이즈

        protected void Page_Load(object sender, EventArgs e)
        {

            _Id = Request["Id"]; // GET/POST 모두 다 받음
            // _Mode = Request["Mode"];

            if(!Page.IsPostBack) // 페이지 최초 로드 시
            {
                ViewState["Mode"] = Request["Mode"];

                if (ViewState["Mode"].ToString() == "Edit")
                    FormType = BoardWriteFormType.Modify;
                else if (ViewState["Mode"].ToString() == "Reply")
                    FormType = BoardWriteFormType.Reply;
                else
                    FormType = BoardWriteFormType.Write;

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
            var repo = new DbRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));

            txtTitle.Text = $"답변 : {note.Title}";
            txtContent.Text = $"\n\n작성일 : {note.PostDate}, 작성자 : '{note.Name}'\n-------------------------\n>"
                           + $"{note.Content.Replace("\n", "\n>")}\n-------------------------\n";

        }

        private void DisplayDataForModify()
        {
            var repo = new DbRepository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));

            txtName.Text = note.Name;
            txtEmail.Text = note.Email;
            txtHomepage.Text = note.Homepage;
            txtTitle.Text = note.Title;
            txtContent.Text = note.Content;

            // Encoding
            string encoding = note.Encoding;

            if (encoding == "Text")
                rdoEncoding.SelectedIndex = 0;

            else if (encoding == "Mixed")
                rdoEncoding.SelectedIndex = 2;
            
            else
                rdoEncoding.SelectedIndex = 1;

            // TODO : 파일 처리
        }

        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {
            pnlFile.Visible = !pnlFile.Visible;
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                if (ViewState["Mode"].ToString() == "Edit")
                    FormType = BoardWriteFormType.Modify;
                else if (ViewState["Mode"].ToString() == "Reply")
                    FormType = BoardWriteFormType.Reply;
                else
                    FormType = BoardWriteFormType.Write;

                // TODO : 파일업로드
                UploadFile();

                Note note = new Note();
                // Write 모드에서는 Id값이 필요없지만 Modify, Reply 모드는 필요함!
                note.Id = Convert.ToInt32(_Id); // 없으면 0
                note.Name = txtName.Text; // 필수
                note.Email = txtEmail.Text; // 필수
                note.Title = txtTitle.Text; // 필수, 추가할 것!
                note.Homepage = txtHomepage.Text;
                note.Content = txtContent.Text; // 필수
                note.FileName = _FileName;
                note.FileSize = _FileSize;
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
                        note.ModifyIp = Request.UserHostAddress;
                        // TODO : file 처리
                        note.FileName = ViewState["FileName"].ToString();
                        note.FileSize = Convert.ToInt32(ViewState["FileSize"]);

                        if (repo.UpdateNote(note) > 0)
                            Response.Redirect($"BoardView.aspx?Id={_Id}");
                        else
                            lblError.Text = "업데이트 실패, 암호를 확인하세요.";
                        break;

                    case BoardWriteFormType.Reply:
                        note.ParentNum = Convert.ToInt32(_Id);
                        repo.ReplyNote(note);
                        Response.Redirect("BoardList.aspx");
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

        // 파일 업로드 처리
        private void UploadFile()
        {
            // D:\GitRepository\StudyAspNet21\DotNetNote\DotNetNote\Files
            // Files 폴더가 있는 경로를 찾아줌
            _BaseDir = Server.MapPath("../Files");
            _FileName = string.Empty;
            _FileSize = 0;

            if(txtFileName.PostedFile != null)
            {
                if (txtFileName.PostedFile.FileName.Trim().Length > 0 && txtFileName.PostedFile.ContentLength > 0)
                {
                    // 변경 모드
                    if (FormType == BoardWriteFormType.Modify)
                    {
                        ViewState["FileName"] = Helpers.FileUtility.GetFileNameWithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        ViewState["FileSize"] = txtFileName.PostedFile.ContentLength;
                        // 업로드
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, ViewState["FileName"].ToString()));

                    }
                    // 입력, 댓글 모드
                    else
                    {
                        // 같은 파일명에 대한 처리
                        _FileName = Helpers.FileUtility.GetFileNameWithNumbering(_BaseDir, Path.GetFileName(txtFileName.PostedFile.FileName));
                        _FileSize = txtFileName.PostedFile.ContentLength;

                        // 업로드
                        txtFileName.PostedFile.SaveAs(Path.Combine(_BaseDir, _FileName));
                    }
                }
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