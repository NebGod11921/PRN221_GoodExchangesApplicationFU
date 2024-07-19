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
        

        public CreateProductModel(IProductService service)
        {
            productService= service;
            
        }
        public async Task OnGet()
        {
            var categories = await productService.GetCategories();
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
            }
            else
                ViewData["Message"] = "Fail";
            return Page();
        }
    }
}
