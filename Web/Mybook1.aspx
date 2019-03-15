<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="MyBook1.aspx.cs" Inherits="Web_MyBook1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        $(function () {
            $(".delete_book").click(function () {
                $("#delete_book_name").text($(this).attr("bookName"));
                $("#ContentPlaceHolder1_BookId").val($(this).attr("bookId"));
            });
        });
        $(function () {
            $(".update_book").click(function () {
                $("#update_book_name").text($(this).attr("bookName"));
                $("#ContentPlaceHolder1_BookId").val($(this).attr("bookId"));
            });
        });
    </script>
                

    
    <div class="modal fade" id="confirm-delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    您确定要删除此记录吗？
                </div>
                <div class="modal-body">
                    <span class="text-primary" id="delete_book_name"></span>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                    <asp:TextBox style="display: none;" ID="TextBox1" runat="server"></asp:TextBox>
                    
                    <asp:Button class="btn btn-danger btn-ok" ID="Button1" runat="server" Text="删除" OnClick="BtnDeleteBook_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="confirm-update" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    您确定要更新此记录吗？
                </div>
                <div class="modal-body">
                    <span class="text-primary" id="update_book_name"></span>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                    <asp:TextBox style="display: none;" ID="BookId" runat="server"></asp:TextBox>
                    
                    <asp:Button class="btn btn-danger btn-ok" ID="BtnUpdateBook" runat="server" Text="编辑" OnClick="BtnUpdateBook_Click" />
                </div>
            </div>
        </div>
    </div>

    <h2>
        <strong style="margin: 2%;"><asp:Label class="text-primary" ID="AccountName" runat="server" Text=""></asp:Label></strong>的图书

    </h2>
    <div id="page_cart" class="card">
        <table class="table table-hover text-center">
            <thead>
                <tr>
                    <th>序号</th>
                    <th>书名</th>
                    <th>作者</th>
                    <th>描述</th>
                    <th>封面</th>
                    <th>价格</th>
                    <th>类别</th>
                    <th>操作</th>

                </tr>
            </thead>
            <tbody>
                <%=MyBook %>
            </tbody>
        </table>
        <h1 class="text-center text-info">
            <asp:Label ID="EmptyInfo" runat="server" Text=""></asp:Label></h1>
        <br />
    </div>
</asp:Content>

