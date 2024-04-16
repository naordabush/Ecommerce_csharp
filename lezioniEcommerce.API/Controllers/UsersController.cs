using lezioniEcommerce.API.DTO;
using lezioniEcommerce.API.Services.Classes;
using Microsoft.AspNetCore.Mvc;


namespace lezioniEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;

        public UsersController(UsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<READ_USER_DTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<READ_USER_DTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<WRITE_USER_DTO>> AddUser(WRITE_USER_DTO userDto)
        {
            try
            {
                await _userService.AddUser(userDto);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add user: {ex.Message} Inner Exception: {ex.InnerException.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<READ_USER_DTO>> UpdateUser(READ_USER_DTO updatedUserDTO)
        {
            try
            {
                await _userService.UpdateUser(updatedUserDTO);
                return Ok(updatedUserDTO);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update user: {ex.Message} Inner Exception: {ex.InnerException.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try { 
            await _userService.DeleteUser(id);
            return Ok("User deleted successfully");

        }
         catch (Exception ex)
         {
             return BadRequest($"Failed to delete user: {ex.Message} Inner Exception: {ex.InnerException.Message}");
    }
}

    }
}
