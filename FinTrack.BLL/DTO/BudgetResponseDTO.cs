using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.DTO
{
    public class BudgetResponseDTO
    {
        public int BudgetId { get; set; }

        public decimal LimitAmount { get; set; }

        public decimal SpentAmount { get; set; }
        public decimal RemainingAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
