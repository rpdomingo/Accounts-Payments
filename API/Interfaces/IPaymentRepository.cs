using API.Entities;

namespace API.Interfaces
{
    public interface IPaymentRepository
    {
         Task AddPaymentAsync(Payment payment);
         Task<IEnumerable<Payment>> GetPaymentByAcctIdAsync(int AccountId);
         Task<Payment> GetPaymentByIdAsync(int paymentId);
         Task<bool> Complete();
    }
}