using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PrasadCodeFirst.Data.CommandQuery.Interfaces;
using PrasadCodeFirst.Data.EntityFramework.DbContexts;

namespace PrasadCodeFirst.Data.CommandQuery
{
    /// <summary>
    ///     A generic repository for working with data in the database
    /// </summary>
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        ///     The context object for the database
        /// </summary>
        protected readonly PrasadCodeFirstDbContext Context;

        /// <summary>
        ///     The contructor requires an open DataContext to work with
        /// </summary>
        protected Repository()
        {
            //TODO: Autofac
            Context = new PrasadCodeFirstDbContext();
        }

        /// <summary>
        ///     Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public T Get(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        /// <summary>
        ///     Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public async Task<T> GetAsync(Guid id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        /// <summary>
        ///     Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An IList of every object in the database</returns>
        public IList<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        /// <summary>
        ///     Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An IList of every object in the database</returns>
        public async Task<IList<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        ///     Gets a collection of all objects in the database
        /// </summary>
        /// <param name="pageIndex">Page index.</param>
        /// <param name="pageSize">Page size.</param>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An IList of every object in the database</returns>
        public async Task<IList<T>> GetAllAsync(int pageIndex, int pageSize)
        {
            return await Context.Set<T>().Skip(pageIndex).Take(pageSize).ToListAsync();
        }

        /// <summary>
        ///     Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>
        ///     A single object which matches the expression filter.
        ///     If more than one object is found or if zero are found, null is returned
        /// </returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await Context.Set<T>().SingleOrDefaultAsync(match);
        }

        /// <summary>
        ///     Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An IList of object which match the expression filter</returns>
        public IList<T> FindAll(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().Where(match).ToList();
        }

        /// <summary>
        ///     Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An IList of object which match the expression filter</returns>
        public async Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await Context.Set<T>().Where(match).ToListAsync();
        }

        /// <summary>
        ///     Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public T Add(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }
            
            Context.Set<T>().Add(t);
            Context.SaveChanges();
            return t;
        }

        /// <summary>
        ///     Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        public async Task<T> AddAsync(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }
            //T entityToAdd = ProcessIdFields(t, Actions.Add);
            Context.Set<T>().Add(t);
            await Context.SaveChangesAsync();
            return t;
        }

        /// <summary>
        ///     Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public IEnumerable<T> AddAll(IEnumerable<T> tList)
        {
            var addAll = tList as T[] ?? tList.ToArray();
            Context.Set<T>().AddRange(addAll);
            Context.SaveChanges();
            return addAll;
        }

        /// <summary>
        ///     Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="tList">An IEnumerable list of objects to insert</param>
        /// <returns>The IEnumerable resulting list of inserted objects including the primary keys</returns>
        public async Task<IEnumerable<T>> AddAllAsync(IEnumerable<T> tList)
        {
            //tList.ToList().ForEach(t => t = ProcessIdFields(t, Actions.Add));
            Context.Set<T>().AddRange(tList);
            await Context.SaveChangesAsync();
            return tList;
        }

        /// <summary>
        ///     Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public T Update(T updated, Guid key)
        {
            if (updated == null)
                return null;
            var existing = Context.Set<T>().Find(key);
            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(updated);
                //_context.Entry(existing).State = EntityState.Modified;
                Context.SaveChanges();
            }
            return existing;
        }

        /// <summary>
        ///     Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="updated">The updated object to apply to the database</param>
        /// <param name="key">The primary key of the object to update</param>
        /// <returns>The resulting updated object</returns>
        public async Task<T> UpdateAsync(T updated, Guid key)
        {
            if (updated == null)
                return null;
            var existing = await Context.Set<T>().FindAsync(key);
            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(updated);
                await Context.SaveChangesAsync();
            }
            return existing;
        }

        /// <summary>
        ///     Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="t">The object to delete</param>
        public void Delete(T t)
        {
            Context.Set<T>().Remove(t);
            Context.SaveChanges();
        }

        /// <summary>
        ///     Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="t">The object to delete</param>
        public async Task<int> DeleteAsync(T t)
        {
            Context.Set<T>().Remove(t);
            return await Context.SaveChangesAsync();
        }

        /// <summary>
        ///     Deletes records matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        public void Delete(Func<T, bool> predicate)
        {
            var records = from x in Context.Set<T>().Where(predicate) select x;
            foreach (var record in records)
            {
                Context.Set<T>().Remove(record);
            }
            Context.SaveChanges();
        }

        /// <summary>
        ///     Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public int Count()
        {
            return Context.Set<T>().Count();
        }

        /// <summary>
        ///     Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public async Task<int> CountAsync()
        {
            return await Context.Set<T>().CountAsync();
        }

        /// <summary>
        ///     Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public T Single(Func<T, bool> predicate)
        {
            return Context.Set<T>().Single(predicate);
        }

        /// <summary>
        ///     The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public T First(Func<T, bool> predicate)
        {
            return Context.Set<T>().First(predicate);
        }

        /// <summary>
        ///     Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An IList of object which match the expression filter</returns>
        public bool Any(Expression<Func<T, bool>> match)
        {
            return Context.Set<T>().Any(match);
        }

        /// <summary>
        ///     Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An IList of object which match the expression filter</returns>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> match)
        {
            return await Context.Set<T>().AnyAsync(match);
        }

        /// <summary>
        ///     Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Attaches the specified entity
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        public void Attach(T entity)
        {
            Context.Set<T>().Attach(entity);
        }

        public object GetPropertyValue(object obj, string propertyName)
        {
            var objType = obj.GetType();
            var prop = objType.GetProperty(propertyName);

            return prop.GetValue(obj, null);
        }

        /// <summary>
        ///     Releases all resources used
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                }
            }
        }
    }

    public enum Actions
    {
        Add,
        Update,
        Delete
    }
}