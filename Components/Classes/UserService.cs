using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarPeak.Components.Classes
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;
        public User? CurrentUser { get; private set; }

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

        public async Task<bool> AuthenticateAdminUserAsync(string username, string password)
        {
            var user = await GetUserByUsernameAsync(username);
            if (user != null && user.Password == password && user.UserRole == "Admin")
            {
                CurrentUser = user; // Set the current user
                return true;
            }
            return false;
        }

        public async Task<bool> AuthenticateRegularUserAsync(string username, string password)
        {
            var user = await GetUserByUsernameAsync(username);
            if (user != null && user.Password == password && user.UserRole == "basic")
            {
                CurrentUser = user; // Set the current user
                return true;
            }
            return false;
        }
    }
}

