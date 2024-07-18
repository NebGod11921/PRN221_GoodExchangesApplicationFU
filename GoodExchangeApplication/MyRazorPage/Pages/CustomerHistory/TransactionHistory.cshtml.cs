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




        public async Task OnGet()
        {
            var getUserSession = HttpContext.Session.GetString("GetUser");
            if (getUserSession != null)
            {
                var json = JsonSerializer.Deserialize<LoginAccountDTOs>(getUserSession);
                GetTransactions = await _transactionService.GetTransactionByUserID(json.Id);
            } else
            {
                GetTransactions = new List<TransactionDTOs>();
            }



        }
    }
}
