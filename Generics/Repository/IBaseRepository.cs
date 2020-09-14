using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ShopManagement.Generics.Repository
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task<T> Get(int id);

        Task<IList<T>> ToListAsync();

        Task<IList<T>> ToListAsync<TProperty>(Expression<Func<T, TProperty>> includePath);

        Task<IList<T>> ToListAsync<TProperty1, TProperty2>(Expression<Func<T, TProperty1>> includePath1,
            Expression<Func<T, TProperty2>> includePath2);

        Task<IList<T>> ToListAsync<TProperty1, TProperty2, TProperty3>(Expression<Func<T, TProperty1>> includePath1,
            Expression<Func<T, TProperty2>> includePath2, Expression<Func<T, TProperty3>> includePath3);

        IQueryable<T> All();

        Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate);

        Task<IList<T>> WhereAsync<TProperty>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProperty>> includePath);

        Task<IList<T>> WhereAsync<TProperty1, TProperty2>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProperty1>> includePath1, Expression<Func<T, TProperty2>> includePath2);

        Task<IList<T>> WhereAsync<TProperty1, TProperty2, TProperty3>(Expression<Func<T, bool>> predicate,
            Expression<Func<T, TProperty1>> includePath1, Expression<Func<T, TProperty2>> includePath2,
            Expression<Func<T, TProperty3>> includePath3);

        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<EntityEntry<T>> Add(T entity);

        Task AddRange(IEnumerable<T> entityList);

        EntityEntry<T> Delete(T entity);

        void Edit(T entity);

        Task<bool> SaveAsync();

        bool Save();

        DbContext GetDbContext();
    }
}