using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugarDao
{
    public interface IDataAccess
    {
        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="isIgnorPk">是否忽略主键</param>
        /// <returns>主键ID</returns>
        long Add<T>(T entity, Expression<Func<T, object>> pk = null) where T : class, new();
        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="isIgnorPk">是否忽略主键</param>
        /// <returns>本批次最大主键ID</returns>
        long Add<T>(T[] entitys, Expression<Func<T, object>> pk = null) where T : class, new();
        /// <summary>
        /// 按主键批量删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="primaryKeys">主键集合</param>
        /// <returns>受影响行数</returns>
        int Delete<T>(int[] primaryKeys) where T : class, new();
        /// <summary>
        /// 按主键删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="primaryKey">主键值</param>
        /// <returns>受影响行数</returns>
        int Delete<T>(int primaryKey) where T : class, new();
        int Delete<T>(string where, object parameters) where T : class, new();
        int Delete<T>(Expression<Func<T, bool>> where) where T : class, new();
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <returns>受影响行数</returns>
        int Edit<T>(T entity) where T : class, new();
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="id">主键</param>
        /// <returns>实体内容</returns>
        T Get<T>(int id) where T : class, new();
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如where id=@id</param>
        /// <param name="parameters">条件参数，如new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <returns></returns>
        T Get<T>(string where, object parameters) where T : class, new();
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        T Get<T>(Expression<Func<T, bool>> where) where T : class, new();

        List<T> GetList<T>(string where, object parameters, string orderBy) where T : class, new();
        List<T> GetList<T>(Expression<Func<T, bool>> where, string orderBy) where T : class, new();
        List<T> GetListPage<T>(string where, object parameters, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new();
        List<T> GetListPage<T>(Expression<Func<T, bool>> where, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new();


        #region Ado操作
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="TReturn">查询返回实体</typeparam>
        /// <param name="sql">sql字符串</param>
        /// <param name="dic">字典</param>
        /// <returns>返回实体</returns>
        IEnumerable<TReturn> SqlQuery<TReturn>(string sql, IDictionary<string, object> dic = null) where TReturn : class, new();
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        TReturn SqlQuerySingle<TReturn>(string sql, IDictionary<string, object> dic = null) where TReturn : class, new();
        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="dic">字典</param>
        /// <returns>返回datatable</returns>
        DataTable GetDataTable(string sql, IDictionary<string, object> dic = null);
        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql字符串</param>
        /// <param name="dic">字典</param>
        /// <returns>返回dataset</returns>
        DataSet GetDataSet(string sql, IDictionary<string, object> dic = null);

        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dic"></param>
        /// <param name="isTran"></param>
        /// <returns></returns>
        int ExecuteSql(string sql, IDictionary<string, object> dic = null, bool isTran = false);

        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        int GetInt(string sql, IDictionary<string, object> dic = null);
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        string GetString(string sql, IDictionary<string, object> dic = null);
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        decimal GetDecimal(string sql, IDictionary<string, object> dic = null);
        #endregion
    }
}
