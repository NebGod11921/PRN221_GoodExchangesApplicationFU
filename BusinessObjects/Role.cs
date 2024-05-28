using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Role : BaseEntity
    {
        public string? RoleName { get; set; }
        public virtual IEnumerable<Role>? Roles { get; set;}
    }
}
