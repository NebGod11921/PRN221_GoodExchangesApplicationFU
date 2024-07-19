using DataAccessObjects.Helpers;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyRazorPage.Pages.Seller
{
    public class ProductManagementModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductManagementModel(IProductService productService)
        {
            _productService = productService;
        }
        

        public Paging<ProductDTos> ProductDtos { get; set; }
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
            var category = await _productService.GetCategories();
            CategorySelectList = new SelectList(category, "Id", "Name");

            int pageSize = 10;
            ProductDtos = await _productService.GetProductsPaging(pageIndex ?? 1, pageSize, Title, MinPrice, MaxPrice, CategoryId, SortField, SortOrder);
        }
    }
}
