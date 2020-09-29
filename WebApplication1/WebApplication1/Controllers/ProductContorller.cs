using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 商品
    /// </summary>
    [Route("api/")]
    public class ProductContorller : ControllerBase
    {
        /// <summary>
        /// 取得商品列表
        /// </summary>
        /// <returns></returns>
        [Route("Product")]
        [HttpGet]
        public IEnumerable<ProductModel> GetProductList()
        {
            var repository = new ProductRepository();
            var result = repository.GetProductList();

            return result;
        }

        /// <summary>
        /// 新增商品
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        [Route("Product")]
        [HttpPost]
        public ResultModel CreateProduct([FromBody] ProductModel productModel)
        {
            var result = new ResultModel();
            var repository = new ProductRepository();

            var data = repository.CreateProduct(productModel);

            if (data == true)
            {
                result.Result = data;
                result.Message = "新增商品成功";
            }
            else
            {
                result.Result = data;
                result.Message = "新增商品失敗，請重試";
            }

            return result;
        }
    }
}