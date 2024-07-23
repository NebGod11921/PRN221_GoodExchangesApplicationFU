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
        public int Id {  get; set; }
/*        public string? Email {  get; set; }
        public string? Password { get; set; }*/
        public string? UserName { get; set; }
        public int? RoleId { get; set; }
        public byte? Status { get; set; }

        /*public byte[]? ProfilePicture { get; set; }*/
        public string? TelephoneNumber { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessage = "Cần phải nhập email")]
        public string? Email {  get; set; }
        [Required(ErrorMessage = "Cần phải nhập Password")]
        public string? Password { get; set; }
    }
}
