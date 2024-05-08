using AutoMapper;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Repos.Classes;
using lezioniEcommerce.API.Repos.Interfaces;
using lezioniEcommerce.API.Services.Interfaces;

namespace lezioniEcommerce.API.Services.Classes
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<List<READ_USER_DTO>> GetAllUsers()
        {
            var users = await _usersRepository.GetAllUsers();
            return _mapper.Map<List<READ_USER_DTO>>(users);
        }

        public async Task<READ_USER_DTO> GetUserById(int id)
        {
            var user = await _usersRepository.GetUserById(id);
            return _mapper.Map<READ_USER_DTO>(user);
        }
        public async Task AddUser(WRITE_USER_DTO userDto)
        {
            var user = _mapper.Map<USERS>(userDto);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.USER_PASSWORD);
            user.USER_PASSWORD = hashedPassword;
            await _usersRepository.AddUser(user);
        }

        public async Task UpdateUser(READ_USER_DTO updatedUserDto)
        {
            var existingUser = await _usersRepository.GetUserById(updatedUserDto.USER_ID);
            if (existingUser == null)
            {
                throw new ArgumentException($"User with ID {updatedUserDto.USER_ID} not found");
            }

            existingUser.USER_USERNAME = updatedUserDto.USER_USERNAME;
            existingUser.USER_FIRSTNAME = updatedUserDto.USER_FIRSTNAME;
            existingUser.USER_LASTNAME = updatedUserDto.USER_LASTNAME;
            existingUser.USER_EMAIL = updatedUserDto.USER_EMAIL;

            if (!string.IsNullOrEmpty(updatedUserDto.USER_PASSWORD))
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(updatedUserDto.USER_PASSWORD);
                existingUser.USER_PASSWORD = hashedPassword;
            }
            await _usersRepository.UpdateUser(existingUser);
        }

        public async Task DeleteUser(int id)
        {
            await _usersRepository.DeleteUser(id);
        }

        //--------------FindByUsername-Register-Login-Logout------------------
        public async Task<READ_USER_DTO> FindUserByUsername(string username)
        {
            var user = await _usersRepository.FindByUsername(username);
            return _mapper.Map<READ_USER_DTO>(user);
        }

        public async Task<bool> Login(string username, string password)
        {
            var user = await FindUserByUsername(username);
            if (user == null)
            {
                return false;
            }
            return BCrypt.Net.BCrypt.Verify(password, user.USER_PASSWORD);
        }



    }
}
