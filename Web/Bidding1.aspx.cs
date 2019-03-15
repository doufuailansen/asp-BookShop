using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Model;
using System.Text;
using System.Data.SqlClient;
using common;
using System.Data;

public partial class Web_Bidding1 : System.Web.UI.Page
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
    public int BookNumber { get; set; }
    public DateTime EndTime { get; set; }
    public string BookType { get; set; }
    public int BookId { get; set; }
    public static int number = 0;
    public string More { get; set; }
    private System.Timers.Timer timer1;


    protected void Page_Load(object sender, EventArgs e)
    {
        int typeId;
        try
        {
            typeId = Convert.ToInt32(Request.QueryString["typeId"]);
        }
        catch (Exception)
        {
            typeId = -1;
        }

        if (typeId <= 0)
        {
            typeId = -1;
        }

        InitPage();
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
        // 图书集合
        List<OldBookInfo> list;
        list = oldBookDao.GetRecommendBooksTop3(typeId);
        if (list != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (OldBookInfo book in list)
            {
                stringBuilder.AppendFormat("<div class='book'><a href = './Bidding1.aspx?id={0}' ><img class='image-right' src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4></a></div>", book.Id, book.Image, book.Name);
            }
            More = stringBuilder.ToString();
        }
        // 获取图书详情
        OldBookInfo oldBookInfo = oldBookDao.GetBiddingBookDetailById(BookId);
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
        BookNumber = oldBookInfo.Number;
        EndTime = oldBookInfo.Time;
        BookBuyer = oldBookInfo.Buyer;

    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void InitPage()
    {
        if (Request.Cookies["accountId"] != null)
        {
            AccountDao accountDao = new AccountDao();
            Session["account"] = accountDao.GetAccountById(Convert.ToInt32(Request.Cookies["accountId"].Value));
        }
        if (Session["account"] != null)
        {
            Account account = (Account)Session["account"];
            btn_Login.Text = account.Username;
            btn_Register.Text = "购物车";
            btn_cart.Text = "退出";
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        // 登录
        if (Session["account"] == null)
        {
            Response.Redirect("./Login.aspx");
        }
        // 个人信息
        else
        {
            // TODO 详细信息
            Response.Redirect("./AccountInfo.aspx");
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        // 注册
        if (Session["account"] == null)
        {
            Response.Redirect("./register.aspx");
        }
        // 购物车
        else
        {
            Response.Redirect("./Cart.aspx");
        }
    }

    protected void btnCart_Click(object sender, EventArgs e)
    {
        // 购物车
        if (Session["account"] == null)
        {
            Response.Write("<script>window.open('Cart.aspx','_self');</script>");
        }
        // 退出
        else
        {
            // 退出（清除Session）
            Session.Remove("account");
            // 清除cookies
            HttpCookie cookie = Request.Cookies["accountId"];
            if (cookie != null)
            {
                Request.Cookies.Remove("accountId");
                cookie.Expires = DateTime.Now.AddDays(-10);
                cookie.Value = null;
                Response.Cookies.Add(cookie);
            }
            // 刷新
            Response.Redirect(Request.Url.ToString());
            // Response.AddHeader("Refresh", "0");
        }

    }

    // 搜索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string keyword = Key_Word.Text.Trim();
        if (string.Empty != keyword)
        {
            Response.Redirect("./Search.aspx?key=" + keyword);
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

        try
        {
             double newprice = Convert.ToDouble(NewPrice.Text.Trim());

            if (newprice <= BookNewPrice)
            {
                ErrorInfo.Text = "小于现最高价，请重新出价!";
                return;
            } 

        } catch 
        {
           
        }



        //获取当前登录用户
        Account account = (Account)Session["account"];


        oldBookInfo.Id = Convert.ToInt32(Request.QueryString["id"]);
        try
        {
            oldBookInfo.NewPrice = Convert.ToDouble(NewPrice.Text.Trim());
        } catch
        {
            oldBookInfo.NewPrice = BookNewPrice;
            ErrorInfo.Text = "请输入有效价格！";
        } 

        oldBookInfo.Buyer = account.Username;
        oldBookInfo.Number = ++BookNumber;
        oldBookDao.AddNewPrice(oldBookInfo);
        oldBookDao.UpdateBuyer(oldBookInfo);
        oldBookDao.UpdateNumber(oldBookInfo);

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
        int time_Minutes = int.Parse((ts.Minutes).ToString());

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
                    if (time_Seconds <= 0)
                    {
                        Label1.Text = "竞拍已结束！";
                        //NewPrice.Text = "1";
                        
                        //this.BtnBuy.Attributes["disabled"] = "true";

                        //BookBuyer
                        string _sql = "select account.id from account where username = '" + BookBuyer + "'";
                        /*SqlParameter[] parameters =
                        {
                            new SqlParameter ("@username",BookBuyer),
                        };*/
                        DataTable data = SqlHelper.GetDataTable(_sql, CommandType.Text);
                        if (data.Rows.Count > 0)
                        {
                            OrderDao orderdao = new OrderDao();
                            if (!IsPostBack)
                            {
                                 orderdao.AddNewOrder((int)data.Rows[0]["id"], BookId, 1);
                                Session["buyer"] = (int)data.Rows[0]["id"];
                                Session["biddingbookid"] = BookId;
                            }

                            Label1.Text = BookBuyer + "竞拍成功！";
                            
                            this.BtnBuy.Attributes["visible"] = "false";
                        }
                        else
                        {
                            Label1.Text = "无人竞拍成功！";
                            //this.BtnBuy.Attributes["disabled"] = "true"; 
                        }
                    
                    }
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
