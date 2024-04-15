using lezioniEcommerce.API.DTO;

namespace lezioniEcommerce.API.Services.Interfaces
{
    public interface IProductsCategoriesService
    {
        Task<List<READ_PRODUCT_CATEGORY_DTO>> GetAllProductCategories();
        Task<READ_PRODUCT_CATEGORY_DTO> GetProductCategoryById(int id);
        Task AddProductCategory(WRITE_PRODUCT_CATEGORY_DTO productCategory);
        Task UpdateProductCategory(WRITE_PRODUCT_CATEGORY_DTO updatedProductCategory);
        Task DeleteProductCategory(int id);
    }
}
