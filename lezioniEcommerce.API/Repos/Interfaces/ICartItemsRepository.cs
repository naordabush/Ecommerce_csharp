using System.Collections.Generic;
using System.Threading.Tasks;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DataModel;
using lezioniEcommerce.API.DTO;

namespace lezioniEcommerce.API.Repos.Interfaces
{
    public interface ICartItemsRepository
    {
        Task<List<CART_ITEMS>> GetAllCartItems();
        Task<CART_ITEMS> GetCartItemById(int id);
        Task AddCartItem(CART_ITEMS cartItem);
        Task UpdateCartItem(CART_ITEMS updatedCartItem);
        Task DeleteCartItem(int id);
        Task<CART_ITEMS> GetCartItemByCartIdAndProductId(int cartId, int productId);

    }
}
