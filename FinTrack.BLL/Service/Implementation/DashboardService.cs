using FinTrack.BLL.DTO;
using FinTrack.BLL.Repo;
using FinTrack.BLL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Service.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(
            IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<DashboardDto> GetDashboardAsync(int userId)
        {
            if (userId <= 0)
                throw new Exception("Invalid User.");

            return await _dashboardRepository
                .GetDashboardAsync(userId);
        }
    }
}
