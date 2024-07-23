using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.PostDTOs;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyRazorPage.Pages.Seller
{
    public class UpdatePostModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IProductService _productService;
        private readonly ICurrentTime _currentTime;

        public UpdatePostModel(IPostService postService, IProductService productService, ICurrentTime currentTime)
        {
            _postService = postService;
            _productService = productService;
            _currentTime = currentTime;
        }
        public IEnumerable<ProductDTos> Products { get; set; }
        
        public async Task OnGet()
        {
            Products = await _productService.GetAllProductsSecVers();
        }

        public async Task<IActionResult> OnPostUpdatePost(int txtPostId, string txtTitle, string txtDescription, int txtSelectProduct)
        {
            ViewData["txtTitle"] = txtTitle;
            ViewData["txtDescription"] = txtDescription;
            ViewData["txtSelectProduct"] = txtSelectProduct;
            ViewData["txtPostId"] = txtPostId;
            try
            {
               
                var getUserSession = HttpContext.Session.GetString("GetSeller");
                if (getUserSession != null)
                {
                    
                    var userJson = JsonSerializer.Deserialize<LoginAccountDTOs>(getUserSession);
                    PostDTO p = new PostDTO
                    {
                        Id = txtPostId,
                        ProductId = txtSelectProduct,
                        Title = txtTitle,
                        Description = txtDescription,
                        Status = 1,
                        UserId = userJson.Id,
                        CreatedDate = _currentTime.GetCurrentTime(),
                    };
                    var result = await _postService.UpdatePostAsync(p, txtPostId);
                    if (result != null)
                    {
                        return RedirectToPage("/Seller/PostManagement");
                    } else
                    {
                        return Page();
                    }


                } else
                {
                    return Page();
                }





            }catch  (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        

        
    }
}
