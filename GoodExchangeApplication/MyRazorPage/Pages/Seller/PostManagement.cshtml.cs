using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.PostDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyRazorPage.Pages.Seller
{
    public class PostManagementModel : PageModel
    {
        private readonly IPostService _postService;

        public PostManagementModel(IPostService postService)
        {
            _postService = postService;
        }

        [BindProperty]
        public PostDTO NewPost { get; set; }

        public IEnumerable<PostDTO> Posts { get; set; }

        public async Task OnGetAsync()
        {
            // Example: Get user information from session
            //var user = HttpContext.Session.GetString("GetUser");
            //var userDto = JsonSerializer.Deserialize<LoginAccountDTOs>(user);
            //int userId = userDto.RoleId ?? 0;
            int userId = 2;
            Posts = await _postService.GetPostsByUserIdAsync(userId);
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var createdPost = await _postService.CreatePostAsync(NewPost);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int postId)
        {
            try
            {
                await _postService.DeletePostAsync(postId);
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
