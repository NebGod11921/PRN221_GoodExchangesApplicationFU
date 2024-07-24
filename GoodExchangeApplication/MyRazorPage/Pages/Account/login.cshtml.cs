using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;


namespace MyRazorPage.Pages.Account
{
    public class loginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public loginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public async Task<IActionResult> OnPostLogin(string Email, string Password)
        {
            ViewData["Email"] = Email;
            ViewData["Password"] = Password;
            try
            {
                if (string.IsNullOrEmpty(Email))
                {
                    ModelState.AddModelError(string.Empty, "Email is required.");
                    return Page();
                }

                if (string.IsNullOrEmpty(Password))
                {
                    ModelState.AddModelError(string.Empty, "Password is required.");
                    return Page();
                }
                else
                {
                    var result = await _accountService.LoginAccountAsync(Email, Password);
                    if (result != null)
                    {
                        if(result.RoleId == 1 && result.Status == 1)
                        {
                            var json = JsonSerializer.Serialize<LoginAccountDTOs>(result);
                            HttpContext.Session.SetString("GetUser", json);
                            return RedirectToPage("/Index");
                        }
                        else if(result.RoleId == 4 && result.Status == 1)
                        {
                            var json = JsonSerializer.Serialize<LoginAccountDTOs>(result);
                            HttpContext.Session.SetString("GetSeller", json);
                            return RedirectToPage("/SellerHistory/TransactionHistoryForSeller");
                        } else
                        {
                            return Page();
                        }
                    }
                    else
                    {
                        return Page();
                    }
                    
                }

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
