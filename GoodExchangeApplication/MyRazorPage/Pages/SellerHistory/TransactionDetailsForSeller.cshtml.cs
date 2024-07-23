using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.SellerHistory
{
    public class TransactionDetailsForSellerModel : PageModel
    {
        private readonly ITransactionProductService _transactionProductService;
        private readonly IProductService _productService;

        public TransactionDetailsForSellerModel(ITransactionProductService transactionProductService, IProductService productService)
        {
            _productService = productService;
            _transactionProductService = transactionProductService;
        }


        public IEnumerable<ProductDTos> ProductDTos { get; set; }



        public async Task OnGet()
        {
            int getTransactionDetailId = (int) HttpContext.Session.GetInt32("OrderIdDetail");
            if (getTransactionDetailId > 0)
            {
                ProductDTos = await _productService.GetProductsByTransactionId(getTransactionDetailId);
            }
            else
            {
                ProductDTos = new List<ProductDTos>();
            }



        }
    }
}
