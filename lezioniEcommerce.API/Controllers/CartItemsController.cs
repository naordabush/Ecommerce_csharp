using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lezioniEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemsService _cartItemsService;

        public CartItemsController(ICartItemsService cartItemsService)
        {
            _cartItemsService = cartItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<READ_CART_ITEM_DTO>>> GetAllCartItems()
        {
            return Ok(await _cartItemsService.GetAllCartItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<READ_CART_ITEM_DTO>> GetCartItemById(int id)
        {
            var cartItem = await _cartItemsService.GetCartItemById(id);
            if (cartItem == null)
            {
                return BadRequest("Cart item not found");
            }
            return Ok(cartItem);
        }

        //[HttpPost]
        //public async Task<ActionResult<List<READ_CART_ITEM_DTO>>> AddCartItem(WRITE_CART_ITEM_DTO cartItem)
        //{
        //    await _cartItemsService.AddCartItem(cartItem);
        //    return Ok(await _cartItemsService.GetAllCartItems());
        //}

        [HttpPost]
        public async Task<ActionResult<List<READ_CART_ITEM_DTO>>> AddCartItem(int cartId, int productId, int quantity)
        {
            try
            {
                var existingCartItem = await _cartItemsService.GetCartItemByCartIdAndProductId(cartId, productId);
                if (existingCartItem != null)
                {
                    existingCartItem.CART_ITEM_QUANTITY += quantity;
                    await _cartItemsService.UpdateCartItem(existingCartItem);
                }
                else
                {
                    await _cartItemsService.AddCartItem(cartId, productId, quantity);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add cart item: {ex.Message}");
            }
            return Ok(await _cartItemsService.GetAllCartItems());
        }

        [HttpPut]
        public async Task<ActionResult<List<READ_CART_ITEM_DTO>>> UpdateCartItem(WRITE_CART_ITEM_DTO updatedCartItem)
        {
            try
            {
                await _cartItemsService.UpdateCartItem(updatedCartItem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update cart item: {ex.Message}");
            }
            return Ok(await _cartItemsService.GetAllCartItems());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<READ_CART_ITEM_DTO>>> DeleteCartItem(int id)
        {
            await _cartItemsService.DeleteCartItem(id);
            return Ok(await _cartItemsService.GetAllCartItems());
        }

        [HttpGet("cart/{cartId}")]
        public async Task<ActionResult<List<CART_ITEMS_DETAILS_DTO>>> GetCartItemsByCartId(int cartId)
        {
            var cartItems = await _cartItemsService.GetCartItemsByCartId(cartId);
            if (cartItems == null || cartItems.Count == 0)
            {
                return NotFound("No cart items found for the given cart ID.");
            }
            return Ok(cartItems);
        }
    }
}
