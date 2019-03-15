using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using common;
using Model;

namespace Dao
{
    /// <summary>
    /// OldBookDao数据库操作类
    /// </summary>

    public class OldBookDao
    {
        private string _sql;

        /// <summary>
        /// 获取所有旧书
        /// </summary>
        /// <returns></returns>
        public List<OldBookInfo> GetAllBooks()
        {
            _sql = "select a.id as id, name, author, oldPrice, newPrice, image, description, bidding, buyer, time, seller, number, typeName, type from oldBookInfo a, bookType b where a.type = b.id";
            DataTable data = SqlHelper.GetDataTable(_sql, CommandType.Text);

            if (data.Rows.Count > 0)
            {
                List<OldBookInfo> list = new List<OldBookInfo>();
                foreach (DataRow row in data.Rows)
                {
                    OldBookInfo book = new OldBookInfo();
                    LoadEntity(book, row);
                    list.Add(book);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        public List<OldBookInfo> GetAllMyBooks()
        {
            _sql = "select a.id as id, name, author, oldPrice, newPrice, image, description, bidding, buyer, time, seller, number, typeName, type from oldBookInfo a, bookType b where a.type = b.id";
            DataTable data = SqlHelper.GetDataTable(_sql, CommandType.Text);

            if (data.Rows.Count > 0)
            {
                List<OldBookInfo> list = new List<OldBookInfo>();
                foreach (DataRow row in data.Rows)
                {
                    OldBookInfo book = new OldBookInfo();
                    MainPageLoadEntity(book, row);
                    list.Add(book);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        public List<OldBookInfo> GetMySellingBookBySeller(string seller)
        {
            _sql = "select a.id as id, name, author, oldPrice, newPrice, image, description, typeName, bidding, buyer, time, seller, type from oldBookInfo a, bookType b where a.type = b.id and seller = '" + seller + "'";
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text);

            List<OldBookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<OldBookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    OldBookInfo oldBookInfo = new OldBookInfo();
                    // 数据填充
                    MainPageLoadEntity(oldBookInfo, row);
                    // 加入集合
                    list.Add(oldBookInfo);
                }
            }
            return list;
        }



        /// <summary>
        /// 通过id获取书籍详细信息
        /// </summary>
        /// <param name="id">书籍id</param>
        /// <returns></returns>
        public OldBookInfo GetBookDetailById(int id)
        {
            _sql = "select a.id as id, name, author,oldPrice, newPrice,image, description, bidding, buyer, time, seller, number, typeName, type from oldBookInfo a, bookType b where a.id = @id and a.type = b.id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id),
            };
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);

            if (dataTable.Rows.Count > 0)
            {
                OldBookInfo oldBookInfo = new OldBookInfo();
                MainPageLoadEntity(oldBookInfo, dataTable.Rows[0]);
                oldBookInfo.Seller = dataTable.Rows[0]["seller"].ToString();
                //oldBookInfo.NewPrice = Convert.ToDouble(dataTable.Rows[0]["newPrice"]);

                return oldBookInfo;
            }
            else
            {
                return null;
            }
        }

        public OldBookInfo GetBiddingBookDetailById(int id)
        {
            _sql = "select a.id as id, name, author,oldPrice, newPrice,image, description, bidding, buyer, time, seller, number, typeName, type from oldBookInfo a, bookType b where a.id = @id and a.type = b.id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id),
            };
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameters);

            if (dataTable.Rows.Count > 0)
            {
                OldBookInfo oldBookInfo = new OldBookInfo();
                LoadEntity(oldBookInfo, dataTable.Rows[0]);
                //oldBookInfo.Seller = dataTable.Rows[0]["seller"].ToString();
                //oldBookInfo.NewPrice = Convert.ToDouble(dataTable.Rows[0]["newPrice"]);

                return oldBookInfo;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 插入新的图书
        /// </summary>
        /// <param name="oldBook"></param>
        /// <returns></returns>
        public bool AddNewBook(OldBookInfo oldBook)
        {
            _sql =
                "insert into OldbookInfo (name, author, oldprice, newprice, seller, bidding, image, time, description, type) values (@name, @author, @oldprice, @newprice, @seller, @bidding, @image, '2018-07-05 10:00:00' ,@description, @type)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", oldBook.Name),
                new SqlParameter("@author", oldBook.Author),
                new SqlParameter("@oldprice", oldBook.OldPrice),
                new SqlParameter("@newprice", oldBook.NewPrice),
                new SqlParameter("@seller", oldBook.Seller),
                new SqlParameter("@bidding",oldBook.IsBidding),
                new SqlParameter("@image", oldBook.Image),
                new SqlParameter("@description", oldBook.Description),
                new SqlParameter("@type", oldBook.TypeId),
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 插入新的报价
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool AddNewPrice(OldBookInfo book)
        {
            _sql = "update oldBookInfo set newPrice = @newPrice where Id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@newPrice", book.NewPrice),
                new SqlParameter("@id", book.Id),
            };


            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;

        }


        /// <summary>
        /// 获取竞拍推荐图书列表
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<OldBookInfo> GetRecommendBooksTop3(int typeId)
        {
            // 查询语句（只取奇数行）
            _sql = "select top 3 a.id as id, name, author, oldPrice, newPrice, image, description, typeName, bidding, buyer, time, seller, number, type from oldBookInfo a, bookType b where a.type = b.id and a.id % 2 = 1 and type = @type and a.bidding = 1";
            SqlParameter[] parameter =
            {
                new SqlParameter("type", typeId),
            };
            if (typeId == -1)
            {
                _sql = "select top 3 a.id as id, name, author, oldPrice, newPrice, image, description, typeName, bidding, buyer, time, seller, number, type from oldBookInfo a, bookType b where a.type = b.id and a.id % 2 = 1 and a.bidding = 1";
                parameter = null;
            }
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameter);

            List<OldBookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<OldBookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    OldBookInfo oldBookInfo = new OldBookInfo();
                    // 数据填充
                    MainPageLoadEntity(oldBookInfo, row);
                    // 加入集合
                    list.Add(oldBookInfo);
                }
            }
            return list;
        }

        /// <summary>
        /// 更新图书信息
        /// </summary>
        /// <param name="oldBook"></param>
        /// <returns></returns>
        public bool UpdateOldBookInfo(OldBookInfo oldBook)
        {
            _sql =
                "update oldBookInfo set name = @name, author = @author, oldPrice = @oldPrice, image = @image, description = @description, type = @type where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@name", oldBook.Name),
                new SqlParameter("@author", oldBook.Author),
                new SqlParameter("@oldPrice", oldBook.OldPrice),
                new SqlParameter("@image", oldBook.Image),
                new SqlParameter("@description", oldBook.Description),
                new SqlParameter("@type", oldBook.TypeId),
                new SqlParameter("@id", oldBook.Id),
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 根据id删除图书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBookById(int id)
        {
            _sql = "delete from oldBookInfo where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@id", id),
            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 获取竞拍图书列表
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<OldBookInfo> GetBookForBidding()
        {
            // 查询语句
            _sql = "select a.id as id, name, author, oldPrice, newPrice, image, description, typeName, bidding, buyer, time, seller, number, type from oldBookInfo a, bookType b where a.bidding = 1 and a.type = b.id";
            //SqlParameter[] parameter =
            //{
            //    new SqlParameter("type", typeId),
            //};
            //if (typeId == -1)
            //{
            //    _sql = "select a.id as id, name, author, oldPrice, newPrice, image, description, typeName, bidding, buyer, time, seller, type from oldBookInfo a, bookType b where a.bidding = True";
            //    parameter = null;
            //}
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text);

            List<OldBookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<OldBookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    OldBookInfo oldBookInfo = new OldBookInfo();
                    // 数据填充
                    LoadEntity(oldBookInfo, row);
                    // 加入集合
                    list.Add(oldBookInfo);
                }
            }
            return list;
        }
        public List<OldBookInfo> GetHotSearchTop10(int typeId)
        {
            // 查询语句
            _sql = "select top 10 a.id as id, name, author, oldPrice, image, description, typeName, type from oldBookInfo a, bookType b where a.type = b.id and type = @type and a.bidding = 0";
            SqlParameter[] parameter =
            {
                new SqlParameter("type", typeId),
            };
            if (typeId == -1)
            {
                _sql = "select top 10 a.id as id, name, author, oldPrice, image, description, typeName, type from oldBookInfo a, bookType b where a.type = b.id and a.bidding = 0";
                parameter = null;
            }
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameter);

            List<OldBookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<OldBookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    OldBookInfo bookInfo = new OldBookInfo();
                    // 数据填充
                    MainPageLoadEntity(bookInfo, row);
                    // 加入集合
                    list.Add(bookInfo);
                }
            }
            return list;
        }

        public List<OldBookInfo> GetNewComingTop10(int typeId)
        {
            // 查询语句（只取偶数行）
            _sql = "select top 10 a.id as id, name, author, oldPrice, image, description, typeName, type from oldBookInfo a, bookType b where a.type = b.id and a.id % 2 = 0 and type = @type and a.bidding = 0";
            SqlParameter[] parameter =
            {
                new SqlParameter("type", typeId),
            };
            if (typeId == -1)
            {
                _sql = "select top 10 a.id as id, name, author, oldPrice, image, description, typeName, type from oldBookInfo a, bookType b where a.type = b.id and a.id % 2 = 0 and a.bidding = 0";
                parameter = null;
            }
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameter);

            List<OldBookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<OldBookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    OldBookInfo bookInfo = new OldBookInfo();
                    // 数据填充
                    MainPageLoadEntity(bookInfo, row);
                    // 加入集合
                    list.Add(bookInfo);
                }
            }
            return list;
        }
        public List<OldBookInfo> GetRecommendBooksTop10(int typeId)
        {
            // 查询语句（只取奇数行）
            _sql = "select top 10 a.id as id, name, author, oldPrice, newPrice, image, description, typeName, bidding, buyer, time, seller, type from oldBookInfo a, bookType b where a.type = b.id and a.id % 2 = 1 and type = @type and a.bidding = 0";
            SqlParameter[] parameter =
            {
                new SqlParameter("type", typeId),
            };
            if (typeId == -1)
            {
                _sql = "select top 10 a.id as id, name, author, oldPrice, newPrice, image, description, typeName, bidding, buyer, time, seller, type from oldBookInfo a, bookType b where a.type = b.id and a.id % 2 = 1 and a.bidding = 0";
                parameter = null;
            }
            // 获取数据
            DataTable dataTable = SqlHelper.GetDataTable(_sql, CommandType.Text, parameter);

            List<OldBookInfo> list = null;
            // 如果存在数据
            if (dataTable.Rows.Count > 0)
            {
                list = new List<OldBookInfo>();
                foreach (DataRow row in dataTable.Rows)
                {
                    OldBookInfo oldBookInfo = new OldBookInfo();
                    // 数据填充
                    MainPageLoadEntity(oldBookInfo, row);
                    // 加入集合
                    list.Add(oldBookInfo);
                }
            }
            return list;
        }
        /// <summary>
        /// 更新买家信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool UpdateBuyer(OldBookInfo book)
        {
            _sql =
                "update oldBookInfo set buyer = @buyer where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@buyer", book.Buyer),
                new SqlParameter("@id", book.Id),

            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }


        /// <summary>
        /// 更新竞拍人数
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool UpdateNumber(OldBookInfo book)
        {
            _sql =
                "update oldBookInfo set number = @number where id = @id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@number", book.Number),
                new SqlParameter("@id", book.Id),

            };
            return SqlHelper.ExecuteNonquery(_sql, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// 实体装载
        /// </summary>
        /// <param name="book">需要转载的对象</param>
        /// <param name="row">数据源</param>
        public void LoadEntity(OldBookInfo book, DataRow row)
        {
            book.Id = Convert.ToInt32(row["id"]);
            book.Name = row["name"].ToString();
            book.Author = row["author"].ToString();
            book.Image = row["image"].ToString();
            book.OldPrice = Convert.ToDouble(row["oldPrice"]);
            book.NewPrice = Convert.ToDouble(row["newPrice"]);
            book.Description = row["description"].ToString();
            book.IsBidding = Convert.ToBoolean(row["bidding"]);
            book.Buyer = row["buyer"].ToString();
            book.Time = Convert.ToDateTime(row["time"]);
            book.Seller = row["seller"].ToString();
            book.Number = Convert.ToInt32(row["Number"]);
            book.TypeName = row["typeName"].ToString();
            book.TypeId = Convert.ToInt32(row["type"]);
        }

        public void MainPageLoadEntity(OldBookInfo book, DataRow row)
        {
            book.Id = Convert.ToInt32(row["id"]);
            book.Name = row["name"].ToString();
            book.Author = row["author"].ToString();
            book.Image = row["image"].ToString();
            book.OldPrice = Convert.ToDouble(row["oldPrice"]);
            //book.NewPrice = Convert.ToDouble(row["newPrice"]);
            book.Description = row["description"].ToString();
            //book.IsBidding = Convert.ToBoolean(row["bidding"]);
            //book.Buyer = row["buyer"].ToString();
            // book.Time = Convert.ToDateTime(row["time"]);
            //book.Seller = row["seller"].ToString();
            book.TypeName = row["typeName"].ToString();
            book.TypeId = Convert.ToInt32(row["type"]);
        }


    }
}

