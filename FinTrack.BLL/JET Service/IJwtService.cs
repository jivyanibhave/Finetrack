using FinTrack.BLL.DTO;
using FinTrack.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.JET_Service
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
