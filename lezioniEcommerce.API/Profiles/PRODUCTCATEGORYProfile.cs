using AutoMapper;
using lezioniEcommerce.API.DataModel;
using lezioniEcommerce.API.DTO;

namespace lezioniEcommerce.API.Profiles
{
    public class PRODUCTCATEGORYProfile : Profile
    {
        public PRODUCTCATEGORYProfile()
        {
            CreateMap<PRODUCTS_CATEGORIES, READ_PRODUCT_CATEGORY_DTO>();
              //  .ForMember(dest => dest.CATEGORY, opt => opt.MapFrom(src => src.CATEGORY))
              //  .ForMember(dest => dest.PRODUCT, opt => opt.MapFrom(src => src.PRODUCT));

            CreateMap<WRITE_PRODUCT_CATEGORY_DTO, PRODUCTS_CATEGORIES>();
             //   .ForMember(dest => dest.CATEGORY_ID, opt => opt.MapFrom(src => src.CATEGORY_ID))
             //   .ForMember(dest => dest.PRODUCT_ID, opt => opt.MapFrom(src => src.PRODUCT_ID))
             //   .ForMember(dest => dest.CATEGORY, opt => opt.Ignore())
             //   .ForMember(dest => dest.PRODUCT, opt => opt.Ignore());
        }
    }
}
