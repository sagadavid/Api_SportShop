using Api_HPlusSport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_HPlusSport.Controllers
{
    [Route("api/[controller]")]//controller is mapped in route,
                               //so the name of the method will determine to which action will be taken
    [ApiController]
    public class ProductsController : ControllerBase
    {


        private readonly ShopContext _shopContext;
        public ProductsController(ShopContext shopContext)
        {
            _shopContext = shopContext;
            _shopContext.Database.EnsureCreated();
        }
        /*
         * if more than one same httpverb is open, then errors
        Fetch errorresponse status is 500 https://localhost:7175/swagger/v1/swagger.json
*/


        //[HttpGet]//version 0
        //            //name of the method leads,
        //            //but, mentioning the http verb is good practice
        //public string GetStringProducts()
        //{
        //    return "get product method returns only a string";
        //}

        //[HttpGet]//version 1
        //public IEnumerable<Product> GetNumerableProducts()
        //{ return _shopContext.Products.ToArray(); }

        [HttpGet]//version 2
        public async Task<ActionResult> GetActionResultProducts()//returns status code 200 and in payload returns data in json
        {
            //var products = _shopContext.Products.ToList();
            //return Ok(products);
            //return Ok(_shopContext.Products.ToArray());
            return Ok(await _shopContext.Products.ToArrayAsync());
        }

        [HttpGet("{id}")]//version 3
                         //notice a shortend form for route
                         //path is already defined in controller.. so skip it just add id
        public async Task<ActionResult> GetActionResultOneProduct(int id)
        //arguement comes from the route here,
        //alternates are from http body and from query mostly for post,put requests
        {
            //var product = _shopContext.Products.Find(id);
            var product = await _shopContext.Products.FindAsync(id);

            if (product == null) { return NotFound(); }//error message has http lint for details
            return Ok(product);
        }

        //[HttpGet, Route("/products/{id}")]//version 4
        //public Product GetOneProduct(int id)
        //{
        //    var product = _shopContext.Products.Find(id);
        //    return product;
        //}

        [HttpPost]//to prevent 400 error in response to this post,
                  //need to make Category to nullable and 
                  //categoryid to required
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            //if (!ModelState.IsValid) 
            //{
            //return BadRequest();
            //}//to prevent 400 error

        _shopContext.Products.Add(product);
            await _shopContext.SaveChangesAsync();
            return CreatedAtAction(
                "GetProduct",
                new { id = product.Id },
                product
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            //check if there is already
            if (id != product.Id) { return BadRequest(); }

        //pose an update state
        _shopContext.Entry(product).State = EntityState.Modified;

            try
            {
                //update
                await _shopContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //second check because of saving
                //if the product with the id is the one user inputted
                if (!_shopContext.Products.Any(p => p.Id == id))
                { return NotFound(); }
                else { throw; }
            }

            //its an update no need any kind of return
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            //retrieve product
            var product = await _shopContext.Products.FindAsync(id);
            if (product == null) { return NotFound();}

            //means we have product by input id
            _shopContext.Products.Remove(product);
            await _shopContext.SaveChangesAsync();

            return product;//get what was deleted..
                           //a new get request with id causes 404 not found error
                           //405 error on postman vs 200 ok on swagger
        }

        //[HttpDelete("{id}")]
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMulitpleProducts([FromQuery]int[] ids)
        {
            //create a list of products to delete
            var productsToDelete =new List <Product>();
            foreach (var id in ids)
            {
                var product = await _shopContext.Products.FindAsync(id);
                if (product == null) { return NotFound(); }
                productsToDelete.Add(product);
            }
            //pinpoint here is praparing a list for removeRange method of entityframework
            _shopContext.Products.RemoveRange(productsToDelete);
            await _shopContext.SaveChangesAsync();

            return Ok(productsToDelete);
        }

    }
}
