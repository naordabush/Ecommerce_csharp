using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.API.Controllers.DataModel;
using Ecommerce.API.DataModel;
using Ecommerce.API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repos.Classes
{
    public class ProductsCategoriesRepository : IProductsCategoriesRepository
    {
        private readonly DB_ECOMMERCEContext _context;

        public ProductsCategoriesRepository(DB_ECOMMERCEContext context)
        {
            _context = context;
        }

        public async Task<List<PRODUCTS_CATEGORIES>> GetAllProductCategories()
        {
            return await _context.PRODUCTS_CATEGORIES
                .Include(pc => pc.PRODUCT)
                .Include(pc => pc.CATEGORY)
                .ToListAsync();
        }

        //public async Task<List<PRODUCTS_CATEGORIES>> GetAllProductCategories()
        //{
        //    return await _context.PRODUCTS_CATEGORIES
        //        .Include(pc => pc.PRODUCTS)
        //        .ThenInclude(p => p.BRAND)
        //        .Include(pc => pc.CATEGORIES)
        //        .ToListAsync();
        //}

        public async Task<PRODUCTS_CATEGORIES> GetProductCategoryById(int id)
        {
            return await _context.PRODUCTS_CATEGORIES.FindAsync(id);
        }

        //public async Task<PRODUCTS_CATEGORIES> GetProductCategoryById(int id)
        //{
        //    return await _context.PRODUCTS_CATEGORIES
        //        .Include(pc => pc.PRODUCTS)
        //        .ThenInclude(p => p.BRAND)
        //        .Include(pc => pc.CATEGORIES)
        //        .FirstOrDefaultAsync(pc => pc.PRODUCT_CATEGORY_ID == id);
        //}

        public async Task AddProductCategory(PRODUCTS_CATEGORIES productCategory)
        {
            _context.PRODUCTS_CATEGORIES.Add(productCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductCategory(PRODUCTS_CATEGORIES updatedProductCategory)
        {
            _context.Entry(updatedProductCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductCategory(int id)
        {
            var productCategory = await _context.PRODUCTS_CATEGORIES.FindAsync(id);
            if (productCategory != null)
            {
                _context.PRODUCTS_CATEGORIES.Remove(productCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
