using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// BuyForm 的摘要说明
/// </summary>
namespace Model
{


    public class BuyForm
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public double BookPrice { get; set; }
        public int Count { get; set; }
        public DateTime BuyTime { get; set; }
        public BuyForm()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
    }
}