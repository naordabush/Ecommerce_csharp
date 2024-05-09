
using lezioniEcommerce.API.Controllers.DataModel;

namespace lezioniEcommerce.API.Repos.Interfaces
{
    public interface ICartsRepository
    {
        Task<List<CARTS>> GetAllCarts();
        Task<CARTS> GetCartById(int id);
        Task AddCart(CARTS cart);
        Task UpdateCart(CARTS updatedCart);
        Task DeleteCart(int id);
        Task<CARTS> GetCartByUserId(int userId);
    }
}
