using Ecommerce.API.DTO;
using Ecommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductController(IProductsService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<READ_PRODUCT_DTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<READ_PRODUCT_DTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return BadRequest("Product not found");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(WRITE_PRODUCT_DTO product)
        {
            try
            {
                await _productService.AddProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add product: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(READ_PRODUCT_DTO updatedProduct)
        {
            try
            {
                await _productService.UpdateProduct(updatedProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update product: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete product: {ex.Message}");
            }
        }
    }
}
