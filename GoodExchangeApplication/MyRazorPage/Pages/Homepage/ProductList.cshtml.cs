using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.Homepage
{
    public class ProductListModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductListModel(IProductService productService)
        {
            _productService = productService;
        }
        public IEnumerable<ProductDTos> ProductDtos { get; set; }



        public async Task OnGet()
        {
            ProductDtos = await _productService.GetAllProductsSecVers();
        }
    }
}
