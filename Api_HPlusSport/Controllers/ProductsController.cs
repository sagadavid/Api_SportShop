using Api_HPlusSport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_HPlusSport.Controllers
{
    [Route("api/[controller]")]//controller is mapped in route,
                               //so the name of the method will determine to which action will be taken
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //[HttpGet]//name of the method leads,
        //         //but, mentioning the http verb is good practice
        //public string GetProducts() 
        //{
        //    return "get product method returns only a string";
        //}

        private readonly ShopContext _shopContext;
        public ProductsController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }
        [HttpGet]
        public IEnumerable<Product> GetAllProducts() {
            return _shopContext.Products.ToArray();
        }
    }
}
