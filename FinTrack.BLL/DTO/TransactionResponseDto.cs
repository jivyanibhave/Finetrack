using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.DTO
{
    public class TransactionResponseDto
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Type { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
