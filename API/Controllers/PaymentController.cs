using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpPost("add-payment")]
        public async Task<ActionResult> AddPayment(Payment payment)
        {
            await _paymentRepository.AddPaymentAsync(payment);

            var result = await _paymentRepository.Complete();

             if (result)
                return Ok();
            else
                return BadRequest("error in register");
        }

        [HttpGet("getpaymentsbyacct/{accountId}")]
        public async Task<ActionResult<Payment>> GetPaymentsByAcctId(int accountId)
        {
            var result = await _paymentRepository.GetPaymentByAcctIdAsync(accountId);

            return Ok(result);
        }

        [HttpGet("getpaymentbyid/{paymentId}")]
        public async Task<ActionResult<Payment>> GetPaymentsById(int paymentId)
        {
            var result = await _paymentRepository.GetPaymentByIdAsync(paymentId);

            return Ok(result);
        }
    }
}