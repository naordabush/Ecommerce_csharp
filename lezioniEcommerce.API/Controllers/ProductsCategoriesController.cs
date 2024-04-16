using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lezioniEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsCategoriesController : ControllerBase
    {
        private readonly IProductsCategoriesService _productsCategoriesService;

        public ProductsCategoriesController(IProductsCategoriesService productsCategoriesService)
        {
            _productsCategoriesService = productsCategoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<READ_PRODUCT_CATEGORY_DTO>>> GetAllProductCategories()
        {
            return Ok(await _productsCategoriesService.GetAllProductCategories());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<READ_PRODUCT_CATEGORY_DTO>> GetProductCategoryById(int id)
        {
            var productCategory = await _productsCategoriesService.GetProductCategoryById(id);
            if (productCategory == null)
            {
                return BadRequest("Product category not found");
            }
            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<ActionResult<List<READ_PRODUCT_CATEGORY_DTO>>> AddProductCategory(WRITE_PRODUCT_CATEGORY_DTO productCategory)
        {
            await _productsCategoriesService.AddProductCategory(productCategory);
            return Ok(await _productsCategoriesService.GetAllProductCategories());
        }

        [HttpPut]
        public async Task<ActionResult<List<READ_PRODUCT_CATEGORY_DTO>>> UpdateProductCategory(WRITE_PRODUCT_CATEGORY_DTO updatedProductCategory)
        {
            try
            {
                await _productsCategoriesService.UpdateProductCategory(updatedProductCategory);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update product category: {ex.Message}");
            }
            return Ok(await _productsCategoriesService.GetAllProductCategories());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<READ_PRODUCT_CATEGORY_DTO>>> DeleteProductCategory(int id)
        {
            await _productsCategoriesService.DeleteProductCategory(id);
            return Ok(await _productsCategoriesService.GetAllProductCategories());
        }
    }
}
