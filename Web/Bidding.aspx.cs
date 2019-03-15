using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Model;
using System.Text;

public partial class Web_Bidding : System.Web.UI.Page
{
    public string BookTitle { get; set; }
    public string BookDescription { get; set; }
    public string BookImage { get; set; }
    public string BookAuthor { get; set; }
    public double BookOldPrice { get; set; }
    public double BookNewPrice { get; set; }
    public bool IsBidding { get; set; }
    public string BookSeller { get; set; }
    public string BookBuyer { get; set; }
    public DateTime EndTime { get; set; }
    public string BookType { get; set; }
    public int BookId { get; set; }
    public static int number = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        // 传参异常捕获
        try
        {
            // 获取get的传参
            BookId = Convert.ToInt32(Request.QueryString["id"]);
        }
        catch (Exception)
        {
            Response.Redirect("./OldBookMainPage.aspx");
        }
        // id值不可为负数
        if (BookId <= 0)
        {
            Response.Redirect("./OldBookMainPage.aspx");
        }

        OldBookDao oldBookDao = new OldBookDao();
        // 获取图书详情
        OldBookInfo oldBookInfo = oldBookDao.GetBookDetailById(BookId);
        // 展示到页面
        BookAuthor = oldBookInfo.Author;
        BookDescription = oldBookInfo.Description;
        BookImage = oldBookInfo.Image;
        BookOldPrice = oldBookInfo.OldPrice;
        BookNewPrice = oldBookInfo.NewPrice;
        BookTitle = oldBookInfo.Name;
        BookType = oldBookInfo.TypeName;
        IsBidding = oldBookInfo.IsBidding;
        BookSeller = oldBookInfo.Seller;
        EndTime = oldBookInfo.Time;

        if(Page.IsPostBack)
        {
            number++;
        }
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        // 判断是否已经有用户登录
        if (Session["account"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }
        OldBookDao oldBookDao = new OldBookDao();
        OldBookInfo oldBookInfo = new OldBookInfo();
        oldBookInfo.Id = Convert.ToInt32(Request.QueryString["id"]);
        oldBookInfo.NewPrice = Convert.ToDouble(NewPrice.Text.Trim());
        oldBookDao.AddNewPrice(oldBookInfo);

        Response.Redirect(Request.Url.ToString());
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
            //当前时间
            DateTime dtStart = System.DateTime.Now;
            TimeSpan ts = new TimeSpan(0, 0, 90000);
            ts = EndTime.Subtract(dtStart);
            string days = (ts.Days < 10) ? ("0" + ts.Days.ToString()) : ts.Days.ToString();
            string hour = (ts.Hours < 10) ? ("0" + ts.Hours.ToString()) : ts.Hours.ToString();

            string minutes = (ts.Minutes < 10) ? ("0" + ts.Minutes.ToString()) : ts.Minutes.ToString();
            string seconds = (ts.Seconds < 10) ? ("0" + ts.Seconds.ToString()) : ts.Seconds.ToString();

            int time_Hours = int.Parse((ts.Hours).ToString());
            int time_Seconds = int.Parse((ts.Seconds).ToString());
            //        int time_Hours = Convert.ToInt32(ts.TotalHours);
            int time_Minutes = int.Parse((minutes).ToString());
            int time_days = int.Parse((ts.Days).ToString());

            if (time_Minutes >= 60)
            {
                if ((time_Minutes % 60) != 0)
                {
                    hour = (ts.Hours + 1).ToString();
                    time_Minutes -= 60;
                }
            }

            Label1.Text = "倒计时：" + days + "天" + hour + "小时" + time_Minutes + "分钟" + seconds + "秒";
            if (time_days <= 0)
            {
                Label1.Text = "倒计时：" + hour + "小时" + time_Minutes + "分钟" + seconds + "秒";
                if (time_Hours <= 0)
                {
                    Label1.Text = "倒计时：" + time_Minutes + "分钟" + seconds + "秒";
                    if (time_Minutes <= 0)
                    {
                        Label1.Text = "倒计时：" + seconds + "秒";
                    }
                }
            }
        } 
    


    // 添加到购物车
    protected void BtnAddToCart_Click(object sender, EventArgs e)
    {
        // 判断是否已经有用户登录
        if (Session["account"] == null)
        {
            Response.Redirect("Login.aspx");
            return;
        }
        int num = 0;
        //try
        //{
        //    num = Convert.ToInt32(BuyNumber.Text);
        //}
        //catch (Exception)
        //{
        //    BuyNumber.Text = "0";
        //    return;
        //}
        // 根据Session获取用户ID，进行商品的添加
        Account account = (Account)Session["account"];
        OrderDao orderDao = new OrderDao();
        // 添加到数据库
        if (orderDao.AddNewOrder(account.Id, BookId, num))
        {
            ErrorInfo.CssClass = "text-primary";
            ErrorInfo.Text = "商品已经添加～";
        }
        else
        {
            ErrorInfo.Text = "加入购物车失败 = =";
        }
    }

}
