using FinTrack.BLL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fin_Track.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetDashboard(
            int userId)
        {
            var result =
                await _dashboardService
                    .GetDashboardAsync(userId);

            return Ok(result);
        }
    }
}
