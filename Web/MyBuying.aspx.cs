using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_MyOrder1 : System.Web.UI.Page
{
    public string OrderList { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        // 验证当前是否有用户登录
        Account account = (Account)Session["account"];
        // 未登录则禁止访问本页，跳转到登录页面
        if (account == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            AccountName.Text = account.Username;
            BuyDao buyDao = new BuyDao();
            List<BuyForm> list = buyDao.GetBuyFormsByAccountId(account.Id);
            List<BuyForm> list1 = buyDao.GetBuyFormsForOldBookByAccountId(account.Id);

            if (list != null || list1 != null)
            {
                // 套接字符串
                StringBuilder sbBuilder = new StringBuilder();
                int counter = 1;
                if(list != null)
                {
                    foreach (BuyForm order in list)
                    {
                        // 生成html
                        sbBuilder.AppendFormat(
                            "<tr><td>{0}</ td><td><img alt = '' class='book_image'src='{1}'/></td><td class='text-primary'><a href='BookDetial.aspx?id={6}'>{2}</a></td><td class='text-danger'>￥{3}</td><td class='text-success'>{4}</td><td class='text-danger'>{5}</td><td><input class='btn btn-danger delete_book' data-toggle='modal' data-target='#confirm-delete' bookId='{6}' bookName='{2}' value='删除' type='button' /></td></tr>", counter++, order.BookImage, order.BookName, order.BookPrice, order.Count, order.BuyTime, order.Id);
                    }

                }
                if(list1 != null)
                {
                    foreach (BuyForm order in list1)
                    {
                        // 生成html
                        sbBuilder.AppendFormat(
                            "<tr><td>{0}</ td><td><img alt = '' class='book_image'src='{1}'/></td><td class='text-primary'><a href='BookDetial.aspx?id={6}'>{2}</a></td><td class='text-danger'>￥{3}</td><td class='text-success'>{4}</td><td class='text-danger'>{5}</td><td><input class='btn btn-danger delete_book' data-toggle='modal' data-target='#confirm-delete' bookId='{6}' bookName='{2}' value='删除' type='button' /></td></tr>", counter++, order.BookImage, order.BookName, order.BookPrice, order.Count, order.BuyTime, order.Id);
                    }
                }

                // 返回给浏览器
                OrderList = sbBuilder.ToString();
            }
            else
            {
                EmptyInfo.Text = "您还没有下过订单哦～";
            }

        }
    }
    protected void BtnDeleteBook_Click(object sender, EventArgs e)
    {
        OrderDao orderDao = new OrderDao();
        BuyDao buyDao = new BuyDao();
        if (buyDao.DeleteBuyingById(Convert.ToInt32(BookId.Text)))
        {
            // 刷新当前页
            Response.AddHeader("Refresh", "0");
        }

    }


}