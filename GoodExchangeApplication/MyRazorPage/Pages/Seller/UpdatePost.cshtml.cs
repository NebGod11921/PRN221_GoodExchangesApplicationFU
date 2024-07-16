using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.PostDTOs;
using DataAccessObjects.ViewModels.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRazorPage.Pages.Seller
{
    public class UpdatePostModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IProductService _productService;

        public UpdatePostModel(IPostService postService, IProductService productService)
        {
            _postService = postService;
            _productService = productService;
        }

        [BindProperty]
        public PostDTO Post { get; set; }

        public List<ProductDTO> Products { get; set; }
        int userId = 2;

        public async Task<IActionResult> OnGetAsync(int postId)
        {
            try
            {
                Post = await _postService.GetPostByIdAsync(postId);
                if (Post == null)
                {
                    return NotFound();
                }

                var products = await _productService.GetProductsByUserIdAsync(userId);
                if (products != null)
                {
                    Products = products.ToList();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Products could not be loaded.");
                    return Page();
                }

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (Post == null)
                {
                    ModelState.AddModelError(string.Empty, "Post data is missing.");
                    return Page();
                }

                Post.UserId = userId;

                await _postService.UpdatePostAsync(Post);
                return RedirectToPage("/Seller/PostManagement");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
