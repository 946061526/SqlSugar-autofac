using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarDao
{
    public class DataAccess : IDataAccess
    {
        SqlSugarClient _db;
        public DataAccess()
        {
            _db = DbFactory.GetSqlSugarClient();
        }

        public long Add<T>(T entity, Expression<Func<T, object>> pk = null) where T : class, new()
        {
            if (pk != null)
                return _db.Insertable(entity).IgnoreColumns(pk).ExecuteReturnIdentity();
            else
                return _db.Insertable(entity).ExecuteReturnIdentity();
        }

        public long Add<T>(T[] entitys, Expression<Func<T, object>> pk = null) where T : class, new()
        {
            if (pk != null)
                return _db.Insertable(entitys).IgnoreColumns(pk).ExecuteReturnIdentity();
            else
                return _db.Insertable(entitys).ExecuteReturnIdentity();
        }

        public int Delete<T>(int[] primaryKeys) where T : class, new()
        {
            return _db.Deleteable<T>(primaryKeys).ExecuteCommand();
        }

        public int Delete<T>(int primaryKey) where T : class, new()
        {
            return _db.Deleteable<T>(primaryKey).ExecuteCommand();
        }

        public int Delete<T>(string where, object parameters) where T : class, new()
        {
            return _db.Deleteable<T>().Where(where, parameters).ExecuteCommand();
        }

        public int Delete<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _db.Deleteable(where).ExecuteCommand();
        }

        public int Edit<T>(T entity) where T : class, new()
        {
            return _db.Updateable(entity).ExecuteCommand();
        }

        public T Get<T>(int id) where T : class, new()
        {
            return _db.Queryable<T>().InSingle(id);
        }

        public T Get<T>(string where, object parameters) where T : class, new()
        {
            return _db.Queryable<T>().Where(where, parameters).Single();
        }

        public T Get<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _db.Queryable<T>().Where(where).Single();
        }

        public List<T> GetList<T>(string where, object parameters, string orderBy) where T : class, new()
        {
            return _db.Queryable<T>().Where(where, parameters).OrderBy(orderBy).ToList();
        }

        public List<T> GetList<T>(Expression<Func<T, bool>> where, string orderBy) where T : class, new()
        {
            return _db.Queryable<T>().Where(where).OrderBy(orderBy).ToList();
        }

        public List<T> GetListPage<T>(string where, object parameters, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new()
        {
            return _db.Queryable<T>().Where(where, parameters).OrderBy(orderBy).ToPageList(pageIndex, pageSize, ref total);
        }

        public List<T> GetListPage<T>(Expression<Func<T, bool>> where, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new()
        {
            return _db.Queryable<T>().Where(where).OrderBy(orderBy).ToPageList(pageIndex, pageSize, ref total);
        }
    }
}
