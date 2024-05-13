using AutoMapper;
using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Repos.Interfaces;
using lezioniEcommerce.API.Services.Interfaces;

namespace lezioniEcommerce.API.Services.Classes
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
      private readonly ICartsRepository _cartsRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, ICartsRepository cartsRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _cartsRepository = cartsRepository;
            _mapper = mapper;
        }
        //--------------FindByUsername-Register-Login-Logout------------------

        public async Task<(bool, string)> Login(string username, string password)
        {
            var user = await FindUserByUsername(username);
            if (user == null)
            {
                return (false, null); // User not found
            }

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.USER_PASSWORD);
            if (!isPasswordCorrect)
            {
                return (false, null); // Password incorrect
            }

            // Generate JWT token
            string token = JwtTokenGenerator.GenerateToken(user.USER_ID.ToString());

            // Retrieve or create cart
            var cart = await _cartsRepository.GetCartByUserId(user.USER_ID);
            if (cart != null)
            {
                Console.WriteLine($"Cart found for user {user.USER_ID}: {cart.CART_ID}");
            }
            else
            {
                // Create a new cart and associate it with the user
                cart = new CARTS { USER_ID = user.USER_ID };
                await _cartsRepository.AddCart(cart);
                Console.WriteLine($"New cart created for user {user.USER_ID}: {cart.CART_ID}");
            }

            return (true, token);
        }
        //-------------------------------------------------------------------------
        public async Task<bool> register(WRITE_USER_DTO userDto)
        {
            var existingUser = await FindUserByUsername(userDto.USER_USERNAME);
            if (existingUser != null)
            {
                return false; // User already exists
            }
            var user = _mapper.Map<USERS>(userDto);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.USER_PASSWORD);
            user.USER_PASSWORD = hashedPassword;
            await _usersRepository.register(user);

            // Creating a cart for the registered user
            var cart = new CARTS { USER_ID = user.USER_ID };
            await _cartsRepository.AddCart(cart);
            Console.WriteLine($"New cart created for user {user.USER_ID}: {cart.CART_ID}");
            return true; // User added successfully
        }
        //-------------------------------------------------------------------------

        public async Task<READ_USER_DTO> GetUserById(int id)
        {
            var user = await _usersRepository.GetUserById(id);
            return _mapper.Map<READ_USER_DTO>(user);
        }
        //-------------------------------------------------------------------------

        public async Task<READ_USER_DTO> FindUserByUsername(string username)
        {
            var user = await _usersRepository.FindByUsername(username);
            return _mapper.Map<READ_USER_DTO>(user);
        }

        //=========================================================================

        public async Task<List<READ_USER_DTO>> GetAllUsers()
        {
            var users = await _usersRepository.GetAllUsers();
            return _mapper.Map<List<READ_USER_DTO>>(users);
        }
        //-------------------------------------------------------------------------

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
        //-------------------------------------------------------------------------

        public async Task DeleteUser(int id)
        {
            await _usersRepository.DeleteUser(id);
        }

    }
}
