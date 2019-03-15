using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_UpdateOldBookInfo : System.Web.UI.Page
{
    public string bookname { get; set; }
    public string image { get; set; }
    public string author { get; set; }
    public double price { get; set; }
    public string descripition { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    { // 验证当前是否有用户登录
        Account account = (Account)Session["account"];
        // 未登录则禁止访问本页，跳转到登录页面
        if (account == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            //显示textbox中的默认信息
            int oldbookid = (int)Session["updateoldbookid"];
            OldBookDao oldbookdao = new OldBookDao();
            OldBookInfo oldbook = oldbookdao.GetBookDetailById(oldbookid);
            bookname = oldbook.Name;
            image = oldbook.Image;
            price = oldbook.OldPrice;
            author = oldbook.Author;
            descripition = oldbook.Description;

            TextAuthor.Text = author;
            TextDescription.Text = descripition;
            TextImage.Text = image;
            TextName.Text = bookname;
            TextPrice.Text = price + "";
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        //获取现在所编辑的书的ID
        int id = (int)Session["updateoldbookid"];
        //实例化一个数据库操作
        OldBookDao bookDao = new OldBookDao();
        //实例化一个模型
        OldBookInfo book = new OldBookInfo();
        book.Description = TextDescription.Text.Trim();
        book.Author = TextAuthor.Text.Trim();
        book.Image = TextImage.Text.Trim();
        book.Name = TextName.Text.Trim();
        book.OldPrice = Convert.ToDouble(TextPrice.Text);
        book.TypeId = Convert.ToInt32(DropDownList.SelectedValue);
        book.Id = id;
        bookDao.UpdateOldBookInfo(book);

        if (bookDao.UpdateOldBookInfo(book))
        {
            //设置样式
            ResultInfo.CssClass = "text-success";
            ResultInfo.Text = "更新成功！";
        }
        else
        {
            ResultInfo.CssClass = "text-danger";
            ResultInfo.Text = "更新失败！";
        }
    }
}