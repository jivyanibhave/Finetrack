namespace Fin_Track.MVC.DTOs
{
    public class BudgetVMResponseDTO
    {
        public int BudgetId { get; set; }

        public decimal LimitAmount { get; set; }

        public decimal SpentAmount { get; set; }
        public decimal RemainingAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
