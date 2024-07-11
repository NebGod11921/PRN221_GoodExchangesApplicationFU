using Azure;
using DataAccessObjects.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MyRazorPage.Pages.Order
{
    [IgnoreAntiforgeryToken]
    public class CheckOutModel : PageModel
    {
        public string PaypalClientId { get; set; } = "";
        private string PaypalSecret { get; set; } = "";
        public string PaypalUrl { get; set; } = "";

        public string DeliveryAddress { get; set; } = "";
        public string Total { get; set; } = "";
        public string ProductIdentifies { get; set; } = "";
        private readonly PaypalClient _paypalClient;



        public CheckOutModel(IConfiguration configuration, PaypalClient paypalClient)
        {
            PaypalClientId = configuration["PaypalOptions:AppId"];
            PaypalSecret = configuration["PaypalOptions:AppSecret"];
            PaypalUrl = configuration["PaypalOptions:Url"];
            _paypalClient = paypalClient;
        }

        public void OnGet()
        {
            DeliveryAddress = "HCM";
            Total = "200";
            ProductIdentifies = "hahaha";
            ViewData["PaypalClientId"] = _paypalClient.ClientId;
        }


        public JsonResult OnPostCreateOrder()
        {
            DeliveryAddress = "HCM";
            Total = "200";
            ProductIdentifies = "hahaha";
            //create the request body
            JsonObject createOrderRequest = new JsonObject();
            createOrderRequest.Add("intent", "CAPTURE");    

            JsonObject amount = new JsonObject();
            amount.Add("currency_code", "USD");
            amount.Add("value", Total);

            JsonObject purchaseUnit1 = new JsonObject();
            purchaseUnit1.Add("amount", amount);

            JsonArray purchaseUnits = new JsonArray();
            purchaseUnits.Add(purchaseUnit1);

            createOrderRequest.Add("purchase_units", purchaseUnits);

            //get access token
            string accessToken = GetPaypalAccessToken();


            //send request
            string url = PaypalUrl + "/v2/checkout/orders";
            string orderId = "";

            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent(createOrderRequest.ToString(), null, "application/json");
            
                var responseTask = client.SendAsync(requestMessage);
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    

                    var strResponse = readTask.Result;
                    var jsonResponse = JsonNode.Parse(strResponse);
                
                    if(jsonResponse != null)
                    {
                        orderId = jsonResponse["id"]?.ToString() ?? "";
                    
                        //later to save into database
                    
                    }
                
                }
            
            }
            var response = new
            {
                Id = orderId
            };
            return new JsonResult(response);
        }

        public JsonResult OnPostCompleteOrder([FromBody] JsonObject data) 
        {
            if(data == null || data["orderID"] == null)
            {
                return new JsonResult("");
            } 
            var orderID = data["orderID"]!.ToString();


            string accessToken = GetPaypalAccessToken();

            string url = PaypalUrl + "/v2/checkout/orders/" + orderID + "/confirm-payment-source";

            using ( var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("", null, "application/json");

                var responseTask = client.SendAsync(requestMessage);
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var strResponse = readTask.Result;


                    var jsonResponse = JsonNode.Parse(strResponse);
                    if(jsonResponse != null)
                    {
                        string paypalOrderStatus = jsonResponse["status"]?.ToString() ?? "";
                        if(paypalOrderStatus == "COMPLETED")
                        {
                            //clear tempdata
                            TempData.Clear();


                            //update payment status in db


                            //clear cookie

                            return new JsonResult("success");
                        }
                    }
                }
            
            }
            return new JsonResult("");
        }

        private string GetPaypalAccessToken()
        {
            string accessToken = "";
            string url = PaypalUrl + "/v1/oauth2/token";
            using(var client = new HttpClient())
            {
                string credentials64 = 
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(PaypalClientId + ":" + PaypalSecret));

                client.DefaultRequestHeaders.Add("Authorization", "Basic " + credentials64);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("grant_type=client_credentials", null
                    , "application/x-www-form-urlencoded");

                var responseTask = client.SendAsync(requestMessage);
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var strResponse = readTask.Result;

                    var jsonResponse = JsonNode.Parse(strResponse);
                    if(jsonResponse != null)
                    {
                        accessToken = jsonResponse["access_token"]?.ToString() ?? "";
                    }
                    
                }
            }

            return accessToken;
        }




        #region Paypal payment

      /*  public async Task<IActionResult> CreatePaypalOrder(CancellationToken cancellationToken)
        {
            try
            {
                var getTotalPrice = HttpContext.Session.GetString("GetTotalPrice");

                if (string.IsNullOrEmpty(getTotalPrice))
                {
                    return BadRequest("Total price data is missing.");
                }

                // Deserialize JSON string to object
                var totalPriceObject = JsonSerializer.Deserialize<string>(getTotalPrice);

                var currencyType = "USD";
                var orderCode = "Order" + DateTime.Now.Ticks.ToString();

                // Pass totalPriceObject to your _paypalClient.CreateOrder method
                var response = await _paypalClient.CreateOrder(totalPriceObject, currencyType, orderCode);

                return RedirectToPage("/Success", response);
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors
                return BadRequest("Error parsing JSON data: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw new Exception("Error creating PayPal order: " + ex.Message);
            }
        }

        public async Task<IActionResult> CapturePaypalOrder(string orderID, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderID);
                //save database
                return RedirectToPage("/Success", response);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/


        #endregion

    }
}
