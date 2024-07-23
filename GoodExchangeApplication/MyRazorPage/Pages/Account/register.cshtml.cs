using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.Account
{
    public class registerModel : PageModel
    {
        private readonly IAccountService _accountService;

        public registerModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnPostRegister(string txtUserName, string txtPassword, string txtEmail, string txtTelephone, string txtAddress)
        {
            ViewData["txtUserName"] = txtUserName;
            ViewData["txtPassword"] = txtPassword;
            ViewData["txtEmail"] = txtEmail;
            ViewData["txtTelephone"] = txtTelephone;
            ViewData["txtAddress"] = txtAddress;
            try
            {
                RegisterAccountDTOs acc = new RegisterAccountDTOs();
                acc.Email = txtEmail;
                acc.TelephoneNumber = txtTelephone;
                acc.Address = txtAddress;
                acc.Password = txtPassword;
                acc.UserName = txtUserName;
                acc.RoleId = 1; // set as customer
                acc.Status = 1; // active
                var result = await _accountService.RegisterAccountAsync(acc);
                if (result != null)
                {
                    return RedirectToPage("/Account/login");
                } else
                {
                    return Page();
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
