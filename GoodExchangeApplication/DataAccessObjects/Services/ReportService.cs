using AutoMapper;
using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ReportDTOS;
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
                var result = _unitOfWork.ReportRepository.
            }
        }

        public Task<bool> DeleteReport(int ReportId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportResponseModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportResponseModel>> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public Task<List<ReportResponseModel>> GetAllValidReport()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReportResponseModel>> GetReportByPostId(int postId)
        {
            throw new NotImplementedException();
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
