namespace Fin_Track.MVC.Models
{
    public class UserVM
    {
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<TransactionVM> Transactions { get; set; }

        public ICollection<BudgetVM> Budgets { get; set; }
    }
}
