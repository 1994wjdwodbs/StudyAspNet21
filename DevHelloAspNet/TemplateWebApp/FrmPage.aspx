<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPage.aspx.cs" Inherits="TemplateWebApp.FrmPage" %>

<%@ Register Src="~/Navigatior.ascx" TagPrefix="nav" TagName="Navigator" %>
<%@ Register Src="~/Copyright.ascx" TagPrefix="cpy" TagName="Copyright" %>
<%@ Register Src="~/Category.ascx" TagPrefix="cat" TagName="Category" %>
<%@ Register Src="~/Catalog.ascx" TagPrefix="ctl" TagName="Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>웹사이트 프레임워크(뼈대) 만들기</title>
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12" style="background-color: aquamarine;">
                    <nav:Navigator runat="server" ID="UcNavigator" /> <!-- UC : 유닛 컨트롤 -->
                </div>
            </div>
            <div class="row" style="height: 200px;">
                <div class="col-md-4" style="background-color: antiquewhite;">
                    <cat:Category runat="server" ID="UcCategory" />
                </div>
                <div class="col-md-8" style="background-color: burlywood;">
                    <ctl:Catalog runat="server" ID="UcCatalog" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="background-color: cadetblue;">
                    <cpy:Copyright runat="server" ID="UcCopyright" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
