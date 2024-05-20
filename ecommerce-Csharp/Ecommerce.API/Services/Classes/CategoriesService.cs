using Ecommerce.API.DataModel;
using Ecommerce.API.Repos.Interfaces;
using Ecommerce.API.Services.Interfaces;
using AutoMapper;
using Ecommerce.API.DTO;


namespace Ecommerce.API.Services.Classes
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<List<READ_CATEGORY_DTO>> GetAllCategories()
        {
            var categories = await _categoriesRepository.GetAllCategories();
            return _mapper.Map<List<READ_CATEGORY_DTO>>(categories);
        }

        public async Task<READ_CATEGORY_DTO> GetCategoryById(int id)
        {
            var category = await _categoriesRepository.GetCategoryById(id);
            return _mapper.Map<READ_CATEGORY_DTO>(category);
        }

        public async Task AddCategory(WRITE_CATEGORY_DTO category)
        {
            var categoryEntity = _mapper.Map<CATEGORIES>(category);
            await _categoriesRepository.AddCategory(categoryEntity);
        }

        public async Task UpdateCategory(WRITE_CATEGORY_DTO updatedCategory)
        {
            var categoryEntity = _mapper.Map<CATEGORIES>(updatedCategory);
            await _categoriesRepository.UpdateCategory(categoryEntity);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoriesRepository.DeleteCategory(id);
        }
    }
}
