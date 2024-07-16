using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRazorPage.Pages.Homepage
{
    public class DeleteProductModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IProductCategoryService productCategoryService;
        public DeleteProductModel(IProductService service, IProductCategoryService categoryService)
        {
            productCategoryService = categoryService;
            productService = service;
        }
        public SelectList CategoryDTOs { get; set; }
        [BindProperty]
        public RequestProductDTO requestProduct { get; set; }
        public async Task OnGet(int id)
        {
            var Categories = await productCategoryService.GetCategories();
            CategoryDTOs = new SelectList(Categories, "Id", "Name");
            if (id != null)
            {
                var request = await productService.GetById((int)id);

                requestProduct = request;
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await productService.DeleteProduct(requestProduct.Id);
            if (result != null)
            {
                ViewData["Message"] = "Delete Successfully";
            }
            else
                ViewData["Message"] = "Fail";
            return Page();
        }
    }
}
