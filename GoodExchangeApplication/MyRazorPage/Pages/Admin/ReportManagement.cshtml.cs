using DataAccessObjects.Services;
using DataAccessObjects.ViewModels.ReportDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.Admin
{
    public class ReportManagementModel : PageModel
    {
        private readonly ReportService _service;

        public ReportManagementModel(ReportService service)
        {
            _service = service;
        }
        
        public void OnGet()
        {

        }

        public void OnPost() 
        {

        }
    }
}
