using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.TransactionDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MyRazorPage.Pages.TransactionHistory
{
    public class TransactionHistoryModel : PageModel
    {
        private readonly ITransactionService _transactionService;


        public TransactionHistoryModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        
        public IEnumerable<TransactionDTOs> GetTransactions { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; } = 1;



        public async Task OnGet(int pageNumber = 1)
        {
            var getUserSession = HttpContext.Session.GetString("GetUser");
            if (getUserSession != null)
            {
                var json = JsonSerializer.Deserialize<LoginAccountDTOs>(getUserSession);

                // Fetch transactions for the current page
                int pageSize = 5; // Number of items per page
                var pagedResult = await _transactionService.GetTransactionByUserID(json.Id, pageNumber, pageSize);
                GetTransactions = pagedResult.Transactions;
                TotalPages = pagedResult.TotalPages;
                CurrentPage = pageNumber;
            }

        }

        public async Task<IActionResult> OnPostCancelOrder(int txtTransactionId)
        {
            ViewData["txtTransactionId"] = txtTransactionId;
            try
            {
                if (txtTransactionId > 0)
                {
                    var result = await _transactionService.DeleteTransaction(txtTransactionId);

                    if (result == true)
                    {
                        return RedirectToPage("/CustomerHistory/TransactionHistory");
                    }
                    else
                    {
                        return Page();
                    }


                }
                else
                {
                    return Page();
                }




            }catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
