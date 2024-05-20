using Ecommerce.API.DTO;

namespace Ecommerce.API.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<READ_CATEGORY_DTO>> GetAllCategories();
        Task<READ_CATEGORY_DTO> GetCategoryById(int id);
        Task AddCategory(WRITE_CATEGORY_DTO category);
        Task UpdateCategory(WRITE_CATEGORY_DTO updatedCategory);
        Task DeleteCategory(int id);
    }
}
