using Ecommerce.API.Controllers.DataModel;

namespace Ecommerce.API.Repos.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<PRODUCTS>> GetAllProducts();
        Task<PRODUCTS> GetProductById(int id);
        Task AddProduct(PRODUCTS product);
        Task UpdateProduct(PRODUCTS updatedProduct);
        Task DeleteProduct(int id);
    }
}
