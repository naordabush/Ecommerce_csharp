using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lezioniEcommerce.API.Repos.Classes
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly DB_ECOMMERCEContext _context;

        public ProductsRepository(DB_ECOMMERCEContext context)
        {
            _context = context;
        }

        public async Task<List<PRODUCTS>> GetAllProducts()
        {
            return await _context.PRODUCTS.ToListAsync();
        }

        //public async Task<List<PRODUCTS>> GetAllProducts()
        //{
        //    return await _context.PRODUCTS
        //        .Include(p => p.BRAND)
        //        .ToListAsync();
        //}
        public async Task<PRODUCTS> GetProductById(int id)
        {
            return await _context.PRODUCTS.FindAsync(id);
        }

        //public async Task<PRODUCTS> GetProductById(int id)
        //{
        //    return await _context.PRODUCTS
        //        .Include(p => p.BRAND)
        //        .FirstOrDefaultAsync(p => p.PRODUCT_ID == id);
        //}
        public async Task AddProduct(PRODUCTS product)
        {
            _context.PRODUCTS.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(PRODUCTS updatedProduct)
        {
            _context.Entry(updatedProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.PRODUCTS.FindAsync(id);
            if (product != null)
            {
                _context.PRODUCTS.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
