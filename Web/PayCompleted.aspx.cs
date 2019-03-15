using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_PayCompleted : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*Account account = new Account();
         HttpCookie cookie = new HttpCookie("accountId");
        cookie.Expires = DateTime.Now.AddDays(7);
        cookie.Value = account.Id + "";
        Response.Cookies.Add(cookie);
        Session["account"] = account;*/

        ErrorInfo.Style.Add("color", "green");
        ErrorInfo.Text = "支付成功，3秒后自动跳转...";
        Response.Write("<meta   http-equiv='refresh'   content='3;URL=./Cart.aspx'>");

    }
}