using Ecommerce.API.DataModel;

namespace Ecommerce.API.Repos.Interfaces
{
    public interface IProductsCategoriesRepository
    {
        Task<List<PRODUCTS_CATEGORIES>> GetAllProductCategories();
        Task<PRODUCTS_CATEGORIES> GetProductCategoryById(int id);
        Task AddProductCategory(PRODUCTS_CATEGORIES productCategory);
        Task UpdateProductCategory(PRODUCTS_CATEGORIES updatedProductCategory);
        Task DeleteProductCategory(int id);
    }
}
