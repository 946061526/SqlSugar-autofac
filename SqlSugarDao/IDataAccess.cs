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
        /// <param name="pk">要忽略的主键</param>
        /// <returns>long</returns>
        long Add<T>(T entity, Expression<Func<T, object>> pk = null) where T : class, new();
        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="pk">要忽略的主键</param>
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
        /// <summary>
        /// 按条件删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">条件语句，如："id=@id"</param>
        /// <param name="parameters">参数，如：new{id=0}</param>
        /// <returns>int</returns>
        int Delete<T>(string where, object parameters) where T : class, new();
        /// <summary>
        /// 按条件删除
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">条件语句</param>
        /// <returns>int</returns>
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
        /// <param name="where">查询条件,如 "id=@id"</param>
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
        /// <summary>
        /// 查询汇总条数
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <returns></returns>
        int GetCount<T>(string where, object parameters) where T : class, new();
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        int GetCount<T>(Expression<Func<T, bool>> where) where T : class, new();
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如 new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <param name="orderBy">排序语句，如 "id asc"</param>
        /// <returns></returns>
        List<T> GetList<T>(string where, object parameters, string orderBy) where T : class, new();
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序语句</param>
        /// <returns></returns>
        List<T> GetList<T>(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy) where T : class, new();
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如 new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <param name="orderBy">排序语句，如 "id asc"</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="total">总条数</param>
        /// <returns></returns>
        List<T> GetListPage<T>(string where, object parameters, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new();
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序语句</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="total">总条数</param>
        /// <returns></returns>
        List<T> GetListPage<T>(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, int pageIndex, int pageSize, ref int total) where T : class, new();


        #region Ado操作
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="TReturn">实体</typeparam>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>实体集合</returns>
        IEnumerable<TReturn> SqlQuery<TReturn>(string sql, object parameters) where TReturn : class, new();
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>实体</returns>
        TReturn SqlQuerySingle<TReturn>(string sql, object parameters) where TReturn : class, new();
        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>DataTable</returns>
        DataTable GetDataTable(string sql, object parameters);
        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>DataSet</returns>
        DataSet GetDataSet(string sql, object parameters);
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>int</returns>
        int ExecuteSql(string sql, object parameters);
        /// <summary>
        /// 事物批量执行sql
        /// </summary>
        /// <param name="sql">sql语句集合</param>
        /// <returns>int</returns>
        int ExecuteSql(List<string> sqlList);
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>int</returns>
        int GetInt(string sql, object parameters);
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>string</returns>
        string GetString(string sql, object parameters);
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>decimal</returns>
        decimal GetDecimal(string sql, object parameters);
        #endregion
    }
}
