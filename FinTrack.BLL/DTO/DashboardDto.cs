using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.DTO
{
    public class DashboardDto
    {
        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal Balance { get; set; }

        public decimal MonthlyBudget { get; set; }

        public decimal BudgetUsed { get; set; }
    }
}
