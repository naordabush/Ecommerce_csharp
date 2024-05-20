using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.API.Controllers.DataModel;
using Ecommerce.API.DataModel;
using Ecommerce.API.DTO;

namespace Ecommerce.API.Repos.Interfaces
{
    public interface ICartItemsRepository
    {
        Task<List<CART_ITEMS>> GetAllCartItems();
        Task<CART_ITEMS> GetCartItemById(int id);
        Task AddCartItem(CART_ITEMS cartItem);
        Task UpdateCartItem(CART_ITEMS updatedCartItem);
        Task DeleteCartItem(int cartId, int ProductId);
        Task<CART_ITEMS> GetCartItemByCartIdAndProductId(int cartId, int productId);
        Task<List<CART_ITEMS_DETAILS_DTO>> GetCartItemsByCartId(int cartId);
    }
}
