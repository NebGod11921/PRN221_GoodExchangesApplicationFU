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
            , IProductService productServices, ITransactionTypeService transactionTypeService)
        {
            _productService = productServices;
            _transactionService = transactionService;
            _transactionProductService = transactionProductService;
            _transactionTypeService = transactionTypeService;
        }

        public IEnumerable<TransactionDTOs> GetTransactions { get; set; }
        public IEnumerable<TransactionTypeDTO> GetTransactionTypeDTOs { get; set; }
        public IEnumerable<ProductDTos> GetProductDTos { get; set; }
        public IEnumerable<TransactionProductDTOs> GetTransactionProductDTOs { get; set; }



        public async Task OnGet()
        {
            GetTransactions = await _transactionService.GetTransactionDTOs();
            GetTransactionTypeDTOs = await _transactionTypeService.GetAllTransactionTypeDTOs();

        }


        public IActionResult OnPostTransferTransactionDetail(int txtOrderId)
        {
            ViewData["txtOrderId"] = txtOrderId;
            try
            {
                HttpContext.Session.SetInt32("OrderIdDetail", txtOrderId);
                return RedirectToPage("/SellerHistory/TransactionDetailsForSeller");



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Set Status

        public async Task<IActionResult> OnPostReOrder(int txtReOrderId)
        {
            ViewData["txtReOrderId"] = txtReOrderId;
            try
            {
                var result = await _transactionService.ReOrderTransaction(txtReOrderId);
                if (result == true)
                {
                    return RedirectToPage("/SellerHistory/TransactionHistoryForSeller");
                }
                else
                {
                    return Page();
                }




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<IActionResult> OnPostConfirmOrder(int txtConfirmOrderId)
        {
            ViewData["txtConfirmOrderId"] = txtConfirmOrderId;
            try
            {
                var result = await _transactionService.ConfirmTransaction(txtConfirmOrderId);
                if (result == true)
                {
                    return RedirectToPage("/SellerHistory/TransactionHistoryForSeller");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }

        public async Task<IActionResult> OnPostCancelOrder(int txtCancelOrderId)
        {
            ViewData["txtCancelOrderId"] = txtCancelOrderId;
            try
            {
                var result = await _transactionService.DeleteTransaction(txtCancelOrderId);
                if (result == true)
                {
                    return RedirectToPage("/SellerHistory/TransactionHistoryForSeller");
                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);


            }
        }



    }
}