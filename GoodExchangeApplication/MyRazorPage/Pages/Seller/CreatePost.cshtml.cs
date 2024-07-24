using DataAccessObjects.IRepositories;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.PostDTOs;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyRazorPage.Pages.Seller
{
    public class CreatePostModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IProductService _productService;
        private readonly ICurrentTime _currentTime;

        public CreatePostModel(IPostService postService, IProductService productService, ICurrentTime currentTime)
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

        public async Task<IActionResult> OnPostCreatePost(string txtTitle, string txtDescription, int txtSelectProductId, string txtImageURL)
        {
            ViewData["txtTitle"] = txtTitle;
            ViewData["txtDescription"] = txtDescription;
            ViewData["txtImageURL"] = txtImageURL;
            try
            {
                var getUserSession = HttpContext.Session.GetString("GetSeller");
                if (getUserSession != null)
                {
                    var json = JsonSerializer.Deserialize<LoginAccountDTOs>(getUserSession);

                    if (json != null )
                    {
                        PostDTO p = new PostDTO
                        {
                            ProductId = txtSelectProductId,
                            Title = txtTitle,
                            Description = txtDescription,
                            CreatedDate = _currentTime.GetCurrentTime(),
                            ImageURL = txtImageURL,
                            Status = 1
                        };


                        var result = await _postService.CreatePostAsync(p, json.Id, txtSelectProductId);
                        if (result != null )
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



                } else
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
