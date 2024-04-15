using System.Collections.Generic;
using System.Threading.Tasks;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lezioniEcommerce.API.Repos.Classes
{
    public class BrandsRepository : IBrandsRepository
    {
        private readonly DB_ECOMMERCEContext _context;

        public BrandsRepository(DB_ECOMMERCEContext context)
        {
            _context = context;
        }

        public async Task<List<BRANDS>> GetAllBrands()
        {
            return await _context.BRANDS.ToListAsync();
        }

        public async Task<BRANDS> GetBrandById(int id)
        {
            return await _context.BRANDS.FindAsync(id);
        }

        public async Task AddBrand(BRANDS brand)
        {
            _context.BRANDS.Add(brand);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBrand(BRANDS updatedBrand)
        {
            _context.Entry(updatedBrand).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBrand(int id)
        {
            var brand = await _context.BRANDS.FindAsync(id);
            if (brand != null)
            {
                _context.BRANDS.Remove(brand);
                await _context.SaveChangesAsync();
            }
        }
    }
}
