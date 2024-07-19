using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.ReportDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IReportService
    {
        Task<IEnumerable<ReportResponseModel>> GetAllReports(ReportResponseModel reportDTO);
        Task<List<ReportResponseModel>> GetReportByUserId(int userId);
        Task<List<ReportResponseModel>> GetReportByPostId(int postId);
        Task<List<ReportResponseModel>> SearchReportByName(string reportName);
        Task<bool> DeleteReport(int ReportId);
/*        Task<List<ReportResponseModel>> GetAll();*/
/*        Task<List<ReportResponseModel>> GetAllValidReport();*/
        Task<string> AddReportByUser(ReportRequestModels dto, int userId);
        Task<string> UpdateReportByUser(int id, ReportRequestModels dto);
/*        Task<string> DeleteReport(int id);
        Task<string> AcceptReport(int id);*/
    }
}
