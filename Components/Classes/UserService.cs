using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;
using System.Net.NetworkInformation;
using Microsoft.Data.Sqlite;

namespace CarPeak.Components.Classes
{
	public class UserService
	{
		private readonly IServiceProvider _serviceProvider;
		public User? CurrentUser { get; set; }

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
            var bookings = new List<Booking>();

            using (var connection = new SqliteConnection("Data Source=app.db"))
            {
                await connection.OpenAsync();

                var command = connection.CreateCommand();
                command.CommandText = @"
            SELECT Id, CustomerName, CarName
            FROM Bookings";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var booking = new Booking
                        {
                            Id = reader.GetInt32(0),
                            CarName = reader.GetString(1),
                            CustomerName = reader.GetString(2)
                        };
                        bookings.Add(booking);
                    }
                }
            }

            return bookings;
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

		public async Task<List<Car>> GetAllCars()
		{
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            return await dbContext.Cars.ToListAsync();
		}
	} 
}

