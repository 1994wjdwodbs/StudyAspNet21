<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmSqlDataSource.aspx.cs" Inherits="DataControlWebApp.FrmSqlDataSource" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>데이터 소스 컨트롤</title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <!-- 항목 입력 or 데이터소스(바인딩) 선택 -->
            <asp:DropDownList ID="CboMemoName" runat="server" DataSourceID="SdsMemoName" DataTextField="Name" DataValueField="Num"></asp:DropDownList>
            <!-- 데이터소스(바인딩) 안하면 안나옴 -->
            <asp:SqlDataSource ID="SdsMemoName" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnString %>" 
                SelectCommand="SELECT TOP (5) Name, Num FROM [Memos]"></asp:SqlDataSource>
            <asp:Chart ID="Chart1" runat="server">
                <Series>
                    <asp:Series Name="Series1"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </form>
</body>
</html>
