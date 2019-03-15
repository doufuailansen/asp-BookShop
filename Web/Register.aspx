<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Web.WebRegister" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <title>注册</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/register.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="images/2.png" />
    <script src="js/jQuery-1.11.3.js"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            // 注册按钮的条件
            var isOk = [0, 0, 0, 0, 0, 0];

            // 判断是否可以点击注册
            var enbaleBtnReg = function () {
                for (var i = 0; i < 6; i++) {
                    if (isOk[i] == 0) {
                        $("#btnRegister").attr("disabled", true);
                        return;
                    }
                }
                $("#btnRegister").removeAttr("disabled");
            };

            // 用户名验证
            $("#TextUsername").blur(function () {
                var nameReg = /^[a-zA-Z0-9_]{1,}$/;
                if (!$(this).val().match(nameReg)) {
                    $(this).popover('show');
                    isOk[0] = 0;
                } else {
                    isOk[0] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                }
            });
            // 密码验证
            $("#TextPassword").blur(function () {
                var pwdReg = /^[A-Za-z0-9_]+$/;
                if (!$(this).val().match(pwdReg)) {
                    isOk[1] = 0;
                    $(this).popover('show');
                } else {
                    isOk[1] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                }
            });
            // 重复密码验证
            $("#TextRepassword").blur(function () {
                if ($(this).val() == $("#TextPassword").val()) {
                    isOk[2] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                } else {
                    isOk[2] = 0;
                    $(this).popover('show');
                }
            });
            // 电子邮件验证
            $("#TextEmail").blur(function () {
                var emailReg = /^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$/;
                if (!$(this).val().match(emailReg)) {
                    isOk[3] = 0;
                    $(this).popover('show');
                } else {
                    isOk[3] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                }
            });
            // 问题验证
            $("#TextQuestion").blur(function () {
                if ($(this).val().length > 0) {
                    isOk[4] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                } else {
                    isOk[4] = 0;
                    $(this).popover('show');
                }
            });
            // 回答验证
            $("#TextAnswer").blur(function () {
                if ($(this).val().length > 0) {
                    isOk[5] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                } else {
                    isOk[5] = 0;
                    $(this).popover('show');
                }
            });
            

            // 注册验证
            $("#btnRegister").mousemove(function () {
                $("#TextUsername").blur();
                $("#TextPassword").blur();
                $("#TextRepassword").blur();
                $("#TextEmail").blur();
                $("#TextQuestion").blur();
                $("#TextAnswer").blur();
                enbaleBtnReg();
            });

        });

        // 回车注册事件取消
        function EnterKeyFilter() {
            if (window.event.keyCode == 13) {
                event.returnValue = false;
                event.cancel = true;
            }
        }
    </script>
</head>

<body onkeydown="javascript:EnterKeyFilter();">
       <div id="header">
            <div class="top-nav">
                <div class ="welcome">
                    <label>欢迎进入坐标系，请先 </label>
                    <a href ="Login.aspx">登录</a>
                    <label>或 </label>
                    <a href="Register.aspx">注册</a>
                </div>
            </div>

                <div class="name">
                    <img src ="images/3.png" alt="网上书店"/>
                    <h2>用户注册</h2>
                </div>
            <div class ="back">
                <a href = "Main.aspx">返回主页</a>
            </div>
        </div>
    <div class="container">
        <div id ="nav">
            <ul id="navBar">
                <li>
                    <img src="images/first.png"alt="1" />
                    设置用户名</li>
                <li>
                    <img src="images/second.png"alt="2" />设置密码</li>
                <li>
                    <img src="images/third.png"alt="3" />设置邮箱</li>
                <li>
                    <img src="images/fourth.png"alt="4" />设置密保问题</li>
            </ul>
        </div>
        <div id="form">
          
            <form class="form-horizontal" role="form" runat="server">
                <table class ="register-table">
                    <th colspan ="2" class="title">
                        <h1><asp:Label style="color: #FF0000" ID="ErrorInfo" runat="server" Text=""></asp:Label>
                        </h1>
                    </th>
                    <tr>
                        <td class ="left">
                            <label>用户名：</label>
                        </td>
                        <td class ="right">
                            <asp:TextBox class="form-control" ID="TextUsername" runat="server" placeholder="请输入用户名" data-placement="right" data-content="只可以是数字字母和下划线" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class ="left">
                            <label>密码：</label>
                        </td>
                        <td class ="right">
                            <asp:TextBox type="password" class="form-control" ID="TextPassword" runat="server" placeholder="请输入密码" data-placement="right" data-content="由数字 字母和下划线组成" MaxLength="16"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class ="left">
                            <label>重复密码：</label>
                        </td>
                        <td class ="right">
                            <asp:TextBox type="password" class="form-control" ID="TextRepassword" runat="server" placeholder="再次输入密码" data-placement="right" data-content="再次输入上一次的密码" MaxLength="16"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class ="left">
                            <label>邮箱：</label>
                        </td>
                        <td class ="right">
                            <asp:TextBox type="email" class="form-control" ID="TextEmail" runat="server" placeholder="请输入邮箱" data-placement="right" data-content="例：example@domain.com"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class ="left">
                            <label>问题：</label>
                        </td>
                        <td class ="right">
                            <asp:TextBox type="text" class="form-control" ID="TextQuestion" runat="server" placeholder="请输入一个找回密码的问题" data-placement="right" data-content="找回密码的问题"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class ="left">
                            <label>回答：</label>
                        </td>
                        <td class ="right">
                            <asp:TextBox type="text" class="form-control" ID="TextAnswer" runat="server" placeholder="请输入回答" data-placement="right" data-content="找回密码的回答"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class ="left">
                            <label>店铺名称：</label>
                        </td>
                        <td class ="right">
                            <asp:TextBox disabled="true" type="text" class="form-control" ID="TextShopName" runat="server" placeholder="请输入店铺名称" data-placement="right" data-content="不能为空!"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class ="left">
                            <label>店铺描述：</label>
                        </td>
                        <td class ="right">
                            <asp:TextBox disabled="true" type="text" class="form-control" ID="TextShopDescription" runat="server" placeholder="请输入店铺描述" data-placement="right" data-content="店铺详细情况"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">                            
                            <asp:CheckBox ID="BeSeller" runat="server"  AutoPostBack="True" OnCheckedChanged="BeSeller_CheckedChanged" Text="成为商家?" />
                        </td>
                        <td class="register">
                        <asp:Button ID="btnRegister" class="btn btn-danger" runat="server" Text="注册" OnClick="btnRegister_Click" Height="34px" Width="78px" />
                        <asp:HyperLink class="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/Web/Login.aspx" >已有账号？直接登录</asp:HyperLink>
                        <button type="reset" class="btn btn-default" style="width: 78px; height: 34px">重置</button>
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <div id="footer">
        <span>制作班级：软件1501 </span><br />
        <span>&copy; 胡家欣 薛宇莹 张诗渊 版权所有</span>
    </div>
</body>
</html>
