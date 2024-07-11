using BusinessObjects;
using DataAccessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.Repositories;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRazorPage.Pages.Homepage
{
    public class CreateProductModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IProductCategoryService productCategoryService;

        public CreateProductModel(IProductService service, IProductCategoryService categoryService)
        {
            productService= service;
            productCategoryService= categoryService;
        }
        public async Task OnGet()
        {
            var categories = await productCategoryService.GetCategories();
            CategorySelectList = new SelectList(categories, "Id", "Name");
        }
        public SelectList CategorySelectList {  get; set; }
        public IEnumerable<Category> CategoryDTOs { get; set; }
        [BindProperty]
        public RequestProductDTO requestProduct { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var result=await productService.CreateProduct(requestProduct);
            if (result != null)
            {
                ViewData["Message"] = "Create Successfully";
                return RedirectToPage("./Homepage/ProductList");
            }
            else
                ViewData["Message"] = "Fail";
            return Page();
        }
    }
}
