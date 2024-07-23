using BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.AccountDTOS
{
    public class AccountDTOs
    {
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Cần nhập tên tài khoản")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Cần nhập mật khẩu")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Cần nhập email")]
        public string? Email { get; set; }
        public byte[]? ProfilePicture { get; set; }
        [RegularExpression(@"^(03|05|07|08|09|01[2689])+([0-9]{8})\b", ErrorMessage = "Số điện thoại phải đúng định dạng")]
        [Required(ErrorMessage = "Cần nhập số điện thoại")]
        public string? TelephoneNumber { get; set; }
        [Required(ErrorMessage = "Hãy nhập địa chỉ")]
        public string? Address { get; set; }

        public bool ? IsBanned { get; set; }

        //Relationships
        public int? RoleId { get; set; }
        public virtual Role? Role { get; set; }
    }
}
