using AutoMapper;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Repos.Interfaces;
using lezioniEcommerce.API.Services.Interfaces;


namespace lezioniEcommerce.API.Services.Classes
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<List<READ_PRODUCT_DTO>> GetAllProducts()
        {
            var products = await _productsRepository.GetAllProducts();
            return _mapper.Map<List<READ_PRODUCT_DTO>>(products);
        }

        public async Task<READ_PRODUCT_DTO> GetProductById(int id)
        {
            var product = await _productsRepository.GetProductById(id);
            return _mapper.Map<READ_PRODUCT_DTO>(product);
        }

        public async Task AddProduct(WRITE_PRODUCT_DTO product)
        {
            var mappedProduct = _mapper.Map<PRODUCTS>(product);
            await _productsRepository.AddProduct(mappedProduct);
        }

        public async Task UpdateProduct(READ_PRODUCT_DTO updatedProduct)
        {
            var mappedProduct = _mapper.Map<PRODUCTS>(updatedProduct);
            await _productsRepository.UpdateProduct(mappedProduct);
        }

        public async Task DeleteProduct(int id)
        {
            await _productsRepository.DeleteProduct(id);
        }
    }
}
