using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ReportDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyRazorPage.Pages.Moderators
{
    public class ReportManagementPageModel : PageModel
    {
        private readonly IReportService _reportService;

        public ReportManagementPageModel(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IEnumerable<ReportResponseModel> Reports { get; set; }

        public async Task OnGet()
        {
            Reports = await _reportService.GetAllReports(new ReportResponseModel());
        }

        public async Task<IActionResult> OnPostApproveReport(int reportId)
        {
            try
            {
                if (reportId > 0)
                {
                    var result = await _reportService.AcceptReport(reportId, true);
                    if (result == "Report processed successfully!")
                    {
                        TempData["SuccessMessage"] = result;
                        return RedirectToPage("/Moderators/ReportManagement");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = result;
                        return Page();
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid report ID.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteReport(int reportId)
        {
            try
            {
                if (reportId > 0)
                {
                    var result = await _reportService.DeleteReport(reportId);
                    if (result)
                    {
                        TempData["SuccessMessage"] = "Report deleted successfully!";
                        return RedirectToPage("/Moderators/ReportManagementPage");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Failed to delete the report.";
                        return Page();
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid report ID.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return Page();
            }
        }
    }
}
