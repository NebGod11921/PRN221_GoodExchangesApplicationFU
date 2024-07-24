using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.PostDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorPage.Pages
{
    public class PostDetailModel : PageModel
    {
        private readonly IPostService _postService;
        public PostDetailModel(IPostService service)
        {
            _postService= service;
        }
        [BindProperty]
        public PostDTO PostDetail { get; set; }
        public async void OnGet(int? id)
        {
            if (id != null)
            {
                PostDetail = await _postService.GetPostByIdAsync((int)id);
            }
        }
    }
}
