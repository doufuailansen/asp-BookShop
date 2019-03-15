using Dao;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;





public partial class Web_OldBookMain : System.Web.UI.Page
{
    public string HotSearch { get; set; }
    public string NewComing { get; set; }
    public string RecommendBooks { get; set; }
    public string BookType { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

        int typeId = -1;
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
        OldBookDao bookDao = new OldBookDao();
        // 图书集合
        List<OldBookInfo> list;

        // 热搜图书
        list = bookDao.GetHotSearchTop10(typeId);
        if (list != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (OldBookInfo book in list)
            {
                stringBuilder.AppendFormat("<div class='book'><a href = './OldBookDetail.aspx?id={0}' ><img src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4><small class='text-info' alt='{3}'>{3} </small><p class='text-danger'>￥{4}</p></a></div>", book.Id, book.Image, book.Name, book.Author, book.OldPrice);
            }
            HotSearch = stringBuilder.ToString();
        }
        else
        {
            HotSearch = "<h3 class='text-warning'>热搜图书暂无数据...</h3>";
        }

        // 新上架图书---->发布的旧书动态
        list = bookDao.GetNewComingTop10(typeId);
        if (list != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (OldBookInfo book in list)
            {
                stringBuilder.AppendFormat("<div class='book'><a href = './OldBookDetail.aspx?id={0}' ><img src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4><small class='text-info' alt='{3}'>{3} </small><p class='text-danger'>￥{4}</p></a></div>", book.Id, book.Image, book.Name, book.Author, book.OldPrice);
            }
            NewComing = stringBuilder.ToString();
        }
        else
        {
            NewComing = "<h3 class='text-warning'>暂无新发布动态...</h3>";
        }
        // 推荐图书
        list = bookDao.GetRecommendBooksTop10(typeId);
        if (list != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (OldBookInfo book in list)
            {
                stringBuilder.AppendFormat("<div class='book'><a href = './OldBookDetail.aspx?id={0}' ><img src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4><small class='text-info' alt='{3}'>{3} </small><p class='text-danger'>￥{4}</p></a></div>", book.Id, book.Image, book.Name, book.Author, book.OldPrice);
            }
            RecommendBooks = stringBuilder.ToString();
        }
        else
        {
            RecommendBooks = "<h3 class='text-warning'>推荐图书暂无数据...</h3>";
        }

        // 左侧类别栏
        BookTypeDao bookTypeDao = new BookTypeDao();
        List<BookType> types = bookTypeDao.GetAllBookTypes();
        if (types != null)
        {
            StringBuilder sb = new StringBuilder();
            foreach (BookType type in types)
            {
                sb.AppendFormat(
                    "<a href='OldBookMain.aspx?typeId={0}' class='list-group-item'><i class='fa fa-comment fa-fw'></i>{1}</a>",
                    type.Id, type.TypeName);
            }
            BookType = sb.ToString();
        }

    }
}
