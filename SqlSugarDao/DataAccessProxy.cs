using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarDao
{
    public class DataAccessProxy
    {
        private static IDataAccess _dataAccess = null;

        static DataAccessProxy()
        {
            _dataAccess = Utility.IocContainer.Resolve<IDataAccess>();
        }

        public static long Add<T>(T entity, Expression<Func<T, object>> pk = null) where T : class, new()
        {
            return _dataAccess.Add(entity, pk);
        }

        public static long Add<T>(T[] entitys, Expression<Func<T, object>> pk = null) where T : class, new()
        {
            return _dataAccess.Add(entitys, pk);
        }

        public static int Delete<T>(int[] primaryKeys) where T : class, new()
        {
            return _dataAccess.Delete<T>(primaryKeys);
        }

        public static int Delete<T>(int primaryKey) where T : class, new()
        {
            return _dataAccess.Delete<T>(primaryKey);
        }

        public static int Delete<T>(string where, object parameters) where T : class, new()
        {
            return _dataAccess.Delete<T>(where, parameters);
        }

        public static int Delete<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _dataAccess.Delete(where);
        }

        public static int Edit<T>(T entity) where T : class, new()
        {
            return _dataAccess.Edit(entity);
        }

        public static T Get<T>(int id) where T : class, new()
        {
            return _dataAccess.Get<T>(id);
        }

        public static T Get<T>(string where, object parameters) where T : class, new()
        {
            return _dataAccess.Get<T>(where, parameters);
        }

        public static T Get<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _dataAccess.Get(where);
        }

        public static List<T> GetList<T>(string where, object parameters, string orderBy) where T : class, new()
        {
            return _dataAccess.GetList<T>(where, parameters, orderBy);
        }

        public static List<T> GetList<T>(Expression<Func<T, bool>> where, string orderBy) where T : class, new()
        {
            return _dataAccess.GetList(where, orderBy);
        }

        public static List<T> GetListPage<T>(string where, object parameters, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new()
        {
            return _dataAccess.GetListPage<T>(where, parameters, orderBy, pageIndex, pageSize, ref total);
        }

        public static List<T> GetListPage<T>(Expression<Func<T, bool>> where, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new()
        {
            return _dataAccess.GetListPage(where, orderBy, pageIndex, pageSize, ref total);
        }

        #region Ado操作
        public IEnumerable<TReturn> SqlQuery<TReturn>(string sql, IDictionary<string, object> dic = null) where TReturn : class, new()
        {
            return _dataAccess.SqlQuery<TReturn>(sql, dic);
        }

        public TReturn SqlQuerySingle<TReturn>(string sql, IDictionary<string, object> dic = null) where TReturn : class, new()
        {
            return _dataAccess.SqlQuerySingle<TReturn>(sql, dic);
        }

        public DataSet GetDataSet(string sql, IDictionary<string, object> dic = null)
        {
            return _dataAccess.GetDataSet(sql, dic);
        }

        public DataTable GetDataTable(string sql, IDictionary<string, object> dic = null)
        {
            return _dataAccess.GetDataTable(sql, dic);
        }

        public int ExecuteSql(string sql, IDictionary<string, object> dic = null, bool isTran = false)
        {
            return _dataAccess.ExecuteSql(sql, dic, isTran);
        }

        public int GetInt(string sql, IDictionary<string, object> dic = null)
        {
            return _dataAccess.GetInt(sql, dic);
        }

        public string GetString(string sql, IDictionary<string, object> dic = null)
        {
            return _dataAccess.GetString(sql, dic);
        }

        public decimal GetDecimal(string sql, IDictionary<string, object> dic = null)
        {
            return _dataAccess.GetDecimal(sql, dic);
        }
        #endregion
    }
}