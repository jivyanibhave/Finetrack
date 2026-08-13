using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.DAL.Models
{
    public class Budget
    {
        public int BudgetId { get; set; }

        public decimal LimitAmount { get; set; }

        public decimal SpentAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
