<%@ Page Language="C#" MasterPageFile="~/Web/Master/MasterPage2.master" AutoEventWireup="true" CodeFile="OldBookForBidding.aspx.cs" Inherits="Web_OldBookForBidding" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page_main">
        <div class="row">
            <div >
                <div id="book_bidding" class="text-center">
                    <h2 class="text-success">竞拍图书</h2>
                    <%=OldBiddingBook %>
                </div>               
            </div>
        </div>
    </div>
</asp:Content>