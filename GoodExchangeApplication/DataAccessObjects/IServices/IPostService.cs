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
        public Task<PostDTO> CreatePostAsync(PostDTO postDto, int userId, int productId);
        public Task<PostDTO> GetPostByIdAsync(int postId);
        public Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        public Task<PostDTO> UpdatePostAsync(PostDTO postDto, int postId);
        public Task<bool> DeletePostAsync(int postId);
        /*public Task<IEnumerable<PostDTO>> GetPostsByUserIdAsync(int userId);*/
    }
}
