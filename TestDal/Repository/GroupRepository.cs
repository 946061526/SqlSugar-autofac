using SqlSugarDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDal
{
    public class GroupRepository : IGroupRepository
    {
        public long Add(GroupInfo entity, bool ignorePk = true)
        {
            if (ignorePk)
                return DataAccessProxy.Add(entity, x => new { x.Id });
            else
                return DataAccessProxy.Add(entity);
        }

        public long Add(List<GroupInfo> entitys, bool ignorePk = true)
        {
            return DataAccessProxy.Add(entitys);
        }

        public int Delete(int[] primaryKeys, bool isLogic)
        {
            return DataAccessProxy.Delete<GroupInfo>(primaryKeys);
        }

        public int Delete(int primaryKey, bool isLogic)
        {
            return DataAccessProxy.Delete<GroupInfo>(primaryKey);
        }

        public int Edit(GroupInfo entity)
        {
            return DataAccessProxy.Edit(entity);
        }
        public int EditColumns(GroupInfo entity)
        {
            return DataAccessProxy.Edit(entity, it => new GroupInfo() { GroupName = entity.GroupName }, it => it.Id == entity.Id);
        }
        public GroupInfo Get(int id)
        {
            return DataAccessProxy.Get<GroupInfo>(id);
        }
        public int GetCount(string where, object parameters)
        {
            return DataAccessProxy.GetCount<GroupInfo>(where, parameters);
        }
        public List<GroupInfo> GetList(string where, object parameters, string orderBy)
        {
            return DataAccessProxy.GetList<GroupInfo>(where, parameters, orderBy);
        }
        public List<GroupInfo> GetList(string where, object parameters, int pageIndex, int pageSize, string orderBy, ref int total)
        {
            //db.Queryable<Student>().Where("name=@name", new { name = value }).ToList();
            return DataAccessProxy.GetListPage<GroupInfo>(where, parameters, orderBy, pageIndex, pageSize, ref total);
        }
        public List<GroupInfo> GetList(string sql, object obj)
        {
            return DataAccessProxy.SqlQuery<GroupInfo>(sql, obj) as List<GroupInfo>;
        }
    }
}
