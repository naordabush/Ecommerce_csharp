using AutoMapper;
using Ecommerce.API.Controllers.DataModel;
using Ecommerce.API.DTO;

namespace Ecommerce.API.Profiles
{
    public class PRODUCTProfile : Profile
    {
        public PRODUCTProfile()
        {
            // read from DB
            CreateMap<PRODUCTS, READ_PRODUCT_DTO>();

            // write to DB
            CreateMap<WRITE_PRODUCT_DTO, PRODUCTS>();
            CreateMap<READ_PRODUCT_DTO, PRODUCTS>();
        }
    }
}
