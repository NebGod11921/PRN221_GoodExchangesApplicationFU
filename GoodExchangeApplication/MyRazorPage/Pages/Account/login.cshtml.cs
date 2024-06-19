using DataAccessObjects.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


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
                if (string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(Email))
                {
                    return Page();
                }
                else
                {
                    var result = _accountService.LoginAccountAsync(Email, Password);
                    if (result != null)
                    {
                        return RedirectToPage("/Index");
                    } else
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
