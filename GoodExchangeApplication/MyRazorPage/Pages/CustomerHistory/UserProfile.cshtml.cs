using DataAccessObjects.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.CustomerHistory
{
    public class UserProfileModel : PageModel
    {
        private readonly IProductService _productService;


        public UserProfileModel(IProductService productService)
        {
            _productService = productService;
        }




        public void OnGet()
        {
        }
    }
}
