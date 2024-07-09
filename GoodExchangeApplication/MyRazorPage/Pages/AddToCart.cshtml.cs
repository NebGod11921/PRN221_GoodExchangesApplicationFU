
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.Transaction
{
    public class AddToCartModel : PageModel
    {




        public IActionResult AddToCart(int Id, int Quantity = 1)
        {
            return  Page();
        }










        public IActionResult CheckOut()
        {
            TempData["PaymentClientId"] = "";


            return RedirectToPage("/Checkout");
        }
    }
}
