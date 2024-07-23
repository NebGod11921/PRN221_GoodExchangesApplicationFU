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

        public async Task<string> AcceptReport(int id, bool isApproved)
        {
            try
            {
                var report = await _unitOfWork.ReportRepository.GetByIdAsync(id);
                if (report == null)
                {
                    return "Report not found";
                }

                var post = await _unitOfWork.PostRepository.GetByIdAsync(id);
                if (post == null)
                {
                    return "Post not found";
                }

                if (isApproved)
                {
                    _unitOfWork.PostRepository.SoftRemove(post);
                    report.Status = 1;  // Report approved and post deleted
                }
                else
                {
                    report.Status = 2;  // Report reviewed and found no violation
                }

                _unitOfWork.ReportRepository.Update(report);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (isSuccess)
                {
                    return "Report processed successfully!";
                }
                else
                {
                    return "Failed to process report";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error processing report in DB!", ex);
            }
        }


        public async Task<string> AddReportByUser(ReportRequestModels dto, int userId)
        {
            try
            {
                // Check if the post exists
                var post = await _unitOfWork.PostRepository.GetByIdAsync(dto.PostId);
                if (post == null)
                {
                    return "Post not found";
                }

                // Check if the post belongs to the user
                if (post.UserId == userId)
                {
                    return "You cannot report your own post";
                }

                // Map the dto to a Report entity
                var report = _mapper.Map<Report>(dto);
                report.UserId = userId;
                report.CreatedDate = DateTime.Now;

                // Add the report to the repository
                await _unitOfWork.ReportRepository.AddAsync(report);
                var isSuccess = await _unitOfWork.SaveChangeAsync() > 0;

                if (isSuccess)
                {
                    return "Add successful!";
                }
                else
                {
                    return "Failed to add report";
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error DB!", ex);
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
        public async Task<List<ReportResponseModel>> GetReportByPostId(int postId)
        {
            try
            {
                var findPost = await _unitOfWork.PostRepository.GetByIdAsync(postId);
                if (findPost != null)
                {
                    var Report = _unitOfWork.ReportRepository.FindAll(r => r.PostId == postId).ToList();
                    List<ReportResponseModel> Final = new List<ReportResponseModel>();
                    foreach (var report in Report)
                    {
                        var user = await _unitOfWork.AccountRepository.FindAsync(u => u.Id.Equals(report.UserId));
                        var post = await _unitOfWork.PostRepository.FindAsync(c => c.Id.Equals(report.PostId));
                        ReportResponseModel result = new ReportResponseModel();
                        result = _mapper.Map<ReportResponseModel>(result);
                        result.UserName = user.UserName;
                        result.title = post.Title;
                        Final.Add(result);
                    }
                    return Final;
                }
                else
                {
                    return null;
                }

            } catch (Exception ex)
            {
                throw new Exception("Error DB!");
            }

        }

        public async Task<List<ReportResponseModel>> GetReportByUserId(int userId)
        {
            try
            {
                var findPost = await _unitOfWork.AccountRepository.GetByIdAsync(userId);
                if (findPost != null)
                {
                    var Report = _unitOfWork.ReportRepository.FindAll(r => r.UserId == userId).ToList();
                    List<ReportResponseModel> Final = new List<ReportResponseModel>();
                    foreach (var report in Report)
                    {
                        var user = await _unitOfWork.AccountRepository.FindAsync(u => u.Id.Equals(report.UserId));
                        var post = await _unitOfWork.PostRepository.FindAsync(c => c.Id.Equals(report.PostId));
                        ReportResponseModel result = new ReportResponseModel();
                        result = _mapper.Map<ReportResponseModel>(result);
                        result.UserName = user.UserName;
                        result.title = post.Title;
                        Final.Add(result);
                    }
                    return Final;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error DB!");
            }
        }

        public Task<List<ReportResponseModel>> SearchReportByName(string reportName)
        {
            throw new NotImplementedException();
        }
    }
}
