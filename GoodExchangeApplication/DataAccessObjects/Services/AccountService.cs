using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountDTOs> GetAccountDTOsById(int id)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.GetByIdAsync(id);
                var mapper = _mapper.Map<AccountDTOs>(result);
                if (mapper != null)
                {
                    return mapper;
                } else
                {
                    return null;
                }


            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AccountDTOs>> GetAllAccounts(AccountDTOs accountDTOs)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.GetUserInformationIncludeRoleName();
                var mapper = _mapper.Map<IEnumerable<AccountDTOs>>(result);
                if (mapper == null)
                {
                    return null;
                } else
                {
                    return mapper;
                }


            }catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoginAccountDTOs> LoginAccountAsync(string email, string password)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.LoginByEmailAndPassword(email, password);
                var mapper = _mapper.Map<LoginAccountDTOs>(result);
                if (mapper == null)
                {
                    return null;
                } else
                {
                    return mapper;
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RegisterAccountDTOs> RegisterAccountAsync(RegisterAccountDTOs accountDTOs)
        {
            try
            {
                var mapper = _mapper.Map<User>(accountDTOs);
                
                var createUser = await _unitOfWork.AccountRepository.RegisterAccount(mapper);

                if (createUser != null)
                {
                    var checkEmail = await _unitOfWork.AccountRepository.CheckEmailExists(createUser.Email);
                    var checkPhoneNumber = await _unitOfWork.AccountRepository.CheckEmailExists(createUser.TelephoneNumber);
                    createUser.RoleId = 1;
                    if (checkEmail == true)
                    {
                        throw new Exception($"This email is already exists");
                    }
                    else if (checkPhoneNumber == true)
                    {
                        throw new Exception($"This telephobe number is already exists");
                    }
                    else
                    {
                        var mapperResult = _mapper.Map<RegisterAccountDTOs>(createUser);
                        return mapperResult;
                    }
                }
                else
                {
                    return null;
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AccountDTOs>> SearchAccountByName(string userName)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.SearchUserByNames(userName);
                var mapper = _mapper.Map<List<AccountDTOs>>(result);
                if (result != null)
                {
                    return mapper;
                }
                else
                {
                    return null;
                }



            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> UpdateUserStatusByName(string userName)
        {
            User user = await _unitOfWork.AccountRepository.SearchUserByNames(userName) as User;
            if (user == null)
            {
                throw new Exception("User not found");
            }

            try
            {
                if (user.Status.Equals(1))
                {
                    user.Status = 0;
                    _unitOfWork.AccountRepository.Update(user);
                    await _unitOfWork.SaveChangeAsync();
                }
                if (user.Status.Equals(0))
                {
                    user.Status = 1;
                    _unitOfWork.AccountRepository.Update(user);
                    await _unitOfWork.SaveChangeAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the user status", ex);
            }
            return user;
        }

    }
}
