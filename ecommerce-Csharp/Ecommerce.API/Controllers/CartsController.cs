using Ecommerce.API.DTO;
using Ecommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartsService _cartsService;

        public CartsController(ICartsService cartsService)
        {
            _cartsService = cartsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<READ_CART_DTO>>> GetAllCarts()
        {
            var carts = await _cartsService.GetAllCarts();
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<READ_CART_DTO>> GetCartById(int id)
        {
            var cart = await _cartsService.GetCartById(id);
            if (cart == null)
            {
                return BadRequest("Cart not found");
            }
            return Ok(cart);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<READ_CART_DTO>> GetCartByUserId(int userId)
        {
            var cart = await _cartsService.GetCartByUserId(userId);
            if (cart == null)
            {
                return BadRequest("Cart not found for user");
            }
            return Ok(cart);
        }

        [HttpPost]
        public async Task<ActionResult<List<READ_CART_DTO>>> AddCart(WRITE_CART_DTO cart)
        {
            await _cartsService.AddCart(cart);
            return Ok(await _cartsService.GetAllCarts());
        }

        [HttpPut]
        public async Task<ActionResult<List<READ_CART_DTO>>> UpdateCart(WRITE_CART_DTO updatedCart)
        {
            try
            {
                await _cartsService.UpdateCart(updatedCart);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update cart: {ex.Message}");
            }
            return Ok(await _cartsService.GetAllCarts());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<READ_CART_DTO>>> DeleteCart(int id)
        {
            await _cartsService.DeleteCart(id);
            return Ok(await _cartsService.GetAllCarts());
        }
    }
}
