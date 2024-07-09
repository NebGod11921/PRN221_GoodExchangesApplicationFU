
using DataAccessObjects.ViewModels.CartDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MyRazorPage.Pages.Transaction
{
    public class AddToCartModel : PageModel
    {




        


        public IEnumerable<CartDTOs> CartDTOs { get; set; }


        public void OnGet()
        {
            var getSession =  HttpContext.Session.GetString("MyCart");
            if (getSession != null)
            {
                var json = JsonSerializer.Deserialize<IEnumerable<CartDTOs>>(getSession);
                CartDTOs = json;
            }

        }





        public IActionResult CheckOut()
        {
            TempData["PaymentClientId"] = "";


            return RedirectToPage("/Checkout");
        }
    }
}
