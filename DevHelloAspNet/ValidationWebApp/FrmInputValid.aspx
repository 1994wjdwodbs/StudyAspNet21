<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInputValid.aspx.cs" Inherits="ValidationWebApp.FrmInputValid" %>

<%@ Register Src="~/Copyright.ascx" TagPrefix="uc1" TagName="Copyright" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>유효성검사</title>
    <script>
        function CheckLogin() {
            var varAge = parseInt(document.getElementById("txtAge").Value);
            if (varAge < 1 || varAge > 150) {
                alert("나이는 1 ~ 150 사이 입니다.");
                document.getElementById("txtAge").focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div>
            <!--
            <input type="text" id="txtAge" name="textAge" value="0" />(1~150)<br />
            <input type="submit" value="체크" />
            <hr />-->

            <asp:TextBox ID="TxtAge" runat="server" />
            <asp:RangeValidator ID="ValAge" runat="server" ControlToValidate="TxtAge"
                ErrorMessage="1 ~ 150 만 입력" MinimumValue="1" MaximumValue="150" Type="Integer"
                ForeColor="DarkRed" Display="Dynamic" SetFocusOnError="true"/>
            <asp:RequiredFieldValidator ID="ValAge2" runat="server" ControlToValidate="TxtAge"
                ErrorMessage="나이를 입력" ForeColor="Red" Display="Dynamic" />(필수)<br />

            <asp:TextBox ID="TxtScore" runat="server" />
            <asp:RangeValidator ID="ValScore" runat="server" ControlToValidate="TxtScore"
                ErrorMessage="A ~ F 만 입력" MinimumValue="A" MaximumValue="F" Type="String"
                Display="Dynamic" SetFocusOnError="true"/>(필수)<br />

            <asp:TextBox ID="TxtUserId" runat="server" />
            <asp:RequiredFieldValidator ID="ValUserId" runat="server" ControlToValidate="TxtUserId"
                ErrorMessage="아이디를 입력하세요" ForeColor="Red" Display="Static"/>(필수)<br />

            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"/>
            <asp:RequiredFieldValidator ID="ValPassword" runat="server" ControlToValidate="TxtPassword"
                ErrorMessage="암호를 입력하세요" ForeColor="Red" Display="Dynamic"/>(필수)<br />

            <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password"/>
            <asp:RequiredFieldValidator ID="ValConfirmPassword" runat="server" ControlToValidate="TxtConfirmPassword"
                ErrorMessage="암호 확인을 입력하세요" ForeColor="Red" Display="Dynamic"/>(필수)<br />
            <asp:CompareValidator ID="ValComparePassword" runat="server" ControlToValidate="TxtPassword"
                ControlToCompare="TxtConfirmPassword" SetFocusOnError="true" ForeColor="DarkRed"
                ErrorMessage="암호 불일치!" Display="Dynamic" /><br />

            <asp:TextBox ID="TxtEmail" runat="server" />
            <asp:RegularExpressionValidator ID="ValEmail" runat="server" ControlToValidate="TxtEmail" 
                ErrorMessage="이메일을 정확히 입력하세요" Display="Dynamic" ForeColor="Red"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/><br />

            <!-- 유효성 검사 : 오류 요약 -->
            <asp:ValidationSummary ID="ValSummory" runat="server" ShowMessageBox="true"
                ShowSummary="true" DisplayMode="BulletList" />            
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                ShowSummary="false" DisplayMode="List" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="true"
                ShowSummary="false" DisplayMode="SingleParagraph" />

            <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="회원 가입"/>


        </div>
    </form>

    <uc1:Copyright runat="server" ID="COpyrightUserControl"/>
</body>
</html>
