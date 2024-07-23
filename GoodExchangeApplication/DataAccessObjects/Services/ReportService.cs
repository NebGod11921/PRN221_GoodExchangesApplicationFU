using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.UnitOfWork;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.ReportDTOS;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class ReportService : IReportService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<string> AddReportByUser(ReportRequestModels dto, int userId)
        {
            try
            {
                /* var result = _unitOfWork.PostRepository.GetByIdAsync(dto.ReportId);
                 if (result == null)
                 {
                     return null;
                 }
                 if (result.Id == userId)
                 {
                     return "You cannot report your own Post";
                 }
                 var result = _mapper.Map<Report>(dto);
                 result.Status = false;
                 result.UserId = userId;
                 result.Date = DateTime.Now;
                 await _unitOfWork.Repository<Report>().InsertAsync(result);
                 await _unitOfWork.CommitAsync();
                 return "Add successful!";*/
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error DB!");
            }
        }

        public async Task<bool> DeleteReport(int ReportId)
        {
            try
            {
                var result = await _unitOfWork.ReportRepository.GetByIdAsync(ReportId);
                if (result != null)
                {
                    _unitOfWork.ReportRepository.SoftRemove(result);
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
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<IEnumerable<ReportResponseModel>> GetAllReports(ReportResponseModel reportDTO)
        {
            try
            {
                var result = await _unitOfWork.ReportRepository.GetAllAsync();
                var mapper = _mapper.Map<IEnumerable<ReportResponseModel>>(result);
                if (mapper == null)
                {
                    return null;
                }
                else
                {
                    return mapper;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error DB!");
            }
        }

        /*        public Task<List<ReportResponseModel>> GetAllValidReport()
                {
                    throw new NotImplementedException();
                }*/

        public async Task<IEnumerable<ReportResponseModel>> GetReportByPostId(int postId)
        {
            try
            {
                var findPost = await _unitOfWork.AccountRepository.GetByIdAsync(postId);
                if (findPost != null)
                {

                }

            } catch (Exception ex)
            {
                throw new Exception("Error DB!");
            }
            return null;
        }

        public Task<IEnumerable<ReportResponseModel>> GetReportByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportResponseModel>> SearchReportByName(string reportName)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateReportByUser(int id, ReportRequestModels dto)
        {
            throw new NotImplementedException();
        }
    }
}
