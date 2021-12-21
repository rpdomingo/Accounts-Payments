using API.Entities;

namespace API.Interfaces
{
    public interface IAccountRepository
    {
         void AddAccount(Account account);
         Task AddAccountAsync(Account account);
         Task<Account> GetAccountAsync(int id);
         Task<bool> Complete();
    }
}