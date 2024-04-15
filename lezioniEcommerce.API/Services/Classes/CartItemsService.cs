using AutoMapper;
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

        public async Task AddCartItem(WRITE_CART_ITEM_DTO cartItem)
        {
            var mappedCartItem = _mapper.Map<CART_ITEMS>(cartItem);
            await _cartItemsRepository.AddCartItem(mappedCartItem);
        }

        public async Task UpdateCartItem(WRITE_CART_ITEM_DTO updatedCartItem)
        {
            var mappedCartItem = _mapper.Map<CART_ITEMS>(updatedCartItem);
            await _cartItemsRepository.UpdateCartItem(mappedCartItem);
        }

        public async Task DeleteCartItem(int id)
        {
            await _cartItemsRepository.DeleteCartItem(id);
        }
    }
}
