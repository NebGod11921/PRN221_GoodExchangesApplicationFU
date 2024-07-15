using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.AccountDTOS
{
    public class LoginAccountDTOs
    {
        [Required(ErrorMessage = "Cần phải nhập email")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Cần phải nhập Password")]
        public string Password { get; set; }
    }
}
