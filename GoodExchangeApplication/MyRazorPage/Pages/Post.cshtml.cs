using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.PostDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostService _postService;
        public PostModel(IPostService service)
        {
            _postService = service;
        }
        public IEnumerable<PostDTO> Posts { get; set; }
        public async Task OnGet()
        {
            Posts = await _postService.GetAllPostsAsync();
        }
    }
}
