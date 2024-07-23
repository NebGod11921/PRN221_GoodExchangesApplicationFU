using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MyRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        [BindProperty]
        public int ProductId { get; set; }
        public List<ProductDTos> FeatureProduct { get; set; }
        public async Task OnGetAsync()
        {
            FeatureProduct=await _productService.GetTopPopularProductsAsync();
        }
        public async Task<IActionResult> OnPostDetail()
        {
            var result = await _productService.GetProductByIdSecondVers(ProductId);
            if (result != null)
            {
                var json = JsonSerializer.Serialize<ProductDTos>(result);
                HttpContext.Session.SetString("GetProductDetail", json);
                return RedirectToPage("/Homepage/ProductDetailPage");


            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPostLogout()
        {
            var getSession = HttpContext.Session.GetString("GetUser");
            if (getSession != null)
            {
                HttpContext.Session.Clear();
                return RedirectToPage("/Account/Login");
            } else
            {
                return Page();
            }



         
        }
    }
}
