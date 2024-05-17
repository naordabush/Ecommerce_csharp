using AutoMapper;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DataModel;
using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Repos.Interfaces;
using lezioniEcommerce.API.Services.Interfaces;

namespace lezioniEcommerce.API.Services.Classes
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ICartItemsRepository _cartItemsRepository;
        private readonly IMapper _mapper;

        public CartItemsService(ICartItemsRepository cartItemsRepository, IMapper mapper)
        {
            _cartItemsRepository = cartItemsRepository;
            _mapper = mapper;
        }

        public async Task<List<READ_CART_ITEM_DTO>> GetAllCartItems()
        {
            var cartItems = await _cartItemsRepository.GetAllCartItems();
            return _mapper.Map<List<READ_CART_ITEM_DTO>>(cartItems);
        }

        public async Task<READ_CART_ITEM_DTO> GetCartItemById(int id)
        {
            var cartItem = await _cartItemsRepository.GetCartItemById(id);
            return _mapper.Map<READ_CART_ITEM_DTO>(cartItem);
        }

        //public async Task AddCartItem(WRITE_CART_ITEM_DTO cartItem)
        //{
        //    var mappedCartItem = _mapper.Map<CART_ITEMS>(cartItem);
        //    await _cartItemsRepository.AddCartItem(mappedCartItem);
        //}
        public async Task AddCartItem(int cartId, int productId, int quantity)
        {
            var cartItem = new CART_ITEMS
            {
                CART_ID = cartId,
                PRODUCT_ID = productId,
                CART_ITEM_QUANTITY = quantity
            };
            await _cartItemsRepository.AddCartItem(cartItem);
        }
        public async Task<READ_CART_ITEM_DTO> GetCartItemByCartIdAndProductId(int cartId, int productId)
        {
            var cartItemEntity = await _cartItemsRepository.GetCartItemByCartIdAndProductId(cartId, productId);
            if (cartItemEntity == null)
            {
                return null;
            }
            var cartItemDto = _mapper.Map<READ_CART_ITEM_DTO>(cartItemEntity);
            return cartItemDto;
        }

        public async Task UpdateCartItem(WRITE_CART_ITEM_DTO updatedCartItem)
        {
            var mappedCartItem = _mapper.Map<CART_ITEMS>(updatedCartItem);
            await _cartItemsRepository.UpdateCartItem(mappedCartItem);
        }
        public async Task<List<CART_ITEMS_DETAILS_DTO>> GetCartItemsByCartId(int cartId)
        {
            return await _cartItemsRepository.GetCartItemsByCartId(cartId);
        }
        public async Task DeleteCartItem(int cartId, int ProductId)
        {
            await _cartItemsRepository.DeleteCartItem(cartId, ProductId);
        }

    }
}
