﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects.IRepositories
{
    public interface ICurrentTime
    {
        public DateTime GetCurrentTime();
    }
}
