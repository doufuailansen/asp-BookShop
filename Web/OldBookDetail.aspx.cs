using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_OldBookDetail : System.Web.UI.Page
{
    public string BookTitle { get; set; }
    public string BookDescription { get; set; }
    public string BookImage { get; set; }
    public string BookAuthor { get; set; }
    public double BookPrice { get; set; }
    public string BookType { get; set; }
    public int BookId { get; set; }
    public Boolean IsBidding { get; set; }
    public string Seller { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // 获取get的传参
            BookId = Convert.ToInt32(Request.QueryString["id"]);
        }
        catch (Exception)
        {
            Response.Redirect("./Main.aspx");
        }
        // id值不可为负数
        if (BookId <= 0)
        {
            Response.Redirect("./Main.aspx");
        }

        OldBookDao bookDao = new OldBookDao();
        // 获取图书详情
        OldBookInfo bookInfo = bookDao.GetBookDetailById(BookId);
        // 展示到页面
        BookAuthor = bookInfo.Author;
        BookDescription = bookInfo.Description;
        BookImage = bookInfo.Image;
        BookPrice = bookInfo.OldPrice;
        BookTitle = bookInfo.Name;
        BookType = bookInfo.TypeName;
        IsBidding = bookInfo.IsBidding;
        Seller = bookInfo.Seller;
    }
    protected void BtnAddToCart_Click(object sender, EventArgs e)
    {
        // 判断是否已经有用户登录
        if (Session["account"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }
        int num = 0;
        try
        {
            num = Convert.ToInt32(BuyNumber.Text);
        }
        catch (Exception)
        {
            BuyNumber.Text = "0";
            return;
        }
        // 根据Session获取用户ID，进行商品的添加
        Account account = (Account)Session["account"];
        OrderDao orderDao = new OrderDao();
        orderDao.AddNewOrder(account.Id, BookId, num);
        //添加到数据库
        //if (orderDao.AddNewOrder(account.Id, BookId, num))
        //{
        //    ErrorInfo.CssClass = "text-primary";
        //    ErrorInfo.Text = "商品已经添加～";
        //}
        //else
        //{
        //    ErrorInfo.Text = "加入购物车失败 = =";
        //}
    }
}