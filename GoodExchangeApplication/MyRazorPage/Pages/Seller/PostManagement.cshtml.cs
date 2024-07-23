using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.AccountDTOS;
using DataAccessObjects.ViewModels.PostDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
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

        

        public IEnumerable<PostDTO> Posts { get; set; }

        public async Task OnGet()
        {
           Posts = await _postService.GetAllPostsAsync();
        }

        public async Task<IActionResult> OnPostTransferToUpdatePage(int txtPostId)
        {
            ViewData["txtPostId"] = txtPostId;
            try
            {
                if (txtPostId > 0)
                {
                    var getUpdateId = await _postService.GetPostByIdAsync(txtPostId);
                    if (getUpdateId != null)
                    {
                        HttpContext.Session.SetString("GetPostDetail", JsonSerializer.Serialize<PostDTO>(getUpdateId));
                        return RedirectToPage("/Seller/UpdatePost");
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







        

        public async Task<IActionResult> OnPostDeletePost(int txtPostDeleteId)
        {
            ViewData["txtPostDeleteId"] = txtPostDeleteId;
            try
            {
                if (txtPostDeleteId > 0)
                {
                    var result = await _postService.DeletePostAsync(txtPostDeleteId);
                    if (result == true)
                    {
                        return RedirectToPage("/Seller/PostManagement");
                    }
                    else
                    {
                        return Page();
                    }
                } else
                {
                    return Page();
                }

                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return Page();
            }
        }
    }
}
