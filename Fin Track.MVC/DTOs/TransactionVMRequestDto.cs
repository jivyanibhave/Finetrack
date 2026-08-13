namespace Fin_Track.MVC.DTOs
{
    public class TransactionVMRequestDto
    {
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Type { get; set; }   // Income / Expense

        public int CategoryId { get; set; }
    }
}
