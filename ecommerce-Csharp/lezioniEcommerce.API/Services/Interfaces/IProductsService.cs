using lezioniEcommerce.API.DTO;

namespace lezioniEcommerce.API.Services.Interfaces
{
    public interface IProductsService
    {
        Task<List<READ_PRODUCT_DTO>> GetAllProducts();
        Task<READ_PRODUCT_DTO> GetProductById(int id);
        Task AddProduct(WRITE_PRODUCT_DTO product);
        Task UpdateProduct(READ_PRODUCT_DTO updatedProduct);
        Task DeleteProduct(int id);
    }
}
