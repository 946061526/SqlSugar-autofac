﻿using System;
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


            //IocContainer.Register();
            IocContainer.Configure();
            //return;
            TestSugar();
        }


        private static void TestSugar()
        {
            var r = 0m;
            try
            {
                ////add
                //var group = new GroupInfo() { GroupName = "testsqlsugar", Remark = "test" };
                //r = IocContainer.Resolve<IGroupRepository>().Add(group);

                ////edit
                //var group1 = new GroupInfo() { Id = 25, GroupName = "group25", Remark = "test25" };
                ////r = IocContainer.Resolve<IGroupRepository>().Edit(group1);
                //r = IocContainer.Resolve<IGroupRepository>().EditColumns(group1);

                ////get by id
                //var l = IocContainer.Resolve<IGroupRepository>().Get(25);

                ////delete
                ////var n = IocContainer.Resolve<IGroupRepository>().Delete(new int[] { 18, 19, 20, 21, 22, 23 }, false);

                ////page
                //int total = 0;
                //var list = IocContainer.Resolve<IGroupRepository>().GetList("id>@id", new { id = 10 }, 1, 30, "id asc", ref total);

                ////by sql
                //var sql = "select * from groupinfo where id>@id ";
                //var dic = new Dictionary<string, object>();
                //dic.Add("id", 0);
                //list = IocContainer.Resolve<IGroupRepository>().GetList(sql, dic);

                ////by sql
                //var sql1 = "select * from groupinfo where id>@id and groupname = @name";
                //var list1 = IocContainer.Resolve<IGroupRepository>().GetList(sql1, new { id = 0, name = "testsqlsugar25" });

                ////count
                //var count = IocContainer.Resolve<IGroupRepository>().GetCount("id>@id", new { id = 0 });

                //join
                var uv = IocContainer.Resolve<IGroupRepository>().GetList();
                var uv2 = IocContainer.Resolve<IGroupRepository>().GetList2();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
        }
    }




}
