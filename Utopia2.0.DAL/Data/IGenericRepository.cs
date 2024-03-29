﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utopia2._0.DAL.Data
{
    interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(int id);
        IQueryable<T> AllQuery();
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
    }
}
