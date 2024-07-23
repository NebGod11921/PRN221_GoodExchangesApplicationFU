using DataAccessObjects.IServices;
using DataAccessObjects.Services;
using DataAccessObjects.ViewModels.AccountDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace MyRazorPage.Pages.Admin
{
    public class AccountDeleteModel : PageModel
    { 
        private readonly IServiceManager _service;

        public AccountDTOs AccountDTOs { get; set; }

        public AccountDeleteModel(IServiceManager service)
        {
            _service = service;
        }
        public IActionResult OnGet(int? id)
        {
           
            if (_service.AccountService.GetAccountDTOsById(AccountDTOs.AccountId) == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (AccountDTOs == null || AccountDTOs.AccountId == 0)
            {
                return RedirectToPage("/NotFound");
            }

            _service.AccountService.DeleteAccount(AccountDTOs.AccountId);

            return RedirectToPage("./AccountManagement", new { SuccessMessage = "Account deleted successfully" });
        }
    }
}
