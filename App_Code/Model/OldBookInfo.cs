using System;

namespace Model
{

    /// <summary>
    /// 二手书信息模型
    /// </summary>

    public class OldBookInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
        public int TypeId { get; set; }
        public bool IsBidding { get; set; }
        public string Buyer { get; set; }
        public string Seller { get; set; }
        public DateTime Time { get; set; }
        public int Number { get; set; }
    }
}


