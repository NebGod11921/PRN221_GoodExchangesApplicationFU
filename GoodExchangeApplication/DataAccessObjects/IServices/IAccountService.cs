using BusinessObjects;
using DataAccessObjects.ViewModels.AccountDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IAccountService
    {
        public Task<LoginAccountDTOs> LoginAccountAsync(string email, string password);
        public Task<RegisterAccountDTOs> RegisterAccountAsync(RegisterAccountDTOs accountDTOs);
        public Task<IEnumerable<AccountDTOs>> GetAllAccounts(AccountDTOs accountDTOs);
        public Task<LoginAccountDTOs> GetAccountDTOsById(int id);
        public Task<List<AccountDTOs>> SearchAccountByName(string userName);
        public Task<LoginAccountDTOs> UpdateUserProfileAsync(LoginAccountDTOs user, int userId);
        public Task<bool> DeleteAccount(int userId);

        public Task<bool> BanAccount(int AccountId);
        public Task<bool> UnbanAccount(int AccountId);
    }
}
