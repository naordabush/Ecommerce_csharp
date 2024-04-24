using lezioniEcommerce.API.DTO;

namespace lezioniEcommerce.API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<List<READ_USER_DTO>> GetAllUsers();
        Task<READ_USER_DTO> GetUserById(int id);
        Task AddUser(WRITE_USER_DTO userDto);
        Task UpdateUser(READ_USER_DTO updatedUserDto);
        Task DeleteUser(int id);
        Task<READ_USER_DTO> FindUserByUsername(string username);
        Task<bool> Login(string username, string password);
    }
}