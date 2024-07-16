using DataAccessObjects.ViewModels.PostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IPostService
    {
        Task<PostDTO> CreatePostAsync(PostDTO postDto);
        Task<PostDTO> GetPostByIdAsync(int postId);
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task UpdatePostAsync(PostDTO postDto);
        Task DeletePostAsync(int postId);
        Task<IEnumerable<PostDTO>> GetPostsByUserIdAsync(int userId);
    }
}
