using BusinessObjects;
using DataAccessObjects.ViewModels.AccountDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        public Task<User> LoginByEmailAndPassword(string email, string password);
        public Task<User> RegisterAccount(User user);
        public Task<bool> CheckEmailExists(string email);
        public Task<bool> CheckTelephoneNumberExists(string phoneNumber);
        public Task<IEnumerable<User>> GetUserInformationIncludeRoleName();
        public Task<IEnumerable<User>> SearchUserByNames(string name);
        public Task<User> UpdateUser(User user, int userId);
        /* public Task<bool> RemoveUser(int userId);*/

        public Task<IEnumerable<User>> CreateAccountAsync(AccountDTOs accountDTOs);
    }

}
