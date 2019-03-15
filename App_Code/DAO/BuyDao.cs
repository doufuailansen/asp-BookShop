using common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// BuyDao 的摘要说明
/// </summary>
namespace Dao
{


    public class BuyDao
    {
        private string _sql;
        public BuyDao()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        //添加新的订单
        public bool AddNewOrder(int id)
        {
            _sql =
                "insert into buyForm select orderForm.accountId,orderForm.bookId,orderForm.count,getdate() as buyTime from orderForm where orderForm.Id = @id;";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id)

            };

            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }
        /// <summary>
        /// 通过用户ID获取购物车列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BuyForm> GetBuyFormsByAccountId(int id)
        {
            _sql =
                "select buyForm.id as id, name, image, price, count, buyTime from bookInfo, buyForm where accountId = @accountId and bookId = bookInfo.id ";

            SqlParameter[] parameters =
            {
                new SqlParameter("@accountId", id),
            };

            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);
            List<BuyForm> list = null;
            if (dataTable.Rows.Count > 0)
            {
                list = new List<BuyForm>();
                foreach (DataRow row in dataTable.Rows)
                {

                    BuyForm buy = new BuyForm();
                    LoadEntity(buy, row);
                    list.Add(buy);
                }
            }
            return list;
        }

        public List<BuyForm> GetBuyFormsForOldBookByAccountId(int id)
        {
            _sql =
                "select buyForm.id as id, name, image, newPrice, count, buyTime from oldBookInfo, buyForm where accountId = @accountId and bookId = oldBookInfo.id ";

            SqlParameter[] parameters =
            {
                new SqlParameter("@accountId", id),
            };

            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);
            List<BuyForm> list = null;
            if (dataTable.Rows.Count > 0)
            {
                list = new List<BuyForm>();
                foreach (DataRow row in dataTable.Rows)
                {

                    BuyForm buy = new BuyForm();
                    LoadOldBookEntity(buy, row);
                    list.Add(buy);
                }
            }
            return list;
        }
        /// <summary>
        /// 根据ID删除一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBuyingById(int id)
        {
            _sql = "delete from buyForm where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id),
            };

            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }
        /// <summary>
        /// 实体装载
        /// </summary>
        /// <param name="order">装载的对象</param>
        /// <param name="row">数据源</param>
        private void LoadEntity(BuyForm order, DataRow row)
        {
            order.Count = Convert.ToInt32(row["count"]);
            order.Id = Convert.ToInt32(row["id"]);
            order.BookImage = row["image"].ToString();
            order.BookName = row["name"].ToString();
            order.BookPrice = Convert.ToDouble(row["price"]);
            order.BuyTime = Convert.ToDateTime(row["buyTime"]);
        }

        private void LoadOldBookEntity(BuyForm order, DataRow row)
        {
            order.Count = Convert.ToInt32(row["count"]);
            order.Id = Convert.ToInt32(row["id"]);
            order.BookImage = row["image"].ToString();
            order.BookName = row["name"].ToString();
            order.BookPrice = Convert.ToDouble(row["newPrice"]);
            order.BuyTime = Convert.ToDateTime(row["buyTime"]);
        }
    }
}