using System.Collections.Generic;
using System.Threading.Tasks;
using lezioniEcommerce.API.DTO;

namespace lezioniEcommerce.API.Services.Interfaces
{
    public interface ICartsService
    {
        Task<List<READ_CART_DTO>> GetAllCarts();
        Task<READ_CART_DTO> GetCartById(int id);
        Task AddCart(WRITE_CART_DTO cart);
        Task UpdateCart(WRITE_CART_DTO updatedCart);
        Task DeleteCart(int id);
        Task<READ_CART_DTO> GetCartByUserId(int userId);
    }
}
