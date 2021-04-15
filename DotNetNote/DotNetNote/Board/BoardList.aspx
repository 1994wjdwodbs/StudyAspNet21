<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BoardList.aspx.cs" Inherits="DotNetNote.Board.BoardList" %>

<%@ Register Src="~/Controls/PagingControl.ascx" TagPrefix="uc1" TagName="PagingControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center">게시판</h3>
    <span>글 목록 - 완성형 게시판</span>
    <hr />

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:Literal ID="LblTotalRecord" runat="server"></asp:Literal>
                <!-- 테이블 : [번호][제목][작성자] -->
                <asp:GridView ID="GrvNotes" runat="server" AutoGenerateColumns="false"
                    DataKeyNames="Id" CssClass="table table-bordered table-hover table-striped table-responsive">
                    <Columns>
                        <asp:TemplateField 
                            HeaderText="번호"
                            HeaderStyle-Width="50px"
                            ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <%# 
                                    // Eval:
                                           //     데이터 바인딩 식을 평가합니다.
                                           //
                                           //  매개 변수:
                                           //      expression:
                                           //      컨테이너에서 바인딩된 컨트롤 속성에 배치 하는 공용 속성 값의 탐색 경로입니다.
                                           //
                                           //  반환 값:
                                           //      데이터 바인딩 식의 계산에서 생성 되는 개체입니다.
                                           //
                                           //  예외:
                                           //      T:System.InvalidOperationException:
                                           //      에 포함 된 컨트롤에 대해서만 데이터 바인딩 메서드를 사용할 수는 System.Web.UI.Page합니다.
                                            // == DataBinder.Eval(Container.DataItem, "Id")
                                            Eval("Id")
                                %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField 
                            HeaderText="제목"
                            HeaderStyle-Width="350px" 
                            ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:HyperLink ID="LnkTitle" runat="server" NavigateUrl='<%# "BoardView.aspx?Id=" + Eval("Id") %>'>
                                    <%# Eval("Title") %>
                                </asp:HyperLink>
                                <%# Helpers.BoardLibrary.FuncNew(Eval("PostDate"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="파일"
                            HeaderStyle-Width="70px"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Eval("FileName") %>
                                <%--<%# Helpers.BoardLibrary.FuncFileDownSingle(
                                    Convert.ToInt32(Eval("Id")), 
                                    Eval("FileName").ToString(), 
                                    Eval("FileSize").ToString()) %>--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField
                            DataField="Name"
                            HeaderText="작성자"
                            HeaderStyle-Width="60px"
                            ItemStyle-HorizontalAlign="Center" />

                        <asp:TemplateField 
                            HeaderText="작성일"
                            ItemStyle-Width="90px"
                            ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Helpers.BoardLibrary.FuncShowTime(
                                    Eval("PostDate")) %>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:BoundField 
                            DataField="ReadCount" 
                            HeaderText="조회수"
                            ItemStyle-HorizontalAlign="Right"
                            HeaderStyle-Width="60px">
                         </asp:BoundField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <div class="text-center">
                    <uc1:PagingControl runat="server" ID="PagingControl" />
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col">
                <div class="text-right">
                    <a href="BoardWrite.aspx" class="btn btn-primary">글쓰기</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
