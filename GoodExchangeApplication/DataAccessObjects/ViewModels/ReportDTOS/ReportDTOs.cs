using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.ReportDTOS
{
    public class ReportDTOs
    {
        public int ReportId { get; set; }
        public string? ReportName { get; set; }
        public string? Reason { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ReportTypeId { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        
    }
}
