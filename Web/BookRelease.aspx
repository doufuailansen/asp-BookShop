<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="BookRelease.aspx.cs" Inherits="Web_MyBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="Page-wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">发布二手图书详细信息</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        图书信息 <small><b>
                            <asp:Label ID="ResultInfo" runat="server" Text=""></asp:Label></b></small>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="form-group">
                            <label>书名</label>
                            <asp:TextBox class="form-control" placeholder="书名" ID="TextName" runat="server"></asp:TextBox>
                            <p class="help-block">图书名称.</p>
                        </div>
                        <div class="form-group">
                            <label>作者</label>
                            <asp:TextBox class="form-control" placeholder="作者" ID="TextAuthor" runat="server"></asp:TextBox>
                            <p class="help-block">图书作者.</p>
                        </div>
                        <div class="form-group">
                            <label>图片</label>
                            <asp:TextBox class="form-control" placeholder="图片" ID="TextImage" runat="server"></asp:TextBox>
                            <p class="help-block">图片的地址.</p>
                        </div>
                        <div class="form-group">
                            <label>价格</label>
                            <asp:TextBox class="form-control" placeholder="价格" ID="TextPrice" runat="server"></asp:TextBox>
                            <p class="help-block">图书价格.</p>
                        </div>
                        <div class="form-group">
                            <label class="bidding">参与竞拍？</label>
                            <asp:RadioButton ID="RadioButton1" class="isbidding" runat="server" AutoPostBack="True" GroupName="bidding" CssClass="isbidding" Width="22px" OnClick="RadioButton1_Click"/>是&nbsp&nbsp&nbsp
                            <asp:RadioButton ID="RadioButton2" class="isbidding" checked="true" runat="server" AutoPostBack="True" GroupName="bidding" Width="20px" OnClick="RadioButton2_Click"/> 否                    
                            
                        &nbsp;</div>
                        <div class="form-group">
                            <label>描述</label>
                            <asp:TextBox TextMode="multiline" placeholder="图书简介" class="form-control" Rows="3" ID="TextDescription" runat="server"></asp:TextBox>
                            <p class="help-block">图书的介绍.</p>
                        </div>
                        <div class="form-group">
                            <label for="types">图书类别</label>
                            <asp:DropDownList class="form-control" ID="DropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="typeName" DataValueField="id"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [bookType]"></asp:SqlDataSource>
                        </div>

                    </div>
                    <!-- /.panel-body -->
                </div>
                <br />
                <!-- /.row -->
        <div class="text-center">
            <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="发布" OnClick="BtnUpdate_Click" />
            <button type="reset" onclick="javascript:window.history.go(-1);" class="btn btn-default">返回</button>
        </div>
    </div>
            <!-- /#page-wrapper -->
</asp:Content>

