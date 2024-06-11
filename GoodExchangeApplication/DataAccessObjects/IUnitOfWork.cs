﻿using DataAccessObjects.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IPostRepository PostRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
