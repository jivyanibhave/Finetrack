using FinTrack.BLL.DTO;
using FinTrack.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDto = FinTrack.BLL.DTO.UserDto;

namespace FinTrack.BLL.Service.Interface
{
    public interface IUserService
    {
        Task<string> LoginAsync(string email, string password);
        Task<UserDto> RegisterAsync(RegisterDto user);
    }
}
