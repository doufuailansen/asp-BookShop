<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="MyBook.aspx.cs" Inherits="Web_MyBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <script>
        $(function () {
            $(".btn-delete").click(function () {
                console.log($(this).parent().attr("bookId"));
                $("#BookId").val($(this).parent().attr("bookId"));
            });
            //$(".btn_update").click(function() {
            //    window.location.href = "UpdateBookInfo.aspx?bookId=" + $(this).parent().attr("bookId");
            //});
        });
    </script>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">我的二手书</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="panel panel-default">
            <div class="panel-heading">
                  我的二手书列表
            </div>
            <!-- /.panel-heading -->
            <div class="panel-body">
                <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                       <thead>
                           <tr>
                                    <th>ID</th>
                                    <th>封面图片</th>
                                    <th>书名</th>
                                    <th>作者</th>
                                    <th>描述</th>
                                    <th>价格</th>
                                    <th>类别</th>
                                    <th>操作</th>
                             </tr>
                        </thead>
                            <tbody>
<%--                                <tr class="odd gradeX">
                                    <td disable="true">-</td>
                                    <td><asp:TextBox class="form-control" placeholder="图片路径" ID="TextBookImage" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox class="form-control" placeholder="书名" ID="TextBookName" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox class="form-control" placeholder="作者" ID="TextBookAuthor" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox class="form-control" placeholder="描述" ID="TextBookDescription" runat="server"></asp:TextBox></td>                                    
                                    <td style="width: 8%;"><asp:TextBox class="form-control" placeholder="价格" ID="TextBookPrice" runat="server"></asp:TextBox></td>
                                    <td style="width: 10%;">
                                        <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="typeName" DataValueField="id"></asp:DropDownList>

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [bookType]"></asp:SqlDataSource>

                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success"  ID="BtnAddBook" runat="server" Text="添加" OnClick="BtnAddBook_Click" />
                                    </td>
                                </tr>--%>
                               <%=MyBook %>

                            </tbody>
                        </table>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /#page-wrapper -->
    <div class="modal fade" id="confirm-delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="text-danger">您确定要删除这条记录吗？</h3>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                        <asp:TextBox Style="display: none;" ID="BookId" runat="server"></asp:TextBox>
                        <asp:Button class="btn btn-danger btn-ok"  ID="BtnDeleteBook" runat="server" Text="删除" OnClick="BtnDeleteBook_Click" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

