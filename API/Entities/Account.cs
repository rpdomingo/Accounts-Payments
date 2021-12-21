using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}