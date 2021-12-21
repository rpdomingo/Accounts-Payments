using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("get-account/{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {
           var result = await _accountRepository.GetAccountAsync(id);

           return Ok(result);
        }

        [HttpPost("add-account")]
        public async Task<ActionResult> AddAccount(Account account)
        {
            await _accountRepository.AddAccountAsync(account);

            var result = await _accountRepository.Complete();

            if (result)
                return Ok();
            else
                return BadRequest("error in register");
        }

        [HttpPost("add-payment")]
        public async Task<ActionResult<Payment>> AddPayment(Payment payment)
        {
            var account = new Account();

            var paymentsDetails = new Payment
            {
                PaymentId = payment.PaymentId,
                Status = payment.Status,
                AccountId = payment.AccountId,
            };

            account.Payments.Add(paymentsDetails);

            var result = await _accountRepository.Complete();

            if (result)
                return Ok();
            else
                return BadRequest("error in register");
        }
    }
}