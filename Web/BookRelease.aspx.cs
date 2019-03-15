using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Model;

public partial class Web_MyBook : System.Web.UI.Page
{
    //实例化一个数据库操作
    OldBookDao oldBookDao = new OldBookDao();

    //实例化一个模型
    OldBookInfo oldBook = new OldBookInfo();
    Boolean isBidding = false;


    protected void Page_Load(object sender, EventArgs e)
    {
        // 验证当前是否有用户登录
        Account account = (Account)Session["account"];
        // 未登录则禁止访问本页，跳转到登录页面
        if (account == null)
        {
            Response.Redirect("Login.aspx");
        }
        //是否是第一次请求，防止缓存
        //else
        //{
        //    UpdatePage();
        //}


    }

    private void UpdatePage()
    {
        int id = 0;
        try
        {
            id = Convert.ToInt32(Request.QueryString["bookId"]);
        }
        //捕获异常，如果有错就返回上一页
        catch (Exception)
        {
            Response.Write("<script>window.history.go(-1);</script>");
        }
        //实例化一个数据库操作
        OldBookDao oldBookDao = new OldBookDao();

        //通过ID获取书本的详细信息
        OldBookInfo oldBook = oldBookDao.GetBookDetailById(id);
        if (oldBook == null)
        {
            //无数据时，返回上一页
            Response.Write("<script>window.history.go(-1);</script>");
        }
        else
        {
            //将这本书的信息写在界面上
            TextAuthor.Text = oldBook.Author;
            TextDescription.Text = oldBook.Description;
            TextImage.Text = oldBook.Image;
            TextName.Text = oldBook.Name;
            TextPrice.Text = oldBook.OldPrice + "";

            for (int i = 0; i < DropDownList.Items.Count; i++)
            {
                if (Convert.ToInt32(DropDownList.Items[i].Value) == oldBook.TypeId)
                {
                    DropDownList.SelectedIndex = i;
                }
            }

        }
    }

    // 发布按钮点击事件
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        Account account = (Account)Session["account"];
        //获取现在所编辑的书的ID
        int id = Convert.ToInt32(Request.QueryString["bookId"]);

        if (RadioButton1.Checked)
        {
            isBidding = true;
        }

        if (RadioButton2.Checked)
        {
            isBidding = false;
        }


        //oldBook.Description = this.TextDescription.Text;
        //oldBook.Author = this.TextAuthor.Text;
        //oldBook.Image = this.TextImage.Text;
        //oldBook.Name = this.TextName.Text;
        //oldBook.OldPrice = Convert.ToDouble(this.TextPrice.Text);
        //oldBook.TypeId = Convert.ToInt32(DropDownList.SelectedValue);

        //id = Convert.ToInt32(Request.QueryString["bookId"]);
        //oldBook.Id = id;
        oldBook.Name = TextName.Text.Trim();
        oldBook.Author = TextAuthor.Text.Trim();
        oldBook.TypeId = Convert.ToInt32(DropDownList.SelectedValue);
        oldBook.OldPrice = Convert.ToDouble(TextPrice.Text);
        oldBook.NewPrice = Convert.ToDouble(TextPrice.Text);
        oldBook.IsBidding = isBidding;
        oldBook.Seller = account.Username;
        oldBook.Image = TextImage.Text.Trim();
        oldBook.Description = TextDescription.Text.Trim();

        if (oldBookDao.AddNewBook(oldBook))
        {
            //设置样式
            ResultInfo.CssClass = "text-success";
            ResultInfo.Text = "发布成功！";
        }
        else
        {
            ResultInfo.CssClass = "text-danger";
            ResultInfo.Text = "发布失败！";
        }
    }

    //protected void RadioButton1_Click(object sender, EventArgs e)
    //{
    //    if (RadioButton1.Checked)
    //    {
    //        isBidding = true;
    //    }
    //}

    //protected void RadioButton2_Click(object sender, EventArgs e)
    //{
    //    if (RadioButton2.Checked)
    //    {
    //        isBidding = false;
    //    }
    //}
}