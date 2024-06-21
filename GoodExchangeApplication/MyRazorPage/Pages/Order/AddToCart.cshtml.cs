
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.Order
{
    public class AddToCartModel : PageModel
    {


        
        public IActionResult CheckOut()
        {
            TempData["PaymentClientId"] = "";


            return RedirectToPage("/Checkout");
        }
    }
}
