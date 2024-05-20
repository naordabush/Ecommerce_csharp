using AutoMapper;
using Ecommerce.API.DataModel;
using Ecommerce.API.DTO;

namespace Ecommerce.API.Profiles
{
    public class CATEGORYProfile : Profile
    {
        public CATEGORYProfile()
        {
            // read from DB
            CreateMap<CATEGORIES, READ_CATEGORY_DTO>();

            // write to DB
            CreateMap<WRITE_CATEGORY_DTO, CATEGORIES>();
            CreateMap<READ_CATEGORY_DTO, CATEGORIES>();
        }
    }
}
