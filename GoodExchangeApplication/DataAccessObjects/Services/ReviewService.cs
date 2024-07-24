using BusinessObjects;
using DataAccessObjects.IServices;
using DataAccessObjects.ViewModels.Reviews;
using System;
using System.Threading.Tasks;

namespace DataAccessObjects.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostService _postService;
        private readonly IAccountService _accountService;

        public ReviewService(IUnitOfWork unitOfWork, IPostService postService, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _postService = postService;
            _accountService = accountService;
        }

        public async Task<bool> GetRatingByUser(int userId, int postId)
        {
            try
            {
                var review = await _unitOfWork.ReviewRepository.FindAsync(r => r.UserId == userId && r.PostId == postId);
                return review != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RatingPost(int userId, ReviewRequestModels dto)
        {
            try
            {
                var review = new Review
                {
                    UserId = userId,
                    PostId = dto.PostId,
                    Rating = dto.Rating,
                    Comment = dto.Comment,
                    CreatedDate = DateTime.UtcNow,
                    Status = 1 // Assuming 1 means active or approved
                };

                await _unitOfWork.ReviewRepository.AddAsync(review);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
