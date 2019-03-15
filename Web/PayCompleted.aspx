<%@ Page Language="C#" MasterPageFile="~/Web/Master/PayMasterPage3.master" AutoEventWireup="true" CodeFile="PayCompleted.aspx.cs" Inherits="Web_PayCompleted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="Page_success">
    <h1 ><img src="images/check.png" alt="✔" style="width: 80px; height: 80px"/>支付成功！
        
       <asp:Label class="notice" Style="color: #FF0000" ID="ErrorInfo" runat="server" Text=""></asp:Label>
    </h1>
    </div>

</asp:Content>

