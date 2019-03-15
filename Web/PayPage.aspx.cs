using common;
using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_PayPage : System.Web.UI.Page
{
    // public int bookcount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitialPage();
        }
    }
    private void InitialPage()
    {
        Account account = (Account)Session["account"];
        if (account == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }
        else
        {
            TextAddr.Text = account.Address;
            TextTel.Text = account.Telephone;


        }
    }

    protected void pay_Click(object sender, EventArgs e)
    {
        Account account = (Account)Session["account"];
        int Id = (int)Session["certainBookId"];
        //int bookcount = (int)Session["certainBookCount"];

        BuyDao buydao = new BuyDao();
        buydao.AddNewOrder(Id);




        Response.Redirect("PayCompleted.aspx");
    }


    protected void quit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");

    }

}