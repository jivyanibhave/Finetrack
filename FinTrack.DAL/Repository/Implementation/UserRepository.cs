using FinTrack.DAL.Data;
using FinTrack.DAL.Models;
using FinTrack.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.DAL.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly FinTrackDbContext _context;
        public UserRepository(FinTrackDbContext context)
        {
            _context = context;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return "User not found";    
            }

            if (user.PasswordHash != password)
            {
                return "Invalid password";
            }
            return "Login successful";
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
