using Ecommerce.API.Controllers.DataModel;
using Ecommerce.API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repos.Classes
{
    public class CartsRepository : ICartsRepository
    {
        private readonly DB_ECOMMERCEContext _context;

        public CartsRepository(DB_ECOMMERCEContext context)
        {
            _context = context;
        }

        //public async Task<List<CARTS>> GetAllCarts()
        //{
        //    return await _context.CARTS.ToListAsync();
        //}

        public async Task<List<CARTS>> GetAllCarts()
        {
            return await _context.CARTS
                .Include(c => c.USER)
                .ToListAsync();
        }

        //public async Task<CARTS> GetCartById(int id)
        //{
        //    return await _context.CARTS.FindAsync(id);
        //}

        public async Task<CARTS> GetCartById(int id)
        {
            return await _context.CARTS
                .Include(c => c.USER)
                .FirstOrDefaultAsync(c => c.CART_ID == id);
        }


        public async Task AddCart(CARTS cart)
        {
            _context.CARTS.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCart(CARTS updatedCart)
        {
            _context.Entry(updatedCart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCart(int id)
        {
            var cart = await _context.CARTS.FindAsync(id);
            if (cart != null)
            {
                _context.CARTS.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<CARTS> GetCartByUserId(int userId)
        {
            return await _context.CARTS
                .Include(c => c.USER)
                .FirstOrDefaultAsync(c => c.USER_ID == userId);
        }


    }
}
