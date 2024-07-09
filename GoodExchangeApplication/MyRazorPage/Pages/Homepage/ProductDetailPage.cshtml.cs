using DataAccessObjects;
using DataAccessObjects.Helpers;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.CartDTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MyRazorPage.Pages.Homepage
{
    public class ProductDetailPageModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IAddToCartService _addToCartService;
        
        public ProductDetailPageModel(IProductService productService, IAddToCartService cartService)
        {
           
            _productService = productService;
            _addToCartService = cartService;
            
        }
      

        public List<CartDTOs> Carts
        {
            get 
            {
                var data = HttpContext.Session.Get<List<CartDTOs>>("MyCart");
                if(data == null)
                {
                    data = new List<CartDTOs>();
                }
                return data;
            }
        }
        



        public async Task<IActionResult> OnPostAddToCart(int txtProductId, int Quantity = 1)
        {
            try
            {
                var mycart = Carts;
                var item = mycart.SingleOrDefault(p => p.Id == txtProductId);

                if (item == null)
                {
                    var getProduct = await _productService.GetProductByIdSecondVers(txtProductId);
                    item = new CartDTOs
                    {
                        Id = txtProductId,
                        Title = getProduct.Title,
                        Quantity = 1,
                        Images = getProduct.Image,
                        Price = getProduct.Price,

                    };
                    mycart.Add(item);
                }
                else
                {
                    item.Quantity++;
                }
                var Json = JsonSerializer.Serialize(mycart);
                HttpContext.Session.SetString("MyCart", Json);

                return RedirectToPage("/AddToCart");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
