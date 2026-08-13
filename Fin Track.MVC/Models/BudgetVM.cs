namespace Fin_Track.MVC.Models
{
    public class BudgetVM
    {
        public int BudgetId { get; set; }

        public decimal LimitAmount { get; set; }

        public decimal SpentAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int UserId { get; set; }

        public UserVM User { get; set; }
    }
}
