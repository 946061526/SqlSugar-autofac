using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
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


        #region Ado操作，执行sql语句
        public IEnumerable<TReturn> SqlQuery<TReturn>(string sql, IDictionary<string, object> dic = null) where TReturn : class, new()
        {
            //var dt = _db.Ado.GetDataTable("select * from table where id=@id", new SugarParameter("@id", 1));

            //var dt = _db.Ado.GetDataTable("select * from table where id=@id and name=@name", new SugarParameter[]{
            //  new SugarParameter("@id",1),
            //  new SugarParameter("@name",2)
            //});
            return _db.Ado.SqlQuery<TReturn>(sql, dic);
        }

        public TReturn SqlQuerySingle<TReturn>(string sql, IDictionary<string, object> dic = null) where TReturn : class, new()
        {
            return _db.Ado.SqlQuerySingle<TReturn>(sql, dic);
        }

        public DataSet GetDataSet(string sql, IDictionary<string, object> dic = null)
        {
            return _db.Ado.GetDataSetAll(sql, dic);
        }

        public DataTable GetDataTable(string sql, IDictionary<string, object> dic = null)
        {
            return _db.Ado.GetDataTable(sql, dic);
        }

        public int ExecuteSql(string sql, IDictionary<string, object> dic = null, bool isTran = false)
        {
            if (isTran)
            {
                var result = _db.Ado.UseTran(() =>
                {
                    return _db.Ado.ExecuteCommand(sql, dic);
                });
                return result.IsSuccess ? result.Data : 0;
            }
            return _db.Ado.ExecuteCommand(sql, dic);
        }

        public int GetInt(string sql, IDictionary<string, object> dic = null)
        {
            return _db.Ado.GetInt(sql, dic);
        }

        public string GetString(string sql, IDictionary<string, object> dic = null)
        {
            return _db.Ado.GetString(sql, dic);
        }

        public decimal GetDecimal(string sql, IDictionary<string, object> dic = null)
        {
            return _db.Ado.GetDecimal(sql, dic);
        }
        #endregion
    }
}
