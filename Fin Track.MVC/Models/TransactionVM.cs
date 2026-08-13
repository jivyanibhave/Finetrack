namespace Fin_Track.MVC.Models
{
    public class TransactionVM
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Type { get; set; } // Income / Expense

        public int CategoryId { get; set; }

        public CategoryVM Category { get; set; }

        public int UserId { get; set; }

        public UserVM User { get; set; }
    }
}
