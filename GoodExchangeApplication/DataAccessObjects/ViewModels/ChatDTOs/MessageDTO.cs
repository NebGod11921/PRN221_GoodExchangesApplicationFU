using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.ViewModels.ChatDTOs
{
    public class MessageDTO : BaseEntity
    {
        public int ChatSessionId { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int? UserId { get; set; }
    }
}
