using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.DTO
{
    public class RegisterDto
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
