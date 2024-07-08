using BusinessObjects;
using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages.Homepage
{
    public class ProductListModel : PageModel
    {
        private IProductRepo productRepo;
        private IProductService productService;

        public ProductListModel(IProductRepo repo, IProductService service)
        {
            productRepo = repo;   
            productService = service;
        }
        public IEnumerable<ResponseProductDTO> Products {  get; set; }
        public async Task OnGetAsync()
        {
            Products = await productService.GetAllProducts();
        }
    }
}
