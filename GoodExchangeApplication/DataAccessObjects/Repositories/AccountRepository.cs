using BusinessObjects;
using DataAccessObjects.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Repositories
{
    public class AccountRepository : GenericRepository<User>, IAccountRepository
    {

        private readonly AppDbContext _appDbContext;


        public AccountRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public async Task<bool> CheckEmailExists(string email)
        {
            try
            {
                var result = await _appDbContext.Users.AnyAsync(u => u.Email == email);
                if (result )
                {
                    return true;
                } else
                {
                    return false;
                }

            } catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            
            }
        }

        public async Task<bool> CheckTelephoneNumberExists(string phoneNumber)
        {
            try
            {
                var result = await _appDbContext.Users.AnyAsync(x => x.TelephoneNumber == phoneNumber);
                if (result)
                {
                    return true;
                } else
                {
                    return false;
                }


            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetUserInformationIncludeRoleName()
        {
            try
            {
                var result = await _appDbContext.Users.Include(x => x.Role).ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                } else
                {
                    return null;
                }

            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> LoginByEmailAndPassword(string email, string password)
        {
            try
            {
                var result = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
                if (result !=  null)
                {
                    return result;
                } else
                {
                    return null;
                }



            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> RegisterAccount(User user)
        {
            await _appDbContext.Users.AddAsync(user);
            return user;
        }

        public async Task<IEnumerable<User>> SearchUserByNames(string name)
        {
            try
            {
                var result = await _appDbContext.Users.Where(x => x.UserName.Contains(name)).ToListAsync();
                return result;



            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
