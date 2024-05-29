using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;
using System.Net.NetworkInformation;

namespace CarPeak.Components.Classes
{
	public class UserService
	{
		private readonly IServiceProvider _serviceProvider;
		public User? CurrentUser { get; private set; }

		public UserService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public async Task<bool> UserExistsAsync(string username, string email)
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			return await dbContext.Users.AnyAsync(u => u.Username == username || u.Email == email);
		}

		public async Task AddUserAsync(User user)
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			dbContext.Users.Add(user);
			await dbContext.SaveChangesAsync();
		}

		public async Task<User> GetUserByUsernamePassAsync(string username, string password)
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			return await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
		}

		public async Task<User?> GetUserByUsernameAsync(string username)
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			return await dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
		}

		public async Task<User> AuthenticateUserAsync(string username, string password)
		{
			CurrentUser = await GetUserByUsernamePassAsync(username, password);
			return CurrentUser;

		}

		public async Task<List<User>> GetUsersAsync()
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			return await dbContext.Users.ToListAsync();
		}

		public async Task<List<Car>> GetCarsAsync()
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			return await dbContext.Cars.ToListAsync();
		}

		public async Task<List<Booking>> GetBookingsAsync()
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			return await dbContext.Bookings.ToListAsync();
		}


		public async Task<Car?> GetCarByIdAsync(int id)
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			return await dbContext.Cars.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<Booking?> GetBookingByIdAsync(int id)
		{
			using var scope = _serviceProvider.CreateScope();
			var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
			return await dbContext.Bookings.FirstOrDefaultAsync(u => u.Id == id);
		}
	}
}
