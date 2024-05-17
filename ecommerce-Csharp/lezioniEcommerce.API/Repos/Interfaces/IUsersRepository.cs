using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DTO;

namespace lezioniEcommerce.API.Repos.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<USERS>> GetAllUsers();
        Task<USERS> GetUserById(int id);
        Task register(USERS user);
        Task UpdateUser(USERS updatedUserDto);
        Task DeleteUser(int id);
        Task<USERS> FindByUsername(string username);

    }
}

