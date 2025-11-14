using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UmCalendar.DTOs;
using UmCalendar.Models;

namespace UmCalendar.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var existing = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email || u.Name == dto.Name);

            if (existing != null)
                return false;

            string salt = PasswordHelper.GenerateSalt();
            string hash = PasswordHelper.HashPassword(dto.Password, salt);

            var user = new User
            {
                Email = dto.Email,
                Name = dto.Name,
                PasswordHash = hash,
                PasswordSalt = salt,
                CreatedAt = DateTime.UtcNow
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<User> AuthenticateAsync(LoginDto dto)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                return null;

            string hash = PasswordHelper.HashPassword(dto.Password, user.PasswordSalt);

            if (hash != user.PasswordHash)
                return null;

            return user!;
        }
    }
}