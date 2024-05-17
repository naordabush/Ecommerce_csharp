using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DataModel;
using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lezioniEcommerce.API.Repos.Classes
{
    public class CartItemsRepository : ICartItemsRepository
    {
        private readonly DB_ECOMMERCEContext _context;

        public CartItemsRepository(DB_ECOMMERCEContext context)
        {
            _context = context;
        }

        //public async Task<List<CART_ITEMS>> GetAllCartItems()
        //{
        //    return await _context.CART_ITEMS.ToListAsync();
        //}
        //ghfh

        public async Task<List<CART_ITEMS>> GetAllCartItems()
        {
            return await _context.CART_ITEMS
            .Include(ci => ci.PRODUCT)
        //        .ThenInclude(p => p.BRAND)
                .Include(ci => ci.CART)
                .ThenInclude(c => c.USER)
                .ToListAsync();
        }

        //public async Task<CART_ITEMS> GetCartItemById(int id)
        //{
        //    return await _context.CART_ITEMS.FindAsync(id);
        //}

        public async Task<CART_ITEMS> GetCartItemById(int id)
        {
            return await _context.CART_ITEMS
                .Include(ci => ci.PRODUCT)
        //      .ThenInclude(p => p.BRAND)
                .Include(ci => ci.CART)
                .ThenInclude(c => c.USER)
                .FirstOrDefaultAsync(ci => ci.CART_ITEM_ID == id);
        }


        public async Task AddCartItem(CART_ITEMS cartItem)
        {
            _context.CART_ITEMS.Add(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItem(CART_ITEMS updatedCartItem)
        {
            _context.Entry(updatedCartItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartItem(int cartId, int productId)
        {
            var cartItem = await _context.CART_ITEMS
                .Include(ci => ci.CART)
                .Include(ci => ci.PRODUCT)
                .FirstOrDefaultAsync(ci => ci.CART.CART_ID == cartId && ci.PRODUCT.PRODUCT_ID == productId);
            if (cartItem != null)
            {
                _context.CART_ITEMS.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CART_ITEMS> GetCartItemByCartIdAndProductId(int cartId, int productId)
        {
            return await _context.CART_ITEMS
                .Include(ci => ci.CART)
                .Include(ci => ci.PRODUCT)
                .FirstOrDefaultAsync(ci => ci.CART.CART_ID == cartId && ci.PRODUCT.PRODUCT_ID == productId);
        }

        public async Task<List<CART_ITEMS_DETAILS_DTO>> GetCartItemsByCartId(int cartId)
        {
            var cartItems = await _context.CART_ITEMS
                .Where(ci => ci.CART.CART_ID == cartId)
                .Include(ci => ci.PRODUCT)
                .ToListAsync();

            var cartItemDetails = cartItems.Select(ci => new CART_ITEMS_DETAILS_DTO
            {
                ProductId = ci.PRODUCT.PRODUCT_ID,
                ProductName = ci.PRODUCT.PRODUCT_NAME,
                Quantity = ci.CART_ITEM_QUANTITY,
                Price = ci.PRODUCT.PRODUCT_PRICE
            }).ToList();

            return cartItemDetails;
        }

    }
}
