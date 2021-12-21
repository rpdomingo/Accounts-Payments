using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DataContext _context;
        public PaymentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Payment>> GetPaymentByAcctIdAsync(int AccountId)
        {
            var payments = await _context.Payments
                .Where(p => p.AccountId == AccountId)
                .ToListAsync();

            return payments;
        }

        public async Task<Payment> GetPaymentByIdAsync(int paymentId)
        {
            var paymet = await _context.Payments.SingleOrDefaultAsync(p => p.PaymentId == paymentId);

            return paymet;
        }
    }
}