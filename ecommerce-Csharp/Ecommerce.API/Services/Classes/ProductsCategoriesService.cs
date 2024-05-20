using Ecommerce.API.DTO;
using Ecommerce.API.Repos.Interfaces;
using Ecommerce.API.Services.Interfaces;
using AutoMapper;
using Ecommerce.API.DataModel;

namespace Ecommerce.API.Services.Classes
{
    public class ProductsCategoriesService : IProductsCategoriesService
    {
        private readonly IProductsCategoriesRepository _productsCategoriesRepository;
        private readonly IMapper _mapper;

        public ProductsCategoriesService(IProductsCategoriesRepository productsCategoriesRepository, IMapper mapper)
        {
            _productsCategoriesRepository = productsCategoriesRepository;
            _mapper = mapper;
        }

        public async Task<List<READ_PRODUCT_CATEGORY_DTO>> GetAllProductCategories()
        {
            var productCategories = await _productsCategoriesRepository.GetAllProductCategories();
            return _mapper.Map<List<READ_PRODUCT_CATEGORY_DTO>>(productCategories);
        }

        public async Task<READ_PRODUCT_CATEGORY_DTO> GetProductCategoryById(int id)
        {
            var productCategory = await _productsCategoriesRepository.GetProductCategoryById(id);
            return _mapper.Map<READ_PRODUCT_CATEGORY_DTO>(productCategory);
        }

        public async Task AddProductCategory(WRITE_PRODUCT_CATEGORY_DTO productCategory)
        {
            var productCategoryEntity = _mapper.Map<PRODUCTS_CATEGORIES>(productCategory);
            await _productsCategoriesRepository.AddProductCategory(productCategoryEntity);
        }

        public async Task UpdateProductCategory(WRITE_PRODUCT_CATEGORY_DTO updatedProductCategory)
        {
            var productCategoryEntity = _mapper.Map<PRODUCTS_CATEGORIES>(updatedProductCategory);
            await _productsCategoriesRepository.UpdateProductCategory(productCategoryEntity);
        }

        public async Task DeleteProductCategory(int id)
        {
            await _productsCategoriesRepository.DeleteProductCategory(id);
        }
    }
}
