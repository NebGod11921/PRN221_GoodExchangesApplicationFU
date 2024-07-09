
using DataAccessObjects.Helpers;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.CartDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MyRazorPage.Pages.Transaction
{
    public class AddToCartModel : PageModel
    {
        
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



        public void OnGet()
        {
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



        public IActionResult CheckOut()
        {
            TempData["PaymentClientId"] = "";


            return RedirectToPage("/Checkout");
        }
    }
}
