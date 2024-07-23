using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.IServices;

namespace MyRazorPage.Pages.Admin
{
    public class AccountUpdateModel : PageModel
    {
        private readonly IServiceManager _serviceManager;

        public AccountUpdateModel(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [BindProperty]
        public AccountDTOs AccountUpdate { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            /*AccountUpdate = await _serviceManager.AccountService.GetAccountDTOsById(id);
            if (AccountUpdate == null)
            {
                return NotFound();
            }*/

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            /*   if (!ModelState.IsValid)
               {
                   return Page();
               }

               var success = await _serviceManager.AccountService.UpdateUserProfileAsync(AccountUpdate, AccountUpdate.AccountId);
               if (success == null)
               {
                   ModelState.AddModelError(string.Empty, "An error occurred while trying to update the account.");
                   return Page();
               }

               return RedirectToPage("./AccountManagement", new { SuccessMessage = "Account updated successfully" });*/
            return Page();
        }
    }
}
