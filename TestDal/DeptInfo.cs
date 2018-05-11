using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDal
{
    /// <summary>
    /// 部门信息
    /// </summary>
    public class DeptInfo
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
