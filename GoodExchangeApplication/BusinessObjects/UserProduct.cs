﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class UserProduct
    {
        public int? UserId {  get; set; }
        public int? ProductId { get; set; }
        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }
    }
}
