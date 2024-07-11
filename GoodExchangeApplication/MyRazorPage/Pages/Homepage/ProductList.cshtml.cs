using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

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
        public async Task<IActionResult> OnPostTransferToProductDetail(int txtProductId)
        {
            ViewData["txtProductId"] = txtProductId;
            try
            {
                var result = await _productService.GetProductByIdSecondVers(txtProductId);
                if (result != null)
                {
                    var json = JsonSerializer.Serialize<ProductDTos>(result);
                    HttpContext.Session.SetString("GetProductDetail", json);
                    return RedirectToPage("/Homepage/ProductDetailPage");

                    
                }else
                {
                    return Page();
                }



            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
