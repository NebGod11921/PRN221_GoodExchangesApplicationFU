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

        [BindProperty]
        public LoginAccountDTOs AccountDTOs { get; set; }

        public AccountDeleteModel(IServiceManager service)
        {
            _service = service;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            AccountDTOs = await _service.AccountService.GetAccountDTOsById(id);
            if (AccountDTOs == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (AccountDTOs == null || AccountDTOs.Id == 0)
            {
                return RedirectToPage("/NotFound");
            }

            _service.AccountService.DeleteAccount(AccountDTOs.Id);

            return RedirectToPage("./AccountManagement", new { SuccessMessage = "Account deleted successfully" });
        }
    }
}
