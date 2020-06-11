using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tawjeeh.Infrastructure;
using Tawjeeh.Repositories.Interface;
using static Dapper.SqlMapper;
using System.Data;

namespace Tawjeeh.Repositories
{
    public abstract class BaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public IConnectionFactory _connectionFactory;     
        public BaseRepository(IConnectionFactory connectionFactory)
        {
            Guard.NotNull(connectionFactory, nameof(connectionFactory));
            _connectionFactory = connectionFactory;

        }
        public virtual int Create(TEntity entity)
        {         
            using (var _conn = _connectionFactory.GetConnection)
            {
                
                return Convert.ToInt32(_conn.Insert(entity));
            };           
        }
        public virtual int Delete(TEntity entity)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                return Convert.ToInt32(_conn.Delete(entity));
            }            

        }
        public virtual int Update(TEntity entity)
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                return Convert.ToInt32(_conn.Update(entity));
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                return await _conn.GetAllAsync<TEntity>().ConfigureAwait(false);
            }
        }

        public virtual IList<TEntity> GetAll()
        {
            using (var _conn = _connectionFactory.GetConnection)
            {
                return _conn.GetAll<TEntity>().AsList();
            }
        }

        //2 table Query
        public virtual Tuple<IEnumerable<T1>, IEnumerable<T2>> GetMultiple<T1, T2>(string sql, bool isSP, object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2)
        {
            var objs = parameters != null ? GetMultiple(sql,isSP ,parameters, func1, (Func<GridReader, object>)func2) :
                GetMultiple(sql, isSP, func1, (Func<GridReader, object>)func2);

            return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>);
        }
        //3 Table Query
        public virtual Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> GetMultiple<T1, T2, T3>(string sql, bool isSP,object parameters,
                                        Func<GridReader, IEnumerable<T1>> func1,
                                        Func<GridReader, IEnumerable<T2>> func2,
                                        Func<GridReader, IEnumerable<T3>> func3)
        {
            var objs = parameters != null ? GetMultiple(sql, isSP, parameters, func1, func2, (Func<GridReader, object>)func3):
                GetMultiple(sql, isSP, func1, func2, (Func<GridReader, object>)func3);
            return Tuple.Create(objs[0] as IEnumerable<T1>, objs[1] as IEnumerable<T2>, objs[2] as IEnumerable<T3>);
        }
        //5 Table Query
        public virtual Tuple<IEnumerable<T1>,IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>,
            IEnumerable<T5>> GetMultiple<T1, T2, T3, T4, T5>(string sql, bool isSP, object parameters,
                                       Func<GridReader, IEnumerable<T1>> func1,
                                       Func<GridReader, IEnumerable<T2>> func2,
                                       Func<GridReader, IEnumerable<T3>> func3,
                                       Func<GridReader, IEnumerable<T4>> func4,
                                       Func<GridReader, IEnumerable<T5>> func5)
        {
            var objs = GetMultiple(sql, isSP, parameters, func1, func2,func3,func4,(Func<GridReader, object>)func5);
            return Tuple.Create(objs[0] as IEnumerable<T1>, 
                                objs[1] as IEnumerable<T2>, 
                                objs[2] as IEnumerable<T3>,
                                objs[3] as IEnumerable<T4>,
                                objs[4] as IEnumerable<T5>);
        }

        public virtual Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>,
           IEnumerable<T5>, IEnumerable<T6>> GetMultiple<T1, T2, T3, T4, T5, T6>(string sql, bool isSP, object parameters,
                                      Func<GridReader, IEnumerable<T1>> func1,
                                      Func<GridReader, IEnumerable<T2>> func2,
                                      Func<GridReader, IEnumerable<T3>> func3,
                                      Func<GridReader, IEnumerable<T4>> func4,
                                      Func<GridReader, IEnumerable<T5>> func5,
                                      Func<GridReader, IEnumerable<T6>> func6)
        {
            var objs = GetMultiple(sql, isSP, parameters, func1, func2, func3, func4, func5, (Func<GridReader, object>)func6);
            return Tuple.Create(objs[0] as IEnumerable<T1>,
                                objs[1] as IEnumerable<T2>,
                                objs[2] as IEnumerable<T3>,
                                objs[3] as IEnumerable<T4>,
                                objs[4] as IEnumerable<T5>,
                                objs[5] as IEnumerable<T6>);
        }

        public virtual Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>,
           IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>> GetMultiple<T1, T2, T3, T4, T5,T6,T7>(string sql, bool isSP, object parameters,
                                      Func<GridReader, IEnumerable<T1>> func1,
                                      Func<GridReader, IEnumerable<T2>> func2,
                                      Func<GridReader, IEnumerable<T3>> func3,
                                      Func<GridReader, IEnumerable<T4>> func4,
                                      Func<GridReader, IEnumerable<T5>> func5,
                                      Func<GridReader, IEnumerable<T6>> func6,
                                      Func<GridReader, IEnumerable<T7>> func7)
        {
            var objs = GetMultiple(sql, isSP, parameters, func1, func2, func3, func4,func5,func6, (Func<GridReader, object>)func7);
            return Tuple.Create(objs[0] as IEnumerable<T1>,
                                objs[1] as IEnumerable<T2>,
                                objs[2] as IEnumerable<T3>,
                                objs[3] as IEnumerable<T4>,
                                objs[4] as IEnumerable<T5>,
                                objs[5] as IEnumerable<T6>,
                                objs[6] as IEnumerable<T7>);
        }
        private List<object> GetMultiple(string sql, bool isSP, object parameters,
            params Func<GridReader, object>[] readerFuncs)
        {
            var returnResults = new List<object>();
            using (var _conn = _connectionFactory.GetConnection)
            {
                var gridReader = _conn.QueryMultiple(sql, parameters,commandType:(isSP == true ? CommandType.StoredProcedure: CommandType.Text));

                foreach (var readerFunc in readerFuncs)
                {
                    var obj = readerFunc(gridReader);
                    returnResults.Add(obj);
                }
            }

            return returnResults;
        }
        private List<object> GetMultiple(string sql, bool isSP,
            params Func<GridReader, object>[] readerFuncs)
        {
            var returnResults = new List<object>();
            using (var _conn = _connectionFactory.GetConnection)
            {
                var gridReader = _conn.QueryMultiple(sql, commandType:(isSP == true ? CommandType.StoredProcedure : CommandType.Text));

                foreach (var readerFunc in readerFuncs)
                {
                    var obj = readerFunc(gridReader);
                    returnResults.Add(obj);
                }
            }

            return returnResults;
        }

    }
}
