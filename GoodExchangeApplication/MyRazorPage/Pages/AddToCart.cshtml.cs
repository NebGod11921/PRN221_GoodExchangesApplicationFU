using DataAccessObjects.Helpers;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.CartDTOS;
using DataAccessObjects.ViewModels.TransactionDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.PaymentDTOS;


namespace MyRazorPage.Pages.Transaction
{
    public class AddToCartModel : PageModel
    {
        private readonly ITransactionTypeService _transactionTypeService;
        private readonly ITransactionProductService _transactionProductService;
        private readonly ITransactionService _transactionService;
        private readonly IPaymentService _paymentService;
        private readonly PaypalClient _paypalClient;

        public AddToCartModel(ITransactionTypeService transactionTypeService, PaypalClient paypalClient, ITransactionService transactionService
            , ITransactionProductService transactionProductService, IPaymentService paymentService)
        {
            _transactionTypeService = transactionTypeService;
            _paypalClient = paypalClient;
            _transactionService = transactionService;
            _transactionProductService = transactionProductService;
            _paymentService = paymentService;
        }

        public IEnumerable<TransactionTypeDTO> TransactionTypeDTOs { get; set; }

        public IEnumerable<CartDTOs> CartDTOs { get; set; }
        public IEnumerable<PaymentDTOs> PaymentDTOs { get; set; }




        public List<CartDTOs> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartDTOs>>("MyCart");
                if (data == null)
                {
                    data = new List<CartDTOs>();
                }
                return data;
            }
        }



        public async Task OnGet()
        {
            TransactionTypeDTOs = await _transactionTypeService.GetAllTransactionTypeDTOs();
            PaymentDTOs = await _paymentService.GetPaymentDTOs();
            var getSession =  HttpContext.Session.GetString("MyCart");
                if (getSession != null)
                {
                    var json = JsonSerializer.Deserialize<IEnumerable<CartDTOs>>(getSession);
                    CartDTOs = json;
                } else
                {
                    CartDTOs = new List<CartDTOs>();
                }
            
        }

        public IActionResult OnPostRemoveCart(int itemId)
        {
            try
            {
                var cart = Carts;
                var item = cart.SingleOrDefault(x => x.Id == itemId);
                if (item != null) 
                {
                    cart.Remove(item);
                    var Json = JsonSerializer.Serialize(cart);
                    HttpContext.Session.SetString("MyCart", Json);
                }
                return RedirectToPage("/AddToCart");



            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IActionResult OnPostUpdateQuantity(int itemId, int quantity)
        {
            try
            {
                var cart = Carts;
                var item = cart.SingleOrDefault(x => x.Id == itemId);
                if (item != null && quantity > 0)
                {
                    item.Quantity = quantity;
                    var Json = JsonSerializer.Serialize(cart);
                    HttpContext.Session.SetString("MyCart", Json);
                }
                return RedirectToPage("/AddToCart");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> OnPostCheckOut(int txtQuantity, float txtTotalPrice, string txtNote, string txtAddress, int txtTransactionTypeId, List<int> productIds
            ,int txtPaymentMethodId)
        {
            ViewData["txtTotalPrice"] = txtTotalPrice;
            ViewData["txtQuantity"] = txtQuantity;
            ViewData["txtNote"] = txtNote;
            ViewData["txtAddress"] = txtAddress;
            ViewData["txtTransactionTypeId"] = txtTransactionTypeId;
            ViewData["productIds"] = productIds;
            ViewData["txtPaymentMethodId"] = txtPaymentMethodId;
            try
            {
                var getSession = HttpContext.Session.GetString("GetUser");
                if(getSession != null)
                {
                    var Json = JsonSerializer.Deserialize<LoginAccountDTOs>(getSession);
                    // Create a new TransactionDTO
                    TransactionDTOs transactionDTOs = new TransactionDTOs();
                    transactionDTOs.Quantity = txtQuantity;
                    transactionDTOs.TotalAmount = txtTotalPrice;
                    transactionDTOs.Note = txtNote;
                    transactionDTOs.ShippingAddress = txtAddress;
                    transactionDTOs.TransactionTypeId = txtTransactionTypeId;
                    transactionDTOs.PaymentId = txtPaymentMethodId;
                    transactionDTOs.Status = 1;
                    transactionDTOs.UserId = Json.Id;
                // Call service method to create transaction
                var resultTransaction = await _transactionService.CreateTransaction(transactionDTOs, txtTransactionTypeId);

                    if (resultTransaction != null)
                    {
                        List<TransactionProductDTOs> transactionProductDTOs = new List<TransactionProductDTOs>();

                        // Iterate over productIds to create TransactionProductDTOs
                        foreach (var productId in productIds)
                        {
                            TransactionProductDTOs transactionProduct = new TransactionProductDTOs();
                            transactionProduct.ProductId = productId;
                            transactionProduct.TransactionId = resultTransaction.Id;
                            transactionProductDTOs.Add(transactionProduct);
                        }

                        // Call service method to create transaction products
                        var resultTransactionProduct = await _transactionProductService.CreateTransactionProducts(transactionProductDTOs, resultTransaction.Id, productIds);

                        if (resultTransactionProduct && resultTransaction.PaymentId == 2)
                        {
                            var json = JsonSerializer.Serialize(resultTransaction);
                            HttpContext.Session.SetString("GetTransactionInfo", json);
                            
                            return RedirectToPage("/Checkout");
                        } else if (resultTransactionProduct && resultTransaction.PaymentId == 1)
                        {
                            var json = JsonSerializer.Serialize(resultTransaction);
                            HttpContext.Session.SetString("GetTransactionInfo", json);
                            
                            return RedirectToPage("/Success");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Failed to create transaction products.");
                            return Page();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create the transaction.");
                        return Page();
                    }
                } else
                {
                    ModelState.AddModelError(string.Empty, "Login first to use this function");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }

    }
}
