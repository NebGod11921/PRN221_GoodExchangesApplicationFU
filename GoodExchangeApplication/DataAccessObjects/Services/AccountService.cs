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

        public async Task<bool> DeleteAccount(int userId)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.GetByIdAsync(userId);
                if (result != null)
                {
                     _unitOfWork.AccountRepository.SoftRemove(result);
                    var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;
                    if (isSuccess)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        public async Task<AccountDTOs> UpdateUserProfileAsync(AccountDTOs user, int userId)
        {
            try
            {
                var mapper = _mapper.Map<User>(user);
                var result = await _unitOfWork.AccountRepository.UpdateUser(mapper, userId);
                if (result != null)
                {
                    var mappedResult = _mapper.Map<AccountDTOs>(result);
                    return mappedResult;
                } else
                {
                    return null;
                }


            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
