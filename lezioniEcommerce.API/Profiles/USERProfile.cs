using AutoMapper;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DTO;


namespace lezioniEcommerce.API.Profiles
{
    public class USERProfile : Profile
    {
        public USERProfile()
        {
            // read from DB
            CreateMap<USERS, READ_USER_DTO>();

            // write DB
            CreateMap<WRITE_USER_DTO, USERS>();
            CreateMap<READ_USER_DTO, USERS>();

            // Additional mapping for login response DTO
            CreateMap<USERS, LOGIN_REQUEST_DTO>(); 

        }
    }
}
