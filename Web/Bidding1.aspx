<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bidding1.aspx.cs" Inherits="Web_Bidding1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>坐标系·网上书店</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/index.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="images/2.png" />
    <link href="try/bootstrap/twitter-bootstrap-v2/docs/assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://www.daimajiayuan.com/download/jquery/jquery-1.10.2.min.js"></script>  
    <script type="text/javascript" src="http://cdn.bootcss.com/bootstrap-select/2.0.0-beta1/js/bootstrap-select.js"></script>   
    <script type="text/javascript" src="<%=ResolveUrl("../js/jQuery-1.11.3.js") %>"></script>
    <script src="<%=ResolveUrl("js/bootstrap.min.js") %>" type="text/javascript"></script>
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
</head>
<body>
    <form id="form1" runat="server" >
        <div id="header">
            <div class="top-nav">
                <div class ="list">    
                <button class="btn btn-default dropdown-toggle" type="button" id="DropDownList1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                       网上书店
                       <span class="caret"></span>
                 </button>     
                  <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                    <li><a href="main.aspx">正版商城</a></li>
                    <li><a href="OldBookMain.aspx">二手商城</a></li>
                  </ul>                     
            </div>
                    <div class="btn-group">
                        <asp:Button class="btn btn-default" ID="btn_Login" runat="server" Text="登录" OnClick="btnLogin_Click"/>
                        <asp:Button class="btn btn-default" ID="btn_Register" runat="server" Text="注册" OnClick="btnRegister_Click" />
                        <asp:Button class="btn btn-default" ID="btn_cart" runat="server" Text="购物车" OnClick="btnCart_Click" />
                    <div class="list ">
                    <button class="btn btn-default dropdown-toggle" type="button" id="DropDownList2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                       用户信息
                       <span class="caret"></span>
                    </button>
                      <ul class="dropdown-menu" aria-labelledby="dropdownMenu1">
                        <li><a href="#">个人信息</a></li>
                        <li><a href="#">店铺信息</a></li>
                      </ul>  
                    </div>
                    </div>
            </div>

                <div class="name">
                    <img src ="images/3.png" alt="网上书店"/>
                </div>


                <div class="search">
                  <asp:TextBox ID="Key_Word"  class="form-control" runat="server"></asp:TextBox>
            <asp:Button ID="BtnSearch"  class="btn btn-warning" type="submit" runat="server" Text=" 搜 索 " BackColor="#DEA774" BorderColor="#666666" OnClick="BtnSearch_Click" />
                </div>

        </div>

        <div id="navigation">
            <ul id="navBar">
                <li>
                    <a href="./OldBookMain.aspx">二手商城</a>
                </li>
                <li>
                    <a href="./OldBookForBidding.aspx">竞拍图书</a>
                </li>
                <li>
                    <a href="./BookRelease.aspx">我要卖书</a>
                </li>
                <li>
                    <a href="./Mybook1.aspx">我的图书</a>
                </li>
                <div class="clean"></div>
            </ul>
        </div>

        <div id="main" class="container">
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

                                  <asp:ScriptManager ID="ScriptManager1" runat="server">
                                  </asp:ScriptManager>
                                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                      <ContentTemplate>
                                        <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
                                        </asp:Timer>
                                           <asp:Label ID="Label1" class="countDown" runat="server" Text="倒计时："></asp:Label>
                                      </ContentTemplate>
                                      </asp:UpdatePanel>

<%--                                <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>
                                    <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
                                    </asp:Timer>--%>
                                   
                                <label>       共<%=BookNumber %>人参与竞拍</label>
                            </div>
                            <%--<h5 class="text-primary">当前价格</h5>
                            ￥ <font size="7"><%=BookPrice %></font>--%>
                        </blockquote>
                        <div class="wrap">
                            <div class="price">
                                <label >当前价： </label>
                                <span class="text-danger">￥ <%=BookNewPrice %></span>
                                <label>出价人：</label>
                                <span class="text-danger"><%=BookBuyer %></span>
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
                        <%=More %>                 
                </div>
            </div>
        </div>
    </div>
        </div>

        <div id="footer">
            <span>制作班级：软件1501 </span><br />
            <span>&copy; 胡家欣 薛宇莹 张诗渊 版权所有</span>
        </div>
    </form>
</body>
</html>