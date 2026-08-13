using FinTrack.BLL.DTO;
using FinTrack.BLL.Service.Interface;
using FinTrack.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fin_Track.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto user)
        {
            try
            {
                var result = await _userService.RegisterAsync(user);

                return Ok(new
                {
                    Message = "User Registered Successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            string email,
            string password)
        {
            try
            {
                var token =
                    await _userService.LoginAsync(email, password);

                return Ok(new
                {
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message,
                    InnerException = ex.InnerException?.Message,
                    InnerException2 = ex.InnerException?.InnerException?.Message,
                    StackTrace = ex.StackTrace
                });
            }
        }
    }
}
