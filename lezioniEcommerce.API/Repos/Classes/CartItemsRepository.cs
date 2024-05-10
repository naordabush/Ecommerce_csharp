using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DataModel;
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
        //        .ThenInclude(p => p.BRAND)
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

        public async Task DeleteCartItem(int id)
        {
            var cartItem = await _context.CART_ITEMS.FindAsync(id);
            if (cartItem != null)
            {
                _context.CART_ITEMS.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
