using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetNote.Models
{
    public enum BoardWriteFormType
    {
        Write,      // 글 쓰기 모드
        Modify,     // 글 수정 모드
        Reply       // 댓글 모드
    }

    public enum ContentEncodingType
    {
        Text,       // 일반 텍스트 모드
        Html,       // HTML 입력 모드
        Mixed       // HTML 입력 + 엔터키 모드
    }
}