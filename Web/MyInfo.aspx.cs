using System;
using Dao;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_MyInfo : System.Web.UI.Page
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
            TextAnswer.Text = account.Answer;
            TextEmail.Text = account.Mail;
            TextPassword.Text = account.Password;
            TextQuestion.Text = account.Question;
            TextUsername.Text = account.Username;
            TextTelephone.Text = account.Telephone;
            TextAddress.Text = account.Address;
        }
    }

    /// <summary>
    /// 更新按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

        UpdateAccountInfo();

    }

    /// <summary>
    /// 更新用户信息
    /// </summary>
    private void UpdateAccountInfo()
    {
        Account account = (Account)Session["account"];
        account.Answer = TextAnswer.Text;
        account.Mail = TextEmail.Text;
        account.Password = TextPassword.Text;
        account.Question = TextQuestion.Text;
        account.Address = TextAddress.Text;
        account.Telephone = TextTelephone.Text;
        AccountDao accountDao = new AccountDao();
        if (accountDao.UpdateAccountInfoById(account))
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