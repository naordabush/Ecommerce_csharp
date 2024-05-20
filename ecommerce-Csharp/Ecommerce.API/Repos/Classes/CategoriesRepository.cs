using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.API.Controllers.DataModel;
using Ecommerce.API.DataModel;
using Ecommerce.API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repos.Classes
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DB_ECOMMERCEContext _context;

        public CategoriesRepository(DB_ECOMMERCEContext context)
        {
            _context = context;
        }

        public async Task<List<CATEGORIES>> GetAllCategories()
        {
                //      return await _context.CATEGORIES
                //.Include(c => c.ProductsCategories)
                //.ToListAsync();
            
            return await _context.CATEGORIES.ToListAsync();
        }

        public async Task<CATEGORIES> GetCategoryById(int id)
        {
            return await _context.CATEGORIES.FindAsync(id);
        }

        public async Task AddCategory(CATEGORIES category)
        {
            _context.CATEGORIES.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(CATEGORIES updatedCategory)
        {
            _context.Entry(updatedCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.CATEGORIES.FindAsync(id);
            if (category != null)
            {
                _context.CATEGORIES.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
