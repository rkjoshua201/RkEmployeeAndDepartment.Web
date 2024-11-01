using JpEmployeeAndDepartment.EntityFramework;
using Microsoft.EntityFrameworkCore;
using RkEmployeeAndDepartment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RkEmployeeAndDepartment.MySql
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DefaultDbContext DbContext;
        private DbSet<TEntity> DbSet;
        public Repository(DefaultDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
            DbSet = DbContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity model)
        {
            await DbSet.AddAsync(model);
        }
        public IQueryable<TEntity> All()
        {
            return DbSet.AsNoTracking();
        }
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public void Update(TEntity model)
        {
            DbSet.Update(model);
        }
        public void Delete(TEntity model)
        {
            DbSet.Remove(model);
        }
        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
