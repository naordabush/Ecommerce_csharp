using lezioniEcommerce.API.Services.Interfaces;
using lezioniEcommerce.API.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lezioniEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<READ_CATEGORY_DTO>>> GetAllCategories()
        {
            return Ok(await _categoriesService.GetAllCategories());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<READ_CATEGORY_DTO>> GetCategoryById(int id)
        {
            var category = await _categoriesService.GetCategoryById(id);
            if (category == null)
            {
                return BadRequest("Category not found");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<READ_CATEGORY_DTO>>> AddCategory(WRITE_CATEGORY_DTO category)
        {
            await _categoriesService.AddCategory(category);
            return Ok(await _categoriesService.GetAllCategories());
        }

        [HttpPut]
        public async Task<ActionResult<List<READ_CATEGORY_DTO>>> UpdateCategory(WRITE_CATEGORY_DTO updatedCategory)
        {
            try
            {
                await _categoriesService.UpdateCategory(updatedCategory);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update category: {ex.Message}");
            }
            return Ok(await _categoriesService.GetAllCategories());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<READ_CATEGORY_DTO>>> DeleteCategory(int id)
        {
            await _categoriesService.DeleteCategory(id);
            return Ok(await _categoriesService.GetAllCategories());
        }
    }
}
