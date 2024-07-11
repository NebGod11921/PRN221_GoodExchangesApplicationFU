
using DataAccessObjects.Helpers;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.CartDTOS;
using DataAccessObjects.ViewModels.TransactionDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.TagHelpers;


namespace MyRazorPage.Pages.Transaction
{
    public class AddToCartModel : PageModel
    {
        private readonly ITransactionTypeService _transactionTypeService;
        private readonly PaypalClient _paypalClient;

        public AddToCartModel(ITransactionTypeService transactionTypeService, PaypalClient paypalClient)
        {
            _transactionTypeService = transactionTypeService;
            _paypalClient = paypalClient;

        }

        public IEnumerable<TransactionTypeDTO> TransactionTypeDTOs { get; set; }

        public IEnumerable<CartDTOs> CartDTOs { get; set; }


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
        public IActionResult OnPostCheckOut(float txtTotalPrice)
        {
            ViewData["txtTotalPrice"] = txtTotalPrice;

            var json = JsonSerializer.Serialize(txtTotalPrice);
            HttpContext.Session.SetString("GetTotalPrice", json);




            return RedirectToPage("/Checkout");
        }
    }
}
