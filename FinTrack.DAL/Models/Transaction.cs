using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.DAL.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Type { get; set; } // Income / Expense

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
