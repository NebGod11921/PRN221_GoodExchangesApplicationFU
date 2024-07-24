using BusinessObjects;
using DataAccessObjects.ViewModels.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IServices
{
    public interface IReviewService
    {

        Task<bool> RatingPost(int userId, ReviewRequestModels dto);
        Task<bool> GetRatingByUser(int userId, int postId);
    }
}
