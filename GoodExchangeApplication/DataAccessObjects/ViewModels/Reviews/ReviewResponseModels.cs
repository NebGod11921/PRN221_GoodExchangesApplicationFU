using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.Reviews
{
    public class ReviewResponseModels
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
/*        public string? UserUrl { get; set; }*/
        public int PostId { get; set; } // nay add them vo db 
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        
    }
}
