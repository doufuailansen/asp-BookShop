using System;
using Dao;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_MyShopInfo : System.Web.UI.Page
{
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

            TextEmail.Text = account.Mail;
            TextUsername.Text = account.Username;
            TextShopname.Text = account.ShopName;
            TextShopDescription.Text = account.ShopDescription;
            TextActivity.Text = account.ShopActivity;
        }
    }

    /// <summary>
    /// 更新按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

        UpdateShopInfo();

    }

    /// <summary>
    /// 更新用户信息
    /// </summary>
    private void UpdateShopInfo()
    {
        Account account = (Account)Session["account"];
        account.Mail = TextEmail.Text;
        account.ShopDescription = TextShopDescription.Text;
        account.ShopActivity = TextActivity.Text;
        AccountDao accountDao = new AccountDao();
        if (accountDao.UpdateShopInfoById(account))
        {
            ResultInfo.Text = "用户信息更新成功！";
        }
        else
        {
            ResultInfo.CssClass = "text-danger";
            ResultInfo.Text = "用户信息更新失败！";
        }
    }
}