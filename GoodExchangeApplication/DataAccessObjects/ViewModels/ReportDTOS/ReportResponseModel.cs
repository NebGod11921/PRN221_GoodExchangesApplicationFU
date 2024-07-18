using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.ReportDTOS
{
    public class ReportResponseModel 
    { 
        public int ReportId { get; set; }

        [Required(ErrorMessage = "Please input the reportName")]
        [MinLength(4, ErrorMessage = "Minimum 4 characters")]
        [MaxLength(50, ErrorMessage = "Up to 50 characters")]
        public string? ReportName { get; set; }

        [Required(ErrorMessage = "Please input the reason here")]
        [MinLength(4, ErrorMessage = "Minimum 4 characters")]
        [MaxLength(50, ErrorMessage = "Up to 50 characters")]
        public string? Reason { get; set; }

        [Required(ErrorMessage = "Please input the created date")]
        public DateTime? CreatedDate { get; set; }


        public int? UserId { get; set; }
        [Required(ErrorMessage = "Please input your username here")]
        public string? UserName { get; set; }
        
    }
}
