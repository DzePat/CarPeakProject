using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarPeak.Components.Classes
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UserExistsAsync(string username, string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == username || u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            var user = await GetUserByUsernameAsync(username);
            if (user != null)
            {
                // Compare plain text passwords
                if (user.Password == password)
                {
                    // Authentication successful
                    return true;
                }
            }
            // Authentication failed
            return false;
        }
    }
}
