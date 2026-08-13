namespace Fin_Track.MVC.DTOs
{
    public class DashboardVMDto
    {
        public decimal TotalIncome { get; set; }

        public decimal TotalExpense { get; set; }

        public decimal Balance { get; set; }

        public decimal MonthlyBudget { get; set; }

        public decimal BudgetUsed { get; set; }
    }
}
