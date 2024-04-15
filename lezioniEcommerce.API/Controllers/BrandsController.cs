using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lezioniEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsService _brandsService;

        public BrandsController(IBrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<READ_BRAND_DTO>>> GetAllBrands()
        {
            var brands = await _brandsService.GetAllBrands();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<READ_BRAND_DTO>> GetBrandById(int id)
        {
            var brand = await _brandsService.GetBrandById(id);
            if (brand == null)
            {
                return BadRequest("Brand not found");
            }
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<List<READ_BRAND_DTO>>> AddBrand(WRITE_BRAND_DTO brand)
        {
            await _brandsService.AddBrand(brand);
            return Ok(await _brandsService.GetAllBrands());
        }

        [HttpPut]
        public async Task<ActionResult<List<READ_BRAND_DTO>>> UpdateBrand(WRITE_BRAND_DTO updatedBrand)
        {
            try
            {
                await _brandsService.UpdateBrand(updatedBrand);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update brand: {ex.Message}");
            }
            return Ok(await _brandsService.GetAllBrands());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<READ_BRAND_DTO>>> DeleteBrand(int id)
        {
            await _brandsService.DeleteBrand(id);
            return Ok(await _brandsService.GetAllBrands());
        }
    }
}
