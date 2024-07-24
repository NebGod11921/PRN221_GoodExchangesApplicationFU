using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MyRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;


        public IndexModel(IProductService service)
        {
           _productService = service;

        }
        
        public List<ProductDTos> ProductDTos { get; set; }
        public async Task OnGet()
        {
            ProductDTos=await _productService.GetTopPopularProductsAsync();
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
