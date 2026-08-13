namespace Fin_Track.MVC.Models
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ICollection<TransactionVM> Transactions { get; set; }
    }
}
