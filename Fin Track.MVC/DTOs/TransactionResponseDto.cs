namespace Fin_Track.MVC.DTOs
{
    public class TransactionResponseDto
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Type { get; set; }

        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
