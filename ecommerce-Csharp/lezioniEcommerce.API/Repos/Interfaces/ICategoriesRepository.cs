using System.Collections.Generic;
using System.Threading.Tasks;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DataModel;

namespace lezioniEcommerce.API.Repos.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<CATEGORIES>> GetAllCategories();
        Task<CATEGORIES> GetCategoryById(int id);
        Task AddCategory(CATEGORIES category);
        Task UpdateCategory(CATEGORIES updatedCategory);
        Task DeleteCategory(int id);
    }
}
