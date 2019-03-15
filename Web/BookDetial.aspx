<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="BookDetial.aspx.cs" Inherits="Web.WebBookDetial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $(function () {
            // 数量减按钮
            $("#btnNumberReduce").click(function () {
                var number = $("#ContentPlaceHolder1_BuyNumber");
                console.log(number.val());
                if (number.val() <= 1) {
                    number.val("1");
                } else {
                    number.val(number.val() - 1);
                }
            });

            // 数量加按钮
            $("#btnNumberAdd").click(function () {
                var number = $("#ContentPlaceHolder1_BuyNumber");
                console.log(number.val());
                if (number.val() <= 0) {
                    number.val("0");
                } else {
                    number.val(parseInt(number.val()) + 1);
                }
            });
        });
        $(function () {
            $(".addTo").click(function () {

            });
        });
    </script>

    <div class="modal fade" id="confirm-add" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    恭喜!
                </div>
                <div class="modal-body">
                    <span class="text-primary" id="delete_book_name">已成功加入购物车！</span>
                </div>
                <div class="modal-footer">
                    <%--<button type="button" class="btn btn-default" data-dismiss="modal">完成</button>--%>
                    <asp:Button class="btn btn-danger addTo" type="button" ID="BtnAddToCart" runat="server" text="完成" OnClick="BtnAddToCart_Click" />
                </div>
            </div>
        </div>
    </div>
    <div id="page_bookDetail">
        <div class="row">
            <div class="col-md-3 clean">
                <img alt="商品预览图" class="book_img" src="<%=BookImage %>" />
            </div>
            <div class="col-md-8">
                <div class="row">
                    <div class="col-md-offset-1">
                        <h2 class="">《<%=BookTitle %>》</h2>
                        <p><%=BookDescription %></p>
                        <div class="row">
                            <div class="col-md-6">
                                <span class="text-primary">作者： </span><small class="text-info"><%=BookAuthor %></small>
                            </div>
                            <div class="col-md-6">
                                <span class="text-primary">图书分类： </span><small class="text-info"><%=BookType %></small>
                            </div>
                        </div>
                        
                        <hr class="bg-info" />
                        <blockquote class="bg-warning text-danger">
                            <h5 class="text-primary">当前价格</h5>
                            ￥ <font size="7"><%=BookPrice %></font>
                        </blockquote>
                        <div class="row">
                            <div class="col-md-2"><font size="4">数  量：</font></div>
                            <div class="col-md-3">
                                <div class="row">
                                    <div class="col-md-9">
                                        <div class="input-group">
                                            <span class="input-group-btn">
                                                <input type="button" class="btn btn-default" id="btnNumberReduce" value=" - " />
                                            </span>
                                            <asp:TextBox class="form-control" ID="BuyNumber" Text="1" runat="server"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <input type="button" class="btn btn-default" id="btnNumberAdd" value="+" />
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <input class="btn btn-danger addTo" data-toggle="modal" data-target="#confirm-add" value="加入购物车" type="button" />
                                <%--<asp:Button class="btn btn-danger addTo" type="button" data-toggle="modal" data-target="#confirm-add" ID="BtnAddToCart" runat="server" text="加入购物车" OnClick="BtnAddToCart_Click" />--%>
                                <asp:HyperLink class="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/Web/Cart.aspx">去购物车..</asp:HyperLink>
                            </div>
                        </div>
                        <br/>
<%--                        <div>
                            <asp:Label class="text-danger" ID="ErrorInfo" runat="server" Text=""></asp:Label>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

