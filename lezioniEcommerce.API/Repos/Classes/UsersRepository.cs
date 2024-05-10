using lezioniEcommerce.API.Controllers.DataModel;
using lezioniEcommerce.API.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lezioniEcommerce.API.Repos.Classes
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DB_ECOMMERCEContext _context;

        public UsersRepository(DB_ECOMMERCEContext context)
        {
            _context = context;
        }

        public async Task<List<USERS>> GetAllUsers()
        {
            return await _context.USERS.ToListAsync();
        }

        public async Task<USERS> GetUserById(int id)
        {
            return await _context.USERS.FindAsync(id);
        }

        public async Task register(USERS user)
        {
            _context.USERS.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(USERS updatedUser)
        {
            _context.Entry(updatedUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.USERS.FindAsync(id);
            if (user != null)
            {
                _context.USERS.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        //--------------FindByUsername-Register-Login-Logout------------------
        public async Task<USERS> FindByUsername(string username)
        {
            return await _context.USERS.FirstOrDefaultAsync(u => u.USER_USERNAME == username);
        }






    }
}
