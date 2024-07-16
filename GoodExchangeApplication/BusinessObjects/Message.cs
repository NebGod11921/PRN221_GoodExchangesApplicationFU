using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Message : BaseEntity
    {
        public int ChatSessionId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ChatSession ChatSession { get; set; }
    }
}
