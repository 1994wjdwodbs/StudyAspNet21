<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="FirstWebApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ASP.NET [웹폼] 웹페이지</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hello ASP~!!</h1>
        </div>
        <input id="TxtOther" name="TxtOther" type="text" runat="server"/>
        <!-- 
            id 속성 "애플리케이션의 고유 영역 식별자", "레이블과 인풋 컨트롤을 연결하기 위한 식별자", "표와 표 설명을 연결하기 위한 식별자"
            : 고유한 식별을 목적으로 하는 경우 사용합니다.

            class 속성 "재사용을 목적으로 하는 애플리케이션 컴포넌트/레이아웃/헬퍼 식별자"
            : 재사용을 목적으로 하는 경우 사용합니다.

            name 속성 "폼 전송 이벤트 발생 시, 서버로 데이터를 전송하기 위한 식별자"
            (JavaScript 프로그래밍 코드를 사용하여 <select> 요소의 name 속성 값을 식별하여 사용자가 선택한 값을 가져와 출력할 수 있습니다.)
            : form 컨트롤 요소의 값(value)을 서버로 전송하기 위해 필요한 속성입니다.
        -->
        <asp:TextBox ID="TxtDisplay" runat="server"></asp:TextBox>
        <asp:Button ID="BtnClick" runat="server" OnClick="BtnClick_Click" Text="클릭" /><br />
        <asp:Label ID="LblResult" runat="server"></asp:Label>
        <br/>

    </form>
</body>
</html>
