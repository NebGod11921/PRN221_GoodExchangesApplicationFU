using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRazorPage.Pages.Seller
{
    public class UpdateProductModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UpdateProductModel(IProductService service, IWebHostEnvironment webHostEnvironment)
        {
            productService = service;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task OnGet(int? id)
        {

            if (id != null)
            {
                var request = await productService.GetById((int)id);

                requestProduct = request;
            }
            var Categories = await productService.GetCategories();

            ViewData["Id"] = new SelectList(Categories, "Id", "Name");
        }
        public SelectList CategoryDTOs { get; set; }
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
            var result = await productService.UpdateProduct(requestProduct);
            if (result != null)
            {
                ViewData["Message"] = "Update Successfully";
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
