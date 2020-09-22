using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("Product")]
    public class ProductContorller : ControllerBase
    {
        [Route("List")]
        [HttpGet]
        public IEnumerable<ProductModel> GetProductList()
        {
            var repository = new ProductRepository();
            var result = repository.GetProductList();

            return result;
        }
    }
}