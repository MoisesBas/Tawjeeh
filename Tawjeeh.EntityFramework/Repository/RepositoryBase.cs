
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Tawjeeh.EntityFramework.Helper;
using Tawjeeh.EntityFramework.Interface;

namespace Tawjeeh.EntityFramework.Repository
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public abstract class RepositoryBase<TContext> : IDisposable
         where TContext : DbContext, IDisposedTracker, new()
    {
        /// <summary>
        /// The data context
        /// </summary>
        private TContext _DataContext;
        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected virtual TContext DataContext
        {
            get
            {
                if (_DataContext == null || _DataContext.IsDisposed)
                {
                    _DataContext = new TContext();
                    AllowSerialization = true;
                    ProxyCreationEnabled = true;
                    AllowLazyLoading = false;                   
                }
                return _DataContext;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [allow lazy loading].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow lazy loading]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool AllowLazyLoading
        {
            get
            {
                return _DataContext.Configuration.LazyLoadingEnabled;

            }
            set
            {
                _DataContext.Configuration.LazyLoadingEnabled = !value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [proxy creation enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [proxy creation enabled]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool ProxyCreationEnabled
        {
            get
            {
                return _DataContext.Configuration.ProxyCreationEnabled;

            }
            set
            {
                _DataContext.Configuration.ProxyCreationEnabled = !value;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether [allow serialization].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow serialization]; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool AllowSerialization
        {
            get
            {
                return _DataContext.Configuration.ProxyCreationEnabled;

            }
            set
            {
                _DataContext.Configuration.ProxyCreationEnabled = !value;
            }
        }
        /// <summary>
        /// Finds the by key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected virtual T FindByKey<T>(object key) where T : class
            => DataContext.Set<T>().Find(key);
        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected virtual T FirstOrDefault<T>(IQuery<T> query) where T : class
            => GetAllQuery(query).FirstOrDefault();

        /// <summary>
        /// Firsts the or default disposable asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected virtual async Task<T> FirstOrDefaultDisposableAsync<T>(IQuery<T> query) where T : class
        {
            using (DataContext)
            {
                IQueryable<T> result = query.Filter(DataContext.Set<T>());
                return await result.FirstOrDefaultAsync();
            }
        }
        /// <summary>
        /// Firsts the or default disposable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        protected virtual T FirstOrDefaultDisposable<T>(IQuery<T> query, string includeProperties = "") where T : class
        {
            using (DataContext)
            {

                IQueryable<T> result = query.Filter(DataContext.Set<T>());
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    result = result.Include(includeProperty);
                }
                return result.FirstOrDefault();
            }
        }

        /// <summary>
        /// Firsts the or default disposable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected virtual T FirstOrDefaultDisposable<T>(IQuery<T> query) where T : class
        {
            using (DataContext)
            {

                IQueryable<T> result = query.Filter(DataContext.Set<T>());                
                return result.FirstOrDefault();
            }
        }
        /// <summary>
        /// Counts the specified query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected virtual long Count<T>(IQuery<T> query) where T : class
            => GetAllQuery(query).Count();
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual IQueryable<T> GetList<T>() where T : class
        {
            try
            {
                return DataContext.Set<T>();
            }
            catch (Exception ex)
            {
                //Log error
            }
            return null;
        }
        /// <summary>
        /// Gets all include query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        protected virtual IQueryable<T> GetAllIncludeQuery<T>(string includeProperties = "") where T : class
        {
            IQueryable<T> result = DataContext.Set<T>();
            foreach (var includeProperty in includeProperties.Split
              (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                result = result.Include(includeProperty);
            }
            
            return result;
        }
        /// <summary>
        /// Gets all not include query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual IQueryable<T> GetAllNotIncludeQuery<T>() where T : class
        {
            IQueryable<T> result = DataContext.Set<T>();
            return result;
        }
        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        protected virtual IEnumerable<T> GetAllQuery<T>(string includeProperties = "") where T : class
        {
            using (DataContext)
            {
                IQueryable<T> result = DataContext.Set<T>();

                foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    result = result.Include(includeProperty);
                }
                return result.ToList();
            };
        }
        /// <summary>
        /// Gets all query disposable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        protected virtual IEnumerable<T> GetAllQueryDisposable<T>(IQuery<T> query, string includeProperties = "") where T : class
        {
            using (DataContext)
            {
                IQueryable<T> result = query.Filter(DataContext.Set<T>());

                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    result = result.Include(includeProperty);
                }

                return result.ToList();
            }
        }
        /// <summary>
        /// Gets all query disposable asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        protected virtual async Task<IEnumerable<T>> GetAllQueryDisposableAsync<T>(IQuery<T> query, string includeProperties = "") where T : class
        {
            using (DataContext)
            {
                IQueryable<T> result = query.Filter(DataContext.Set<T>());

                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    result = result.Include(includeProperty);
                }    
             
                return await result.ToListAsync<T>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        protected virtual IQueryable<T> GetAllQuery<T>(IQuery<T> query) where T : class => query.Filter(DataContext.Set<T>());
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        protected virtual T GetById<T>(long id) where T : class
        {
            using (DataContext)
            {
                var entity = DataContext.Set<T>().Find(id);
                if(id != 0) DataContext.Entry(entity).State = EntityState.Detached;
                return entity;               
            }
        }
        /// <summary>
        /// Gets the list disposable context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual IEnumerable<T> GetListDisposableContext<T>() where T : class
        {
            using (DataContext)
            {
                IEnumerable<T> query = DataContext.Set<T>().AsNoTracking().ToList<T>();
                return query;
            }
        }
        /// <summary>
        /// Gets the list disposable context asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual async Task<IEnumerable<T>> GetListDisposableContextAsync<T>() where T : class
        {
            using (DataContext)
            {
                IEnumerable<T> query = await DataContext.Set<T>().ToListAsync<T>().ConfigureAwait(false);
                return query;
            }
        }

        /// <summary>
        /// Gets the store list disposable context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        protected virtual IEnumerable<T> GetStoreListDisposableContext<T>(string storedProcedure, object[] parameters) where T : class
        {
            using (DataContext)
            {
                IEnumerable<T> query = DataContext.Database.SqlQuery<T>(storedProcedure, parameters).ToList<T>();
                return query;
            }
        }
        /// <summary>
        /// Gets the single disposable context asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        protected virtual async Task<T> GetSingleDisposableContextAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            using (DataContext)
            {
                T query = await DataContext.Set<T>().Where(predicate).FirstOrDefaultAsync().ConfigureAwait(false);
                return query;
            }
        }
        /// <summary>
        /// Inserts the or update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        protected virtual int InsertOrUpdate<T>(T entity) where T : class
        {
            try
            {
                using (DataContext)
                {
                    var id = (long)GetPropertyValue(entity, "Id");

                    DataContext.Entry(entity).State = id == 0 ? EntityState.Added : EntityState.Modified;
                    DataContext.SaveChanges();
                    return Convert.ToInt32(GetPropertyValue(entity, "Id")); 
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Deletes the record.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        protected virtual int DeleteRecord<T>(T entity) where T : class
        {
            try
            {
                using (DataContext)
                {
                    DataContext.Entry(entity).State = EntityState.Deleted;
                    return DataContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private object GetPropertyValue<T>(T item, string name) where T : class
        {
            Type t = item.GetType();

            PropertyInfo prop = t.GetProperty(name);

            object propertyValue = prop.GetValue(item);
            return propertyValue;
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            if (DataContext != null) DataContext.Dispose();
        }

        /// <summary>
        /// Collections the delete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id">The identifier.</param>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public List<KeyValuePair<int, List<T>>> CollectionDelete<T>(int Id,List<T> items) where T: class
        {
            return new List<KeyValuePair<int, List<T>>>
            {
                new KeyValuePair<int, List<T>>(Id,items)
            };
        }
        /// <summary>
        /// Batches the soft delete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TContext BatchSoftDelete<T>(TContext context,
            T entity) where T : class
        {
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Deleted;                
            }
            return context;
        }
        /// <summary>
        /// Performs the batch delete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="listOfItem">The list of item.</param>
        /// <returns></returns>
        public TContext PerformBatchDelete<T>(TContext context, IEnumerable<T> listOfItem) where T: class
        {
            int count = 0;
            if (listOfItem.Count() > 0)
            {
                
                foreach (var entityToInsert in listOfItem)
                {
                    ++count;
                    context = BatchSoftDelete(context, entityToInsert);
                }
            }
            return context;
        }
        /// <summary>
        /// Batches the insert or update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public TContext BatchInsertOrUpdate<T>(TContext context,
           T entity) where T : class
        {
            if (entity != null)
            {
                var id = (long)GetPropertyValue(entity, "Id");
                context.Entry(entity).State = id == 0 ? EntityState.Added : EntityState.Modified;
            }
            return context;
        }
        /// <summary>
        /// Performs the insert or update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="listOfItem">The list of item.</param>
        /// <returns></returns>
        public TContext PerformInsertOrUpdate<T>(TContext context, IEnumerable<T> listOfItem) where T : class
        {
            int count = 0;
            if (listOfItem.Count() > 0)
            {

                foreach (var entityToInsert in listOfItem)
                {
                    ++count;
                    context = BatchInsertOrUpdate(context, entityToInsert);
                }
            }
            return context;
        }

    }
}
