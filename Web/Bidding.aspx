<%@ Page Language="C#" MasterPageFile="~/Web/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="Bidding.aspx.cs" Inherits="Web_Bidding" %>

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
    </script>
    <div id="page_biddingDetail">
        <div class="row">
            <div class="col-md-3 ">
                <div class="image">
                    <img alt="商品预览图" class="book_img" src="<%=BookImage %>" />
                </div>
                <div class="seller">
                    <label>送拍人：</label>
                    <a href="#" class="btn btn-link"><%=BookSeller %></a>
                </div>
            </div>
            <div class="col-md-6">
                <div class="row">
                    <div class="col-md-offset-1">
                        <h2 class="">《<%=BookTitle %>》</h2>
                        <p><%=BookDescription %></p>
                        <div class="row">
                            <div class="col-md-4">
                                <span class="text-primary">作者： </span><small class="text-info"><%=BookAuthor %></small>
                            </div>
                            <div class="col-md-4">
                                <span class="text-primary">图书分类： </span><small class="text-info"><%=BookType %></small>
                            </div>
                        </div>
                        
                        <hr class="bg-info" />
                        <blockquote class="bg-warning text-danger">
                            <div class="bidding-now">
                                <p>正在</br>竞拍
                                </p>
                            </div>
                            <div class="info">
                                <form id="form1" runat="server">
                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                      <ContentTemplate>
                                        <asp:Timer ID="Timer1" runat="server" Interval="10000" ontick="Timer1_Tick">
                                        </asp:Timer>
                                      </ContentTemplate>
                                      </asp:UpdatePanel>
                                </form>
<%--                                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>
                                    <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
                                    </asp:Timer>--%>
                                    <asp:Label ID="Label1" class="countDown" runat="server" Text="倒计时："></asp:Label>
                                <label>       共<%=number %>人参与竞拍</label>
                            </div>
                            <%--<h5 class="text-primary">当前价格</h5>
                            ￥ <font size="7"><%=BookPrice %></font>--%>
                        </blockquote>
                        <div class="wrap">
                            <div class="price">
                                <label >当前价： </label>
                                <span class="text-danger">￥ <%=BookNewPrice %></span>
                            </div>
                            <div class="price">
                                <label>起拍价：</label>
                                <span  class="text-danger">￥ <%=BookOldPrice %></span>
                            </div>
                        </div>
                        <div class="buy">
                            <asp:TextBox class="form-control" ID="NewPrice" runat="server" placeholder="请出价.."></asp:TextBox>
                            <asp:Button class="btn btn-danger" ID="BtnBuy" runat="server" Text="我要出价"  OnClick="btnBuy_Click"/>
                        </div>
                       <%-- <div class="row">
                            <div class="col-md-2"><font size="5">数  量：</font></div>
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
                                <asp:Button class="btn btn-danger" ID="BtnAddToCart" runat="server" Text="加入购物车" OnClick="BtnAddToCart_Click" />
                                <asp:HyperLink class="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/Web/Cart.aspx">去购物车..</asp:HyperLink>
                            </div>
                        </div>--%>
                        <br/>
                        <div>
                            <asp:Label class="text-danger" ID="ErrorInfo" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 ">
                <div class="more">
                    <div class="header">
                        <h3>更多拍卖</h3>
                    </div>
                    <ul class="list">
                        <li class="item">
                            <div class="img">
                                <img />
                            </div>
                            <div class="title">
                                <a href="#"></a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

