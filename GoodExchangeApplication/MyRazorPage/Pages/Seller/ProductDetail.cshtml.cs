using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRazorPage.Pages.Seller
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductService productService;
        public ProductDetailModel(IProductService service)
        {
            productService = service;
        }
        public SelectList CategoryDTOs { get; set; }
        [BindProperty]
        public RequestProductDTO requestProduct { get; set; }
        public async Task OnGet(int? id)
        {
            var Categories = await productService.GetProductCategories();
            CategoryDTOs = new SelectList(Categories, "Id", "Name");
            if (id != null)
            {
                var request = await productService.GetById((int)id);

                requestProduct = request;
            }
        }
    }
}
