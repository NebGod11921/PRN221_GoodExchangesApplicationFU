using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string? TelephoneNumber { get; set; }
        public string? Address { get; set; }
        
        //Relationships
        public int? RoleId {  get; set; }
        public virtual Role? Role { get; set; }
        public virtual IEnumerable<Post>? Posts { get; set; }
        public virtual IEnumerable<UserProduct>? UserProducts { get; set; }
        public virtual IEnumerable<Review>? Reviews { get; set; }
        public virtual IEnumerable<Report>? Reports { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ChatSession> ChatSessionsAsUser1 { get; set; }
        public virtual ICollection<ChatSession> ChatSessionsAsUser2 { get; set; }
    }
}
