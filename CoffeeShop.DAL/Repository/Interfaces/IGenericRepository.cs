﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DAL.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> AddAsync(TEntity item);
        public Task<List<TEntity>> GetListAsync();
        public Task<TEntity> GetByIdAsync(int id);
        public TEntity Update(TEntity item);
        public void Delete(int id);

    }
}
