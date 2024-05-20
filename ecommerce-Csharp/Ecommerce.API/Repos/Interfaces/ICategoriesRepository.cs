using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.API.Controllers.DataModel;
using Ecommerce.API.DataModel;

namespace Ecommerce.API.Repos.Interfaces
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
