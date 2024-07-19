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

        public CreatePostModel(IPostService postService, IProductService productService)
        {
            _postService = postService;
            _productService = productService;
        }

        [BindProperty]
        public PostDTO PostDTO { get; set; }

        public List<ProductDTO> Products { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            PostDTO = new PostDTO();

            // Initialize Products as an empty list
            Products = new List<ProductDTO>();

            try
            {

                // var user = HttpContext.Session.GetString("GetUser");
                // var userDto = JsonSerializer.Deserialize<LoginAccountDTOs>(user);
                // int userId = userDto.RoleId ?? 0;
                int? id = HttpContext.Session.GetInt32("userId");
                int userId = id ?? 0;
                var products = await _productService.GetProductsByUserIdAsync(userId);

                if (products != null)
                {
                    Products = products.ToList();
                }
                else
                {
                  throw new Exception("Failed to fetch products.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Replace with your session handling logic
                // var user = HttpContext.Session.GetString("GetUser");
                // var userDto = JsonSerializer.Deserialize<LoginAccountDTOs>(user);
                // PostDTO.UserId = userDto.RoleId;

                PostDTO.UserId = 2; 
                PostDTO.CreatedDate = DateTime.Now;
                PostDTO.Status = 1;
                var createdPost = await _postService.CreatePostAsync(PostDTO);

                if (createdPost != null)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create post.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Page();
            }
        }
    }
}
