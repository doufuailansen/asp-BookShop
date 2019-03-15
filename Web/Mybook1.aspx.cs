using common;
using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_MyBook1 : System.Web.UI.Page
{
    public string MyBook { get; set; }

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
            string _sql = "select username from account where id = '" + account.Id + "'";
            DataTable data = SqlHelper.GetDataTable(_sql, CommandType.Text);
            OldBookDao oldbookdao = new OldBookDao();
            List<OldBookInfo> list = new List<OldBookInfo>();
            int count = 1;
            if (data.Rows.Count > 0)
            {
                //(int)data.Rows[0]["id"]
                string seller = data.Rows[0]["username"].ToString();
                //通过用户名在旧书表中取出该用户为seller的图书
                list = oldbookdao.GetMySellingBookBySeller(seller);
            }

            if (list != null)
            {
                StringBuilder sb = new StringBuilder();
                //遍历列表
                foreach (OldBookInfo oldBook in list)
                {
                    //生成html
                    sb.AppendFormat("<tr><td>{0}</ td><td class='text-primary'><a href='OldBookDetial.aspx?id={7}'>{1}</a></td><td class='text-danger'>{2}</td><td class='text-danger'>{3}</td><td><img alt = '' class='book_image'src='{4}'/></td><td class='text-danger'>￥{5}</td><td class='text-danger'>{6}</td><td> <input class='btn btn-danger update_book' data-toggle='modal' data-target='#confirm-update' bookId='{7}' bookName='{2}' value='编辑' type='button' /><input class='btn btn-danger delete_book' data-toggle='modal' data-target='#confirm-delete' bookId='{7}' bookName='{2}' value='删除' type='button' /></tr>", count++, oldBook.Name, oldBook.Author, oldBook.Description, oldBook.Image, oldBook.OldPrice, oldBook.TypeName, oldBook.Id);
                }
                //返回给页面
                MyBook = sb.ToString();
            }
            else
            {
                EmptyInfo.Text = "您还没有卖自己的图书哦～";
            }
        }
    }

    /// <summary>
    /// 删除一条订单
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnDeleteBook_Click(object sender, EventArgs e)
    {
        OldBookDao oldbookdao = new OldBookDao();
        if (oldbookdao.DeleteBookById(Convert.ToInt32(BookId.Text)))
        {
            // 刷新当前页

            Response.AddHeader("Refresh", "0");
        }

    }
    protected void BtnUpdateBook_Click(object sender, EventArgs e)
    {
        //获取现在所编辑的书的ID
        Session["updateoldbookid"] = Convert.ToInt32(Convert.ToInt32(BookId.Text));
        Response.Redirect("UpdateOldBookInfo.aspx");

    }


}