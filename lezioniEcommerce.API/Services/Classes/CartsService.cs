using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Repos.Interfaces;
using lezioniEcommerce.API.Services.Interfaces;

namespace lezioniEcommerce.API.Services.Classes
{
    public class CartsService : ICartsService
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IMapper _mapper;

        public CartsService(ICartsRepository cartsRepository, IMapper mapper)
        {
            _cartsRepository = cartsRepository;
            _mapper = mapper;
        }

        public async Task<List<READ_CART_DTO>> GetAllCarts()
        {
            var carts = await _cartsRepository.GetAllCarts();
            return _mapper.Map<List<READ_CART_DTO>>(carts);
        }

        public async Task<READ_CART_DTO> GetCartById(int id)
        {
            var cart = await _cartsRepository.GetCartById(id);
            return _mapper.Map<READ_CART_DTO>(cart);
        }

        public async Task AddCart(WRITE_CART_DTO cart)
        {
            var cartEntity = _mapper.Map<CARTS>(cart);
            await _cartsRepository.AddCart(cartEntity);
        }

        public async Task UpdateCart(WRITE_CART_DTO updatedCart)
        {
            var cartEntity = _mapper.Map<CARTS>(updatedCart);
            await _cartsRepository.UpdateCart(cartEntity);
        }

        public async Task DeleteCart(int id)
        {
            await _cartsRepository.DeleteCart(id);
        }
    }
}
