using BusinessObjects;
using DataAccessObjects.Helpers;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        /*public IEnumerable<ProductDTos> ProductDtos { get; set; }*/

        public Pagination<ProductDTos> ProductDtos { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortField { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        [BindProperty(SupportsGet = true)]
        public float? MinPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public float? MaxPrice { get; set; }
        public SelectList CategorySelectList { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            var category = await _productService.GetProductCategories();
            CategorySelectList = new SelectList(category, "Id", "Name");
            
            int pageSize = 10;
            ProductDtos = await _productService.GetProductsPaging(pageIndex ?? 1, pageSize, Title, MinPrice, MaxPrice, CategoryId, SortField, SortOrder);
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
