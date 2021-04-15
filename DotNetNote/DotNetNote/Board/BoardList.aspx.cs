using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardList : System.Web.UI.Page
    {
        private DbRepository _repo;

        // 검색/보통 모드 : true/false
        public bool SearchMode { get; set; } = false;

        public int RecordCount = 0; // 총 레코드 수
        public int PageIndex = 0; // 페이징 할 때 필요한 값, 현재 보여줄 페이지 번호

        public BoardList()
        {
            // repository : (어떤 것의 대량) 저장소[보관소]
            _repo = new DbRepository(); // SqlConnection 생성
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SearchMode)
            { // 보통 모드 (모든 레코드 수 출력)
                RecordCount = _repo.GetCountAll();
            }
            
            if (Request["Page"] != null)
            {
                PageIndex = Convert.ToInt32(Request["page"]) - 1;
            }
            else
            {
                PageIndex = 0; // 1 페이지
            }

            // TODO : 쿠키 사용해서 리스트 페이지번호 유지

            // 페이징 처리
            PagingControl.PageIndex = PageIndex;
            PagingControl.RecordCount = RecordCount;

            if(!Page.IsPostBack) // 최초 페이지 로드 
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            if (!SearchMode)
            { // 보통 모드 출력
                GrvNotes.DataSource = _repo.GetAll(PageIndex);
            }

            GrvNotes.DataBind(); // 데이터 바인딩
        }
    }
}