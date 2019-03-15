﻿<%@ Page Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="ShopManage.aspx.cs" Inherits="Web_ShopManage" %>

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

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">

        <strong style="margin: 2%;"><asp:Label class="text-primary" ID="AccountName" runat="server" Text=""></asp:Label></strong> 的店铺

           </h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="panel panel-default">
            <div class="panel-heading">
                  图书列表
            </div>
            <!-- /.panel-heading -->
            <div class="panel-body">
                <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                       <thead>
                           <tr>
                                    <th>ID</th>
                                    <th>书名</th>
                                    <th>作者</th>
                                    <th>描述</th>
                                    <th>封面图片</th>
                                    <th>价格</th>
                                    <th>类别</th>
                                    <th>操作</th>
                             </tr>
                        </thead>
                            <tbody>
                                <tr class="odd gradeX">
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
                                </tr>
                               <%=MyBook %>

                            </tbody>
                        </table>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /#page-wrapper -->
        <h1 class="text-center text-info">
            <asp:Label ID="EmptyInfo" runat="server" Text=""></asp:Label></h1>
        <br />
</asp:Content>

