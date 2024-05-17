using lezioniEcommerce.API.Controllers.DataModel;

namespace lezioniEcommerce.API.Repos.Interfaces
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
