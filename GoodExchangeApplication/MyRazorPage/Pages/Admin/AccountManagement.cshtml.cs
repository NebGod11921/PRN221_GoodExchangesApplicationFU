using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.IServices;

namespace MyRazorPage.Pages.Admin
{
    public class AccountManagementModel : PageModel
    {
        public string SuccessMessage { get; set; }
        public List<string> ErrorMessage { get; set; } = new List<string>();
        public List<AccountDTOs> FilterAccounts { get; set; }
        public int TotalFindAccount { get; set; }

        public bool ShowAddAccountModal { get; set; }

        public AccountDTOs AddAccount { get; set; }


        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchProperty { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortProperty { get; set; }
        [BindProperty(SupportsGet = true)]
        public int SortOrder { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Page { get; set; } = 1;

        private readonly IAccountService _accountService;

        public AccountManagementModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            
            var accounts = await _accountService.GetAllAccounts(new AccountDTOs());

            if (accounts == null)
            {
                ErrorMessage.Add("No accounts found.");
                return Page();
            }

            var query = accounts.AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                switch (SearchProperty)
                {
                    case "UserName":
                        query = query.Where(a => a.UserName.Contains(SearchString));
                        break;
                    case "Email":
                        query = query.Where(a => a.Email.Contains(SearchString));
                        break;
                    case "TelephoneNumber":
                        query = query.Where(a => a.TelephoneNumber.Contains(SearchString));
                        break;
                    case "Address":
                        query = query.Where(a => a.Address.Contains(SearchString));
                        break;
                    default:
                        query = query.Where(a => a.Id.ToString().Contains(SearchString));
                        break;
                }
            }

            switch (SortProperty)
            {
                case "UserName":
                    query = SortOrder == 1 ? query.OrderBy(a => a.UserName) : query.OrderByDescending(a => a.UserName);
                    break;
                case "Email":
                    query = SortOrder == 1 ? query.OrderBy(a => a.Email) : query.OrderByDescending(a => a.Email);
                    break;
                case "TelephoneNumber":
                    query = SortOrder == 1 ? query.OrderBy(a => a.TelephoneNumber) : query.OrderByDescending(a => a.TelephoneNumber);
                    break;
                case "Address":
                    query = SortOrder == 1 ? query.OrderBy(a => a.Address) : query.OrderByDescending(a => a.Address);
                    break;
                default:
                    query = SortOrder == 1 ? query.OrderBy(a => a.Id) : query.OrderByDescending(a => a.Id);
                    break;
            }

            TotalFindAccount = query.Count();
            TotalPages = (int)System.Math.Ceiling(TotalFindAccount / 10.0);
            CurrentPage = Page;

            FilterAccounts = query.Skip((CurrentPage - 1) * 10).Take(10).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAddAccountAsync(string UserName, string Email, string Password, string TelephoneNumber, string Address)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage.Add("UserName, Email, and Password are required.");
                return Page();
            }

            var newAccount = new AccountDTOs
            {
                UserName = UserName,
                Email = Email,
                Password = Password,
                TelephoneNumber = TelephoneNumber,
                Address = Address,
                IsBanned = false
            };

          /*  var result = await _accountService.CreateAccountAsync(newAccount);

            if (result)
            {
                SuccessMessage = "Account added successfully.";
            }
            else
            {
                ErrorMessage.Add("Failed to add the account.");
            }*/

            return RedirectToPage();
        }

    }
}
