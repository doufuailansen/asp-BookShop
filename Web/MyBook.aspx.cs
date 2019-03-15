using System;
using System.Collections.Generic;
using Dao;
using Model;
using System.Text;

public partial class Web_MyBook : System.Web.UI.Page
{
    //用来生成用户列表的html标签
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
        //是否是第一次请求，防止缓存
        else 
        {
            UpdateList();
        }
    }

    private void UpdateList()
    {
        //实例化一个bookDao
        //Dao数据库访问操作
        OldBookDao oldBookDao = new OldBookDao();
        //通过bookDao对象取出所有的书的信息
        List<OldBookInfo> list = oldBookDao.GetAllMyBooks();
        if (list != null)
        {
            StringBuilder sb = new StringBuilder();
            //遍历列表
            foreach (OldBookInfo oldBook in list)
            {
                //生成html
                sb.AppendFormat("<tr class='odd gradeX'><td>{0}</td><td style='width:20%;'><img width='99%' src='{4}'/></td><td>{1}</td><td>{2}</td><td>{3}</td><td>{5}</td><td>{6}</td><td><div bookId = '{0}' class='btn-group-sm text-center'><button type = 'button' class='btn btn-success btn_update'>编辑</button><p> </p><button type = 'button' class='btn btn-danger btn_delete' data-toggle='modal' data-target='#confirm-delete'>删除</button></div></td>", oldBook.Id, oldBook.Name, oldBook.Author, oldBook.Description, oldBook.Image, oldBook.OldPrice, oldBook.TypeName);

            }
            //返回给页面
            MyBook = sb.ToString();
        }
    }

    //// 添加图书
    //protected void BtnAddBook_Click(object sender, EventArgs e)
    //{
    //    OldBookInfo oldBook = new OldBookInfo();
    //    oldBook.Author = TextBookAuthor.Text;
    //    oldBook.Description = TextBookDescription.Text;
    //    oldBook.Image = TextBookImage.Text;
    //    oldBook.Name = TextBookName.Text;
    //    oldBook.TypeId = Convert.ToInt32(DropDownList1.SelectedValue);
    //    oldBook.OldPrice = Convert.ToDouble(TextBookPrice.Text);
    //    //实例化一个bookDao
    //    //Dao数据库访问操作
    //    OldBookDao oldBookDao = new OldBookDao();
    //    if (oldBookDao.AddNewBook(oldBook))
    //    {
    //        Response.AddHeader("Refresh", "0");
    //    }
    //}

    // 删除图书
    protected void BtnDeleteBook_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(BookId.Text);
        //实例化一个bookDao
        OldBookDao oldBookDao = new OldBookDao();
        //调用删除方法删除图书
        oldBookDao.DeleteBookById(id);
        //{
        //    //刷新当前页 0为立即刷新
        //    Response.AddHeader("Refresh", "0");
        //}
    }
}