using DataAccessObjects.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.Order
{
    public class CheckOutModel : PageModel
    {
        private readonly PaypalClient _paypalClient;

        public CheckOutModel(PaypalClient paypalClient)
        {
            _paypalClient = paypalClient;
        }

        public void OnGet()
        {
            ViewData["PaypalClientId"] = _paypalClient.ClientId;
        }



    }
}
