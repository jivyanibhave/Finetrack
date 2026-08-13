using FinTrack.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Service.Interface
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync(int userId);
    }
}
