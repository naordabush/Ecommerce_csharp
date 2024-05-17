using AutoMapper;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DataModel;
using lezioniEcommerce.API.DTO;

namespace lezioniEcommerce.API.Profiles
{
    public class CARTITEMProfile : Profile
    {
        public CARTITEMProfile()
        {
            // read from DB
            CreateMap<CART_ITEMS, READ_CART_ITEM_DTO>();
            // write to DB
            CreateMap<WRITE_CART_ITEM_DTO, CART_ITEMS>();
            CreateMap<READ_CART_ITEM_DTO, CART_ITEMS>();
        }
    }
}
