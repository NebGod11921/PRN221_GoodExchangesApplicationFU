using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using DataAccessObjects.ViewModels.TransactionDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.SellerHistory
{
    public class TransactionHistoryForSellerModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        private readonly ITransactionProductService _transactionProductService;
        private readonly ITransactionTypeService _transactionTypeService;
        private readonly IProductService _productService;

        public TransactionHistoryForSellerModel(ITransactionService transactionService, ITransactionProductService transactionProductService
            ,IProductService productServices, ITransactionTypeService transactionTypeService)
        {
            _productService = productServices;
            _transactionService = transactionService;
            _transactionProductService = transactionProductService;
            _transactionTypeService = transactionTypeService;
        }

        public IEnumerable<TransactionDTOs> GetTransactions {  get; set; }
        public IEnumerable<TransactionTypeDTO> GetTransactionTypeDTOs { get; set; }
        public IEnumerable<ProductDTos> GetProductDTos { get; set; }
        public IEnumerable<TransactionProductDTOs> GetTransactionProductDTOs { get; set; }



        public async Task OnGet()
        {
            GetTransactions = await _transactionService.GetTransactionDTOs();
            GetTransactionTypeDTOs = await _transactionTypeService.GetAllTransactionTypeDTOs();
           
        }
        
    }
}
