using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ChatSession : BaseEntity
    {
        public int User1Id { get; set; }
        public virtual User User1 { get; set; }
        public int User2Id { get; set; }
        public virtual User User2 { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
