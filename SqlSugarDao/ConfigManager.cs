using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlSugarDao
{
    internal class ConfigManager
    {

        private string GetConfigPath()
        {
            //如果当前请求上下文为null 表示不是应用程序
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }

}
