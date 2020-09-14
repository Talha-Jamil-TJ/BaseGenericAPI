using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopManagement.models;

namespace ShopManagement.Generics.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly DataContext _context;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(DataContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        #region IBaseRepository<T> Members

        // public DbSet<T> Entity => DbSet;

        public async Task<int> CountAsync() => await DbSet.CountAsync();

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate) => await DbSet.CountAsync(predicate);

        public async Task<T> Get(int id) => await DbSet.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<T> All() => DbSet;

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => DbSet.Where(predicate);

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate) =>
            await DbSet.FirstOrDefaultAsync(predicate);

        public virtual async Task<EntityEntry<T>> Add(T entity) => await DbSet.AddAsync(entity);

        public virtual async Task AddRange(IEnumerable<T> entityList) => await DbSet.AddRangeAsync(entityList);

        public virtual EntityEntry<T> Delete(T entity) => DbSet.Remove(entity);

        public virtual void Edit(T entity) => _context.Entry(entity).State = EntityState.Modified;

        public virtual async Task<bool> SaveAsync() => await _context.SaveChangesAsync() > 0;

        public virtual bool Save() => _context.SaveChanges() > 0;

        public DbContext GetDbContext() => _context;

        #endregion

        public async Task<IList<T>> ToListAsync() => await DbSet.ToListAsync();

        public async Task<IList<T>> ToListAsync<TProperty>(Expression<Func<T, TProperty>> includePath) =>
            await DbSet.Include(includePath).ToListAsync();

        public async Task<IList<T>> ToListAsync<TProperty1, TProperty2>(Expression<Func<T, TProperty1>> includePath1,
            Expression<Func<T, TProperty2>> includePath2) =>
            await DbSet.Include(includePath1).Include(includePath2).ToListAsync();

        public async Task<IList<T>> ToListAsync<TProperty1, TProperty2, TProperty3>(
            Expression<Func<T, TProperty1>> includePath1, Expression<Func<T, TProperty2>> includePath2,
            Expression<Func<T, TProperty3>> includePath3) =>
            await DbSet.Include(includePath1).Include(includePath2).Include(includePath3).ToListAsync();

        public async Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate) =>
            await DbSet.Where(predicate).ToListAsync();

        public async Task<IList<T>> WhereAsync<TProperty>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProperty>> includePath) =>
            await DbSet.Where(predicate).Include(includePath).ToListAsync();

        public async Task<IList<T>> WhereAsync<TProperty1, TProperty2>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProperty1>> includePath1, Expression<Func<T, TProperty2>> includePath2) =>
            await DbSet.Where(predicate).Include(includePath1).Include(includePath2).ToListAsync();

        public async Task<IList<T>> WhereAsync<TProperty1, TProperty2, TProperty3>(
            Expression<Func<T, bool>> predicate, Expression<Func<T, TProperty1>> includePath1,
            Expression<Func<T, TProperty2>> includePath2, Expression<Func<T, TProperty3>> includePath3) =>
            await DbSet.Where(predicate).Include(includePath1).Include(includePath2).Include(includePath3)
               .ToListAsync();
    }
}