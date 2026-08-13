using FinTrack.BLL.DTO;
using FinTrack.BLL.JET_Service;
using FinTrack.BLL.Service.Interface;
using FinTrack.DAL.Models;
using FinTrack.DAL.Repository.Interface;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public UserService(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto user)
        {
            if (user == null)
                throw new Exception("User data is required.");

            if (string.IsNullOrWhiteSpace(user.FullName))
                throw new Exception("Full Name is required.");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new Exception("Email is required.");

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new Exception("Password is required.");

            var existingUser =
                await _userRepository.GetByEmailAsync(user.Email);

            if (existingUser != null)
                throw new Exception("Email already registered.");

            user.PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            var userModel = new User
            {               
                FullName = user.FullName,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };

            var result = await _userRepository.RegisterAsync(userModel);

            // Convert Model -> DTO
            return new UserDto
            {
                UserId = result.UserId,
                FullName = result.FullName,
                Email = result.Email,
                PasswordHash = result.PasswordHash
            };
        }

        public async Task<string> LoginAsync(
            string email,
            string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email is required.");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required.");

            var user =
                await _userRepository.GetByEmailAsync(email);

            if (user == null)
                throw new Exception("Invalid Email.");

            bool isValid =
                BCrypt.Net.BCrypt.Verify(
                    password,
                    user.PasswordHash);

            if (!isValid)
                throw new Exception("Invalid Password.");

            return _jwtService.GenerateToken(user);
        }
    }
}
