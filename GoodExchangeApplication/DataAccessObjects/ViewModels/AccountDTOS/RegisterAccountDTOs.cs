using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.AccountDTOS
{
    public class RegisterAccountDTOs
    {
 
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Cần phải nhập password")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Cần phải nhập email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Cần phải nhập telephonenumber")]
        /*public byte[]? ProfilePicture { get; set; }*/
        
        public string? TelephoneNumber { get; set; }
        [Required(ErrorMessage = "Cần phải nhập address")]
        public string? Address { get; set; }

        
        public int? RoleId { get; set; }
        public byte? Status { get; set; }
    }
}
