using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.Reviews
{
    public class ReviewDTO
    {
        public int Id { get; set; } 
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? CreatedDate { get; set; }


        public int? UserId { get; set; }
        public int? PostId { get; set; }
    }
}
