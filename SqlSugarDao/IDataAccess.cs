using System;
using System.Collections.Generic;
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
        /// <param name="parameters">条件参数，如new SugarParameter("@id",1)</param>
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

    }
}
