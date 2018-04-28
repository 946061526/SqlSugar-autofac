using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDal;
using Utility;

namespace SqlSugarDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            IocContainer.Register();
            //return;
            TestSugar();
        }


        private static void TestSugar()
        {
            var r = 0m;
            try
            {
                //add
                var group = new GroupInfo() { Id = 1, GroupName = "testsqlsugar", Remark = "test" };
                r = IocContainer.Resolve<IGroupRepository>().Add(group);

                //edit
                group = new GroupInfo() { Id = 24, GroupName = "testsqlsugar24", Remark = "test24" };
                r = IocContainer.Resolve<IGroupRepository>().Edit(group);

                var l = IocContainer.Resolve<IGroupRepository>().Get(24);

                var n = IocContainer.Resolve<IGroupRepository>().Delete(new int[] { 18, 19, 20, 21, 22, 23 }, false);

                int total = 0;
                var list = IocContainer.Resolve<IGroupRepository>().GetList("id>@id", new { id = 0 }, 1, 30, "id asc", ref total);
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
        }
    }




}
