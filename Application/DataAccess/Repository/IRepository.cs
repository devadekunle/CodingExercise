﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataAccess.Repository
{
    public interface IRepository<T> where T:class 
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);

        Task<T> FindAsync(Guid key);
    }
}
