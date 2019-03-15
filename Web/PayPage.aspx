<%@ Page Language="C#" MasterPageFile="~/Web/Master/PayMasterPage3.master" AutoEventWireup="true" CodeFile="PayPage.aspx.cs" Inherits="Web_PayPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
        <div id="Page_orderform">
            <table class="order-form">
                <tr class="order-title">
                    <td colspan="2">
                        <label>收货信息</label>
                    </td>
                </tr>
                <tr>
                    <td class="td-left">
                        <label>地址：</label>
                    </td>
                    <td class="td-right">
                        <asp:TextBox disabled="true" class="form-control" ID="TextAddr" runat="server" placeholder="暂无地址信息"></asp:TextBox>
                    </td>
                </tr>
                <tr class="info">
                    <td class="td-left">
                        <label>电话：</label>
                    </td>
                    <td class="td-right">
                        <asp:TextBox disabled="true" class="form-control" ID="TextTel" runat="server" placeholder="暂无电话信息"></asp:TextBox>
                    </td>
                </tr>
                </table>
            <br />
                <table class="pay">
                <tr class="order-title">
                    <td colspan="2">
                        <label>支付方式</label>
                    </td>
                </tr>
                <tr>
                    <td class="center">
                        <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" />
                        <img src="images/zhifubao.png" alt="支付宝" style="width: 100px; height: 100px"/>
                    </td>
                    <td class="center">
                        <asp:RadioButton ID="RadioButton2" runat="server" />
                        <img src="images/weixin.png" alt="微信" style="width: 100px; height: 100px"/>
                    </td>
                </tr>
                <tr>
                    <td class="center">
                        <asp:Button class="btn btn-danger" ID="pay" Text="下单" OnClick="pay_Click" runat="server"/>
                    </td>
                    <td  class="center">
                        <asp:Button class="btn btn-default" ID="quit" Text="取消" OnClick="quit_Click" runat="server"/>
                    </td>
                </tr>
                </table>


        </div>

</asp:Content>
