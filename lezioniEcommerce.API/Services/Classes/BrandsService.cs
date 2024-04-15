
using AutoMapper;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Repos.Interfaces;
using lezioniEcommerce.API.Services.Interfaces;

namespace lezioniEcommerce.API.Services.Classes
{
    public class BrandsService : IBrandsService
    {
        private readonly IBrandsRepository _brandsRepository;
        private readonly IMapper _mapper;

        public BrandsService(IBrandsRepository brandsRepository, IMapper mapper)
        {
            _brandsRepository = brandsRepository;
            _mapper = mapper;
        }

        public async Task<List<READ_BRAND_DTO>> GetAllBrands()
        {
            var brands = await _brandsRepository.GetAllBrands();
            return _mapper.Map<List<READ_BRAND_DTO>>(brands);
        }

        public async Task<READ_BRAND_DTO> GetBrandById(int id)
        {
            var brand = await _brandsRepository.GetBrandById(id);
            return _mapper.Map<READ_BRAND_DTO>(brand);
        }

        public async Task AddBrand(WRITE_BRAND_DTO brand)
        {
            var brandEntity = _mapper.Map<BRANDS>(brand);
            await _brandsRepository.AddBrand(brandEntity);
        }

        public async Task UpdateBrand(WRITE_BRAND_DTO updatedBrand)
        {
            var brandEntity = _mapper.Map<BRANDS>(updatedBrand);
            await _brandsRepository.UpdateBrand(brandEntity);
        }

        public async Task DeleteBrand(int id)
        {
            await _brandsRepository.DeleteBrand(id);
        }
    }
}
