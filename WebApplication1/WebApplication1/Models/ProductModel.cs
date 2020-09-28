using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductModel
    {
        /// <summary>
        /// 商品流水號
        /// </summary>
        public int? ProductID { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 供應商ID
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// 種類ID
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// 每單位數量
        /// </summary>
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// 每單位價格
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 每單位稅額
        /// </summary>
        public Int16 UnitsInStock { get; set; }

        /// <summary>
        /// 每單位訂購價
        /// </summary>
        public Int16 UnitsOnOrder { get; set; }

        /// <summary>
        /// 重新訂購等級
        /// </summary>
        public Int16 ReorderLevel { get; set; }

        /// <summary>
        /// 是否已停產
        /// </summary>
        public bool Discontinued { get; set; }
    }
}