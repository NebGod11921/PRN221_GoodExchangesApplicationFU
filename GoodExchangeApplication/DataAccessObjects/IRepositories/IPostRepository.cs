using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> CreatePostAsync(Post post);
        Task<Post> GetPostByIdAsync(int postId);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int postId);
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);
    }
}
