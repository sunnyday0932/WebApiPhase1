using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/")]
    public class ProductContorller : ControllerBase
    {
        [Route("Product")]
        [HttpGet]
        public IEnumerable<ProductModel> GetProductList()
        {
            var repository = new ProductRepository();
            var result = repository.GetProductList();

            return result;
        }

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