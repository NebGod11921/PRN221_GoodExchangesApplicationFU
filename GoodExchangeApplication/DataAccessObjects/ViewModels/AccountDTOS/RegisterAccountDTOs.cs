using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.AccountDTOS
{
    public class RegisterAccountDTOs
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        /*public byte[]? ProfilePicture { get; set; }*/
        public string? TelephoneNumber { get; set; }
        public string? Address { get; set; }

        //Relationships
        public int? RoleId { get; set; }
    }
}
