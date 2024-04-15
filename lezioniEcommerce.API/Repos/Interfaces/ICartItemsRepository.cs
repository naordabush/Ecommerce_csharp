using System.Collections.Generic;
using System.Threading.Tasks;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DataModel;

namespace lezioniEcommerce.API.Repos.Interfaces
{
    public interface ICartItemsRepository
    {
        Task<List<CART_ITEMS>> GetAllCartItems();
        Task<CART_ITEMS> GetCartItemById(int id);
        Task AddCartItem(CART_ITEMS cartItem);
        Task UpdateCartItem(CART_ITEMS updatedCartItem);
        Task DeleteCartItem(int id);
    }
}
