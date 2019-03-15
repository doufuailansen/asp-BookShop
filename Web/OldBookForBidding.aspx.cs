using System;
using System.Collections.Generic;
using System.Text;
using Dao;
using Model;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{

}

public partial class Web_OldBookForBidding : System.Web.UI.Page
{
    public string OldBiddingBook { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        int typeId;
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

        OldBookDao oldBookDao = new OldBookDao();
        List<OldBookInfo> list = oldBookDao.GetBookForBidding();
        if (list != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (OldBookInfo book in list)
            {
                stringBuilder.AppendFormat("<div class='book'><a href = './Bidding1.aspx?id={0}' ><img src = '{1}' /><h4 class='title' alt='{2}'>{2}</h4><small class='text-info' alt='{3}'>作者：{3} </small></br><small class='text-info' alt='{4}'>送拍人：{4} </small><p class='text-danger'>当前出价： ￥{5}</p></a></div>", book.Id, book.Image, book.Name, book.Author, book.Seller, book.NewPrice);
            }
            OldBiddingBook = stringBuilder.ToString();
        }
    }
}