using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDal
{
    [SugarTable("UserInfo")]
    public class UserInfo
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string CnName { get; set; }
        /// <summary>
        /// 英文名/登录名
        /// </summary>
        public string EnName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 状态(1.正常 2.禁用 3.删除)
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 所属部门编号
        /// </summary>
        public int DeptID { get; set; }
        /// <summary>
        /// 所属组编号
        /// </summary>
        public int GroupID { get; set; }
    }

    public class UserView {
        public int Id { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string CnName { get; set; }
        /// <summary>
        /// 用户组名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }
    }
}
