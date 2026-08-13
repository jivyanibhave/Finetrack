using FinTrack.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Repo
{
    public interface IDashboardRepository
    {
        Task<DashboardDto> GetDashboardAsync(int userId);
    }
}
