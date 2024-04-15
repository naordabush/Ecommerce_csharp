using System.Collections.Generic;
using System.Threading.Tasks;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DataModel;
using lezioniEcommerce.API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lezioniEcommerce.API.Repos.Classes
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
