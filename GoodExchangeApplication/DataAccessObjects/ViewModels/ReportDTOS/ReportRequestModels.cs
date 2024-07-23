using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.ReportDTOS
{
    public class ReportRequestModels
    { 

        public int PostId {get;set;}
        [Required(ErrorMessage = "Please input the reason here")]
        public string? Reason { get; set; }

    }
}
