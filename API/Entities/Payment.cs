using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}