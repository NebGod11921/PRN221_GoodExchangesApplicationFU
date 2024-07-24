using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.PostDTOs;
using DataAccessObjects.ViewModels.Reviews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MyRazorPage.Pages
{
    public class PostDetailModel : PageModel
    {
        private readonly IPostService _postService;
        private readonly IReviewService _reviewService;
        public PostDetailModel(IPostService service, IReviewService reviewService)
        {
            _postService= service;
            _reviewService= reviewService;
        }
        [BindProperty]
        public PostDTO PostDetail { get; set; }

        public IEnumerable<ReviewDTO>? Reviews { get; set; }


        public async Task OnGet(int? id)
        {
            if (id != null)
            {
                   PostDetail = await _postService.GetPostByIdAsync((int)id);
               
            }
            Reviews = await _reviewService.GetAllReviewDtos();
        }
    }
}
