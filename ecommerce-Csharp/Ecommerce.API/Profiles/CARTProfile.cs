using AutoMapper;
using Ecommerce.API.Controllers.DataModel;
using Ecommerce.API.DTO;

namespace Ecommerce.API.Profiles
{
    public class CARTProfile : Profile
    {
        public CARTProfile()
        {
            // read from DB
            CreateMap<CARTS, READ_CART_DTO>();
            // write to DB
            CreateMap<WRITE_CART_DTO, CARTS>();
            CreateMap<READ_CART_DTO, CARTS>();
        }
    }
}
