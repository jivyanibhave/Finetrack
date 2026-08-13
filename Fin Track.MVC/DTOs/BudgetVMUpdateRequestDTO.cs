namespace Fin_Track.MVC.DTOs
{
    public class BudgetVMUpdateRequestDTO
    {
        public int BudgetId { get; set; }

        public decimal LimitAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
