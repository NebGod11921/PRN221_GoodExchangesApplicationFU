using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRazorPage.Pages.Homepage
{
    public class UpdateProductModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IProductCategoryService productCategoryService;
        public UpdateProductModel(IProductService service, IProductCategoryService categoryService)
        {
            productService = service;
            productCategoryService = categoryService;
        }
        public async Task OnGet(int? id)
        {
            
            if (id != null)
            {
                var request = await productService.GetById((int)id);
                
                requestProduct= request;
            }
            var Categories = await productCategoryService.GetCategories();
            
            CategoryDTOs = new SelectList(Categories, "Id", "Name");
        }
        public SelectList CategoryDTOs { get; set; }
        [BindProperty]
        public RequestProductDTO requestProduct { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await productService.UpdateProduct(requestProduct);
            if (result != null)
            {
                ViewData["Message"] = "Update Successfully";
            }
            else
                ViewData["Message"] = "Fail";
            return Page();
        }
    }
}
