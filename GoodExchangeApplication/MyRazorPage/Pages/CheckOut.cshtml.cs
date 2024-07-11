using DataAccessObjects.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Text.Json;

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


        #region Paypal payment
        [Authorize]
        [HttpPost("/CheckOut/create-paypal-order")]
        public async Task<IActionResult> CreatePaypalOrder(CancellationToken cancellationToken)
        {

            

            try
            {
                var getTotalPrice = HttpContext.Session.GetString("GetTotalPrice");

                if (string.IsNullOrEmpty(getTotalPrice))
                {
                    return BadRequest("Total price data is missing.");
                }

                // Assume getTotalPrice contains valid JSON
                var json = getTotalPrice;
                var currencyType = "USD";
                var orderCode = "Order" + DateTime.Now.Ticks.ToString();

                var response = await _paypalClient.CreateOrder(json, currencyType, orderCode);

                return RedirectToPage("/Success", response);


            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }



            //Info payment in cart
            
        }

        public async Task<IActionResult> CapturePaypalOrder(string orderID, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderID);
                //save database


                return RedirectToPage("/Success", response);


            }catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #endregion

    }
}
