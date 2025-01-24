using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

/* Controller Actions:
Implement actions in the ProductsController to interact with the ProductService.
Use appropriate HTTP methods (GET, POST, PUT, DELETE) for each action.
 */

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _productService.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id) return BadRequest();
            await _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryId(categoryId);
            return Ok(products);
        }

        [HttpGet("category/{categoryId}/total-price")]
        public async Task<IActionResult> GetTotalPriceByCategoryId(int categoryId)
        {
            var totalPrice = await _productService.GetTotalPriceByCategoryId(categoryId);
            return Ok(totalPrice);
        }

        [HttpGet("total-price-per-category")]
        public async Task<IActionResult> GetTotalPricePerCategory()
        {
            var result = await _productService.GetTotalPricePerCategory();
            return Ok(result);
        }
    }
}