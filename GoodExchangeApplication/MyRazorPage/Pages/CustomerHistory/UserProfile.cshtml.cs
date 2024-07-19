using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MyRazorPage.Pages.CustomerHistory
{
    public class UserProfileModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IAccountService _accountService;

        public UserProfileModel(IProductService productService, IAccountService accountService)
        {
            _productService = productService;
            _accountService = accountService;
        }

        public LoginAccountDTOs LoginAccountDTOs { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var getSession = HttpContext.Session.GetString("GetUser");
            if (getSession != null)
            {
                var json = JsonSerializer.Deserialize<LoginAccountDTOs>(getSession);
                LoginAccountDTOs = await _accountService.GetAccountDTOsById(json.Id);
            }
            else
            {
                LoginAccountDTOs = new LoginAccountDTOs();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateProfile(int txtUserId, string txtEmail, string txtUserName, string txtPassword, string txtTelephone, string txtAddress)
        {
            try
            {
                if (txtUserId > 0)
                {
                    LoginAccountDTOs acc = new LoginAccountDTOs
                    {
                        Id = txtUserId,
                        Address = txtAddress,
                        Email = txtEmail,
                        TelephoneNumber = txtTelephone,
                        Password = txtPassword,
                        UserName = txtUserName,
                        RoleId = 1,
                        Status = 1
                    };

                    var result = await _accountService.UpdateUserProfileAsync(acc, txtUserId);
                    if (result != null)
                    {
                        // Reload updated profile data and update session
                        var updatedProfile = await _accountService.GetAccountDTOsById(txtUserId);
                        HttpContext.Session.SetString("GetUser", JsonSerializer.Serialize(updatedProfile));

                        // Redirect to reload the page with updated data
                        return RedirectToPage();
                    }
                }

                // Handle errors or invalid data
                TempData["ErrorMessage"] = "Failed to update profile. Please try again.";
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return Page();
            }
        }
    }
}
