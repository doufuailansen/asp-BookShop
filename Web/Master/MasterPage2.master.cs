using System;
using System.Web;
using Dao;
using Model;

public partial class Web_Master_MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InitPage();
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
        // 关于我们
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
}
