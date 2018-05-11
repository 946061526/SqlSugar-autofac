using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace SqlSugarDao
{
    public class DataAccess : IDataAccess
    {
        SqlSugarClient _db;
        public DataAccess()
        {
            //_db = DbFactory.GetSqlSugarClient();
            _db = DbFactory.DbClient;
        }

        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="pk">要忽略的主键</param>
        /// <returns>long</returns>
        public long Add<T>(T entity, Expression<Func<T, object>> pk = null) where T : class, new()
        {
            if (pk != null)
                return _db.Insertable(entity).IgnoreColumns(pk).ExecuteReturnIdentity();
            else
                return _db.Insertable(entity).ExecuteReturnIdentity();
        }
        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="pk">要忽略的主键</param>
        /// <returns>本批次最大主键ID</returns>
        public long Add<T>(T[] entitys, Expression<Func<T, object>> pk = null) where T : class, new()
        {
            if (pk != null)
                return _db.Insertable(entitys).IgnoreColumns(pk).ExecuteReturnIdentity();
            else
                return _db.Insertable(entitys).ExecuteReturnIdentity();
        }
        /// <summary>
        /// 按主键批量删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="primaryKeys">主键集合</param>
        /// <returns>受影响行数</returns>
        public int Delete<T>(int[] primaryKeys) where T : class, new()
        {
            return _db.Deleteable<T>(primaryKeys).ExecuteCommand();
        }
        /// <summary>
        /// 按主键删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="primaryKey">主键值</param>
        /// <returns>受影响行数</returns>
        public int Delete<T>(int primaryKey) where T : class, new()
        {
            return _db.Deleteable<T>(primaryKey).ExecuteCommand();
        }
        /// <summary>
        /// 按条件删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">条件语句，如："id=@id"</param>
        /// <param name="parameters">参数，如：new{id=0}</param>
        /// <returns>int</returns>
        public int Delete<T>(string where, object parameters) where T : class, new()
        {
            return _db.Deleteable<T>().Where(where, parameters).ExecuteCommand();
        }
        /// <summary>
        /// 按条件删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">条件语句</param>
        /// <returns>int</returns>
        public int Delete<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _db.Deleteable(where).ExecuteCommand();
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <returns>受影响行数</returns>
        public int Edit<T>(T entity) where T : class, new()
        {
            return _db.Updateable(entity).ExecuteCommand();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="columns">要编辑的列</param>
        /// <param name="where">条件</param>
        /// <returns>受影响行数</returns>        
        public int Edit<T>(T entity, Expression<Func<T, T>> columns, Expression<Func<T, bool>> where) where T : class, new()
        {
            return _db.Updateable(entity).UpdateColumns(columns).Where(where).ExecuteCommand();
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="id">主键</param>
        /// <returns>实体内容</returns>
        public T Get<T>(int id) where T : class, new()
        {
            return _db.Queryable<T>().InSingle(id);
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <returns></returns>
        public T Get<T>(string where, object parameters) where T : class, new()
        {
            return _db.Queryable<T>().Where(where, parameters).Single();
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public T Get<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _db.Queryable<T>().Where(where).Single();
        }
        /// <summary>
        /// 查询汇总条数
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <returns></returns>
        public int GetCount<T>(string where, object parameters) where T : class, new()
        {
            return _db.Queryable<T>().Where(where, parameters).Count();
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public int GetCount<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _db.Queryable<T>().Where(where).Count();
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如 new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <param name="orderBy">排序语句，如 "id asc"</param>
        /// <returns></returns>
        public List<T> GetList<T>(string where, object parameters, string orderBy) where T : class, new()
        {
            return _db.Queryable<T>().Where(where, parameters).OrderBy(orderBy).ToList();
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序语句</param>
        /// <returns></returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy) where T : class, new()
        {
            return _db.Queryable<T>().Where(where).OrderBy(orderBy).ToList();
        }
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
        public List<T> GetListPage<T>(string where, object parameters, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new()
        {
            return _db.Queryable<T>().Where(where, parameters).OrderBy(orderBy).ToPageList(pageIndex, pageSize, ref total);
        }
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
        public List<T> GetListPage<T>(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, int pageIndex, int pageSize, ref int total) where T : class, new()
        {
            return _db.Queryable<T>().Where(where).OrderBy(orderBy).ToPageList(pageIndex, pageSize, ref total);
        }


        #region Ado操作，执行sql语句
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="TReturn">实体</typeparam>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>实体集合</returns>
        public IEnumerable<TReturn> SqlQuery<TReturn>(string sql, object parameters) where TReturn : class, new()
        {
            //var dt = _db.Ado.GetDataTable("select * from table where id=@id", new SugarParameter("@id", 1));

            //var dt = _db.Ado.GetDataTable("select * from table where id=@id", new { id = 1 });

            //var dt = _db.Ado.GetDataTable("select * from table where id=@id and name=@name", new SugarParameter[]{
            //  new SugarParameter("@id",1),
            //  new SugarParameter("@name",2)
            //});
            return _db.Ado.SqlQuery<TReturn>(sql, parameters);
        }
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>实体</returns>
        public TReturn SqlQuerySingle<TReturn>(string sql, object parameters) where TReturn : class, new()
        {
            return _db.Ado.SqlQuerySingle<TReturn>(sql, parameters);
        }
        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(string sql, object parameters)
        {
            return _db.Ado.GetDataSetAll(sql, parameters);
        }
        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string sql, object parameters)
        {
            return _db.Ado.GetDataTable(sql, parameters);
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>int</returns>
        public int ExecuteSql(string sql, object parameters)
        {
            return _db.Ado.ExecuteCommand(sql, parameters);
        }
        /// <summary>
        /// 事物批量执行sql
        /// </summary>
        /// <param name="sqlList">sql语句集合</param>
        /// <returns>int</returns>
        public int ExecuteSql(List<string> sqlList)
        {
            var result = _db.Ado.UseTran(() =>
            {
                foreach (var sql in sqlList)
                    _db.Ado.ExecuteCommand(sql);
            });
            return result.IsSuccess ? 1 : 0;
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>int</returns>
        public int GetInt(string sql, object parameters)
        {
            return _db.Ado.GetInt(sql, parameters);
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>string</returns>
        public string GetString(string sql, object parameters)
        {
            return _db.Ado.GetString(sql, parameters);
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>decimal</returns>
        public decimal GetDecimal(string sql, object parameters)
        {
            return _db.Ado.GetDecimal(sql, parameters);
        }
        #endregion
    }
}
