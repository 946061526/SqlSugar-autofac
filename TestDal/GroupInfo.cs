using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDal
{
    //[SugarTable("GroupInfo")]
    public class GroupInfo
    {
        /// <summary>
        /// 用户组编号
        /// </summary>
        //[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 用户组名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        //[SugarColumn(ColumnName = "Remark")]
        public string Remark { get; set; }
    }
}
