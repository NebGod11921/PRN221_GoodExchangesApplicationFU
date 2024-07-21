using BusinessObjects;
using DataAccessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.Repositories;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRazorPage.Pages.Seller
{
    public class CreateProductModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateProductModel(IProductService service, IWebHostEnvironment webHostEnvironment)
        {
            productService = service;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task OnGet()
        {
            var categories = await productService.GetCategories();
            ViewData["Id"] = new SelectList(categories, "Id", "Name");
        }
        public SelectList CategorySelectList { get; set; }
        public IEnumerable<Category> CategoryDTOs { get; set; }
        [BindProperty]
        public RequestProductDTO requestProduct { get; set; }
        public async Task<IActionResult> OnPostAsync(IFormFile ImageFile)
        {
            if (ImageFile != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(fileStream);
                }

                requestProduct.Image = "/uploads/" + uniqueFileName;
            }

            var result = await productService.CreateProduct(requestProduct);
            if (result != null)
            {
                ViewData["Message"] = "Create Successfully";
                return RedirectToPage("./ProductManagement");
            }
            else
            {
                ViewData["Message"] = "Fail";
                return Page();
            }
                
        }
    }
}
