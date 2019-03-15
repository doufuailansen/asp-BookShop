<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="MyShopInfo.aspx.cs" Inherits="Web_MyShopInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page_account" class="card">
            <%--<br/>--%>
        <div class="row">
            <div class="text-center">
                <h1>店铺信息<small> --XYZ <asp:Label style="color: #FF0000" ID="ErrorInfo" runat="server" Text=""></asp:Label></small></h1>
            </div>
        </div>
            <br />
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <label class="col-sm-2 control-label">用&nbsp;&nbsp;户&nbsp;&nbsp;名：</label>
                    <div class="col-sm-9">
                        <asp:TextBox disabled="true" class="form-control" ID="TextUsername" runat="server" placeholder="请输入用户名"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">店&nbsp;&nbsp;铺&nbsp;&nbsp;名：</label>
                    <div class="col-sm-9">
                        <asp:TextBox disabled="true" class="form-control" ID="TextShopname" runat="server" placeholder=""></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;箱：</label>
                    <div class="col-sm-9">
                        <asp:TextBox type="email" class="form-control" ID="TextEmail" runat="server" placeholder="请输入邮箱"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">店&nbsp;铺&nbsp;活&nbsp;动：</label>
                    <div class="col-sm-9">
                        <asp:TextBox type="text" class="form-control" ID="TextActivity" runat="server" placeholder="请输入活动简介"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group">
                    <label class="col-sm-2 control-label">店&nbsp;铺&nbsp;简&nbsp;介：</label>
                    <div class="col-sm-9">
                        <asp:TextBox type="text" class="form-control" ID="TextShopDescription" runat="server" placeholder="暂无" Height="115px"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-6">
                        <asp:Button ID="BtnUpdate" class="btn btn-default" runat="server" Text="更新" OnClick="BtnUpdate_Click" />
                        <asp:Label class="text-success" ID="ResultInfo" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <button type="button" onclick="javascript:history.go(-1);" class="btn btn-default">返回</button>
                    </div>
                </div>
            </div>
        <br/>
    </div>
</asp:Content>

