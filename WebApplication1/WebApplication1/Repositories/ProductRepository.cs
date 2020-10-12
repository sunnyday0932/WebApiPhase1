using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductRepository
    {
        /// <summary>
        /// 取得產品列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetProductList()
        {
            var sql = @"SELECT productid,
                               productname,
                               supplierid,
                               categoryid,
                               quantityperunit,
                               unitprice,
                               unitsinstock,
                               unitsonorder,
                               reorderlevel,
                               discontinued
                        FROM   products ";

            var connection = new SqlConnection(ConnectionHelper.ConnectionStr);

            var result = connection.Query<ProductModel>(sql);

            return result;
        }

        /// <summary>
        /// 新增一筆商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public bool CreateProduct(ProductModel productModel)
        {
            var sql = @"INSERT INTO products
                                (productname,
                                 supplierid,
                                 categoryid,
                                 quantityperunit,
                                 unitprice,
                                 unitsinstock,
                                 unitsonorder,
                                 reorderlevel,
                                 discontinued)
                         VALUES (@ProductName,
                                 @SupplierID,
                                 @CategoryID,
                                 @QuantityPerUnit,
                                 @UnitPrice,
                                 @UnitsInStock,
                                 @UnitsOnOrder,
                                 @ReorderLevel,
                                 @Discontinued) ";

            var parameters = new DynamicParameters();
            parameters.Add("@ProductName", productModel.ProductName);
            parameters.Add("@SupplierID", productModel.SupplierID);
            parameters.Add("@CategoryID", productModel.CategoryID);
            parameters.Add("@QuantityPerUnit", productModel.QuantityPerUnit);
            parameters.Add("@UnitPrice", productModel.UnitPrice);
            parameters.Add("@UnitsInStock", productModel.UnitsInStock);
            parameters.Add("@UnitsOnOrder", productModel.UnitsOnOrder);
            parameters.Add("@ReorderLevel", productModel.ReorderLevel);
            parameters.Add("@Discontinued", productModel.Discontinued);

            var connection = new SqlConnection(ConnectionHelper.ConnectionStr);

            var result = connection.Execute(sql, parameters);

            return result > 0;
        }

        /// <summary>
        /// 修改商品內容
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public bool UpdateProduct(ProductModel productModel)
        {
            var sql = @"UPDATE products
                        SET    productname = @ProductName,
                               supplierid = @SupplierID,
                               categoryid = @CategoryID,
                               quantityperunit = @QuantityPerUnit,
                               unitprice = @UnitPrice,
                               unitsinstock = @UnitsInStock,
                               unitsonorder = @UnitsOnOrder,
                               reorderlevel = @ReorderLevel,
                               discontinued = @Discontinued
                        WHERE productid = @ProductID ";

            var parameters = new DynamicParameters();
            parameters.Add("@ProductName", productModel.ProductName);
            parameters.Add("@SupplierID", productModel.SupplierID);
            parameters.Add("@CategoryID", productModel.CategoryID);
            parameters.Add("@QuantityPerUnit", productModel.QuantityPerUnit);
            parameters.Add("@UnitPrice", productModel.UnitPrice);
            parameters.Add("@UnitsInStock", productModel.UnitsInStock);
            parameters.Add("@UnitsOnOrder", productModel.UnitsOnOrder);
            parameters.Add("@ReorderLevel", productModel.ReorderLevel);
            parameters.Add("@Discontinued", productModel.Discontinued);
            parameters.Add("@ProductID", productModel.ProductID);

            var connection = new SqlConnection(ConnectionHelper.ConnectionStr);

            var result = connection.Execute(
                sql,
                parameters);

            return result > 0;
        }

        /// <summary>
        /// 刪除指定的商品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool RemoveProduct(int productId)
        {
            var sql = @"DELETE products
                        WHERE  productid = @ProductID ";

            var parameter = new DynamicParameters();
            parameter.Add("@ProductID", productId);

            var connection = new SqlConnection(ConnectionHelper.ConnectionStr);

            var result = connection.Execute(
                sql,
                parameter);

            return result > 0;
        }
    }
}