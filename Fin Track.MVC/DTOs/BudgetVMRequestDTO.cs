namespace Fin_Track.MVC.DTOs
{
    public class BudgetVMRequestDTO
    {
        public decimal LimitAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
