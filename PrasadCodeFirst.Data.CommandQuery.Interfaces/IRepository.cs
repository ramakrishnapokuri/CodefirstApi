using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrasadCodeFirst.Data.CommandQuery.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Add(T t);
        IEnumerable<T> AddAll(IEnumerable<T> tList);
        Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> tList);
        Task<T> AddAsync(T t);
        void Attach(T entity);
        int Count();
        Task<int> CountAsync();
        void Delete(Func<T, bool> predicate);
        void Delete(T t);
        Task<int> DeleteAsync(T t);
        IList<T> FindAll(Expression<Func<T, bool>> match);
        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        T First(Func<T, bool> predicate);
        T Get(Guid id);
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetAllAsync(int pageIndex, int pageSize);
        Task<T> GetAsync(Guid id);
        object GetPropertyValue(object obj, string propertyName);
        T Single(Func<T, bool> predicate);
        T Update(T updated, Guid key);
        Task<T> UpdateAsync(T updated, Guid key);
        bool Any(Expression<Func<T, bool>> match);
        Task<bool> AnyAsync(Expression<Func<T, bool>> match);
    }
}