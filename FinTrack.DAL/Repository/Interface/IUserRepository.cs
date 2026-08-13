using FinTrack.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.DAL.Repository.Interface
{
    public interface IUserRepository
    {
        Task<User> RegisterAsync(User user);

        Task<string> LoginAsync(string email, string password);
        Task<User> GetByEmailAsync(string email);
    }
}
