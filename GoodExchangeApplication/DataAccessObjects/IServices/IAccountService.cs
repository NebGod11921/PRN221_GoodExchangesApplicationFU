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
        public Task<AccountDTOs> GetAccountDTOsById(int id);
        public Task<List<AccountDTOs>> SearchAccountByName(string userName);
        public Task<AccountDTOs> UpdateUserProfileAsync(AccountDTOs user, int userId);
        public Task<bool> DeleteAccount(int userId);
    }
}
