﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace SqlSugarDao
{
    /// <summary>
    /// DataAccess代理
    /// </summary>
    public class DataAccessProxy
    {
        private static IDataAccess _dataAccess = null;

        static DataAccessProxy()
        {
            _dataAccess = Utility.IocContainer.Resolve<IDataAccess>();
        }

        #region 插入
        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="pk">要忽略的主键</param>
        /// <returns>long</returns>
        public static long Add<T>(T entity, Expression<Func<T, object>> pk = null) where T : class, new()
        {
            return _dataAccess.Add(entity, pk);
        }
        /// <summary>
        /// 插入一个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="pk">要忽略的主键</param>
        /// <returns>本批次最大主键ID</returns>
        public static long Add<T>(T[] entitys, Expression<Func<T, object>> pk = null) where T : class, new()
        {
            return _dataAccess.Add(entitys, pk);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 按主键批量删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="primaryKeys">主键集合</param>
        /// <returns>受影响行数</returns>
        public static int Delete<T>(int[] primaryKeys) where T : class, new()
        {
            return _dataAccess.Delete<T>(primaryKeys);
        }
        /// <summary>
        /// 按主键删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="primaryKey">主键值</param>
        /// <returns>受影响行数</returns>
        public static int Delete<T>(int primaryKey) where T : class, new()
        {
            return _dataAccess.Delete<T>(primaryKey);
        }
        /// <summary>
        /// 按条件删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">条件语句，如："id=@id"</param>
        /// <param name="parameters">参数，如：new{id=0}</param>
        /// <returns>int</returns>
        public static int Delete<T>(string where, object parameters) where T : class, new()
        {
            return _dataAccess.Delete<T>(where, parameters);
        }
        /// <summary>
        /// 按条件删除(物理删除)
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">条件语句</param>
        /// <returns>int</returns>
        public static int Delete<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _dataAccess.Delete(where);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <returns>受影响行数</returns>
        public static int Edit<T>(T entity) where T : class, new()
        {
            return _dataAccess.Edit(entity);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="entity">实体内容</param>
        /// <param name="columns">要编辑的列</param>
        /// <param name="where">条件</param>
        /// <returns>受影响行数</returns>
        public static int Edit<T>(T entity, Expression<Func<T, T>> columns, Expression<Func<T, bool>> where) where T : class, new()
        {
            return _dataAccess.Edit(entity, columns, where);
        }
        #endregion

        #region 查询单个
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="id">主键</param>
        /// <returns>实体内容</returns>
        public static T Get<T>(int id) where T : class, new()
        {
            return _dataAccess.Get<T>(id);
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <returns></returns>
        public static T Get<T>(string where, object parameters) where T : class, new()
        {
            return _dataAccess.Get<T>(where, parameters);
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public static T Get<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _dataAccess.Get(where);
        }
        #endregion

        #region 查询总条数
        /// <summary>
        /// 查询汇总条数
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <returns></returns>
        public static int GetCount<T>(string where, object parameters) where T : class, new()
        {
            return _dataAccess.GetCount<T>(where, parameters);
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public static int GetCount<T>(Expression<Func<T, bool>> where) where T : class, new()
        {
            return _dataAccess.GetCount(where);
        }
        #endregion

        #region 查询列表
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件,如 "id=@id"</param>
        /// <param name="parameters">条件参数，如 new SugarParameter("@id",1) 或 new { id = 1 }</param>
        /// <param name="orderBy">排序语句，如 "id asc"</param>
        /// <returns></returns>
        public static List<T> GetList<T>(string where, object parameters, string orderBy) where T : class, new()
        {
            return _dataAccess.GetList<T>(where, parameters, orderBy);
        }
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="T">表实体</typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序语句</param>
        /// <returns></returns>
        public static List<T> GetList<T>(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy) where T : class, new()
        {
            return _dataAccess.GetList(where, orderBy);
        }
        #endregion

        #region 查询分页
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
        public static List<T> GetListPage<T>(string where, object parameters, string orderBy, int pageIndex, int pageSize, ref int total) where T : class, new()
        {
            return _dataAccess.GetListPage<T>(where, parameters, orderBy, pageIndex, pageSize, ref total);
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
        public static List<T> GetListPage<T>(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, int pageIndex, int pageSize, ref int total) where T : class, new()
        {
            return _dataAccess.GetListPage(where, orderBy, pageIndex, pageSize, ref total);
        }
        #endregion

        #region 多表查询
        /// <summary>
        /// 两表join
        /// </summary>
        /// <typeparam name="T">表1</typeparam>
        /// <typeparam name="T2">表2</typeparam>
        /// <typeparam name="TResult">返回的内容实体</typeparam>
        /// <param name="joinExpression">连接条件</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="selectColumns">返回的实体字段</param>
        /// <returns></returns>
        public static List<TResult> GetList<T, T2, TResult>(Expression<Func<T, T2, object[]>> joinExpression, Expression<Func<T, bool>> where, Expression<Func<T, T2, object>> orderBy, Expression<Func<T, T2, TResult>> selectColumns) where T : class, new()
        {
            return _dataAccess.GetList(joinExpression, where, orderBy, selectColumns);
        }
        /// <summary>
        /// 三表join
        /// </summary>
        /// <typeparam name="T">表1</typeparam>
        /// <typeparam name="T2">表2</typeparam>
        /// <typeparam name="T3">表3</typeparam>
        /// <typeparam name="TResult">返回的内容实体</typeparam>
        /// <param name="joinExpression">连接条件</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="selectColumns">返回的实体字段</param>
        /// <returns></returns>
        public static List<TResult> GetList<T, T2, T3, TResult>(Expression<Func<T, T2, T3, object[]>> joinExpression, Expression<Func<T, bool>> where, Expression<Func<T, T2, object>> orderBy, Expression<Func<T, T2, T3, TResult>> selectColumns) where T : class, new()
        {
            return _dataAccess.GetList(joinExpression, where, orderBy, selectColumns);
        }
        /// <summary>
        /// 四表join
        /// </summary>
        /// <typeparam name="T">表1</typeparam>
        /// <typeparam name="T2">表2</typeparam>
        /// <typeparam name="T3">表3</typeparam>
        /// <typeparam name="T4">表4</typeparam>
        /// <typeparam name="TResult">返回的内容实体</typeparam>
        /// <param name="joinExpression">连接条件</param>
        /// <param name="where">查询条件</param>
        /// <param name="orderBy">排序条件</param>
        /// <param name="selectColumns">返回的实体字段</param>
        /// <returns></returns>
        public static List<TResult> GetList<T, T2, T3, T4, TResult>(Expression<Func<T, T2, T3, T4, object[]>> joinExpression, Expression<Func<T, bool>> where, Expression<Func<T, T2, object>> orderBy, Expression<Func<T, T2, T3, T4, TResult>> selectColumns) where T : class, new()
        {
            return _dataAccess.GetList(joinExpression, where, orderBy, selectColumns);
        }
        #endregion

        #region Ado操作
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="TReturn">实体</typeparam>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>实体集合</returns>
        public static IEnumerable<TReturn> SqlQuery<TReturn>(string sql, object parameters) where TReturn : class, new()
        {
            return _dataAccess.SqlQuery<TReturn>(sql, parameters);
        }
        /// <summary>
        /// sql查询
        /// </summary>
        /// <typeparam name="TReturn">实体</typeparam>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>实体</returns>
        public static TReturn SqlQuerySingle<TReturn>(string sql, object parameters) where TReturn : class, new()
        {
            return _dataAccess.SqlQuerySingle<TReturn>(sql, parameters);
        }
        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string sql, object parameters)
        {
            return _dataAccess.GetDataSet(sql, parameters);
        }
        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDataTable(string sql, object parameters)
        {
            return _dataAccess.GetDataTable(sql, parameters);
        }
        /// <summary>
        /// 执行sql
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>int</returns>
        public static int ExecuteSql(string sql, object parameters)
        {
            return _dataAccess.ExecuteSql(sql, parameters);
        }
        /// <summary>
        /// 事物批量执行sql
        /// </summary>
        /// <param name="sqlList">sql语句集合</param>
        /// <returns>int</returns>
        public int ExecuteSql(List<string> sqlList)
        {
            return _dataAccess.ExecuteSql(sqlList);
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>int</returns>
        public static int GetInt(string sql, object parameters)
        {
            return _dataAccess.GetInt(sql, parameters);
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>string</returns>
        public static string GetString(string sql, object parameters)
        {
            return _dataAccess.GetString(sql, parameters);
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql">sql语句，示例："select * from table where id=@id"</param>
        /// <param name="pars">参数，示例：new { id = 1 }</param>
        /// <returns>decimal</returns>
        public static decimal GetDecimal(string sql, object parameters)
        {
            return _dataAccess.GetDecimal(sql, parameters);
        }
        #endregion
    }
}