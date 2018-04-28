using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Utility
{
    public class IocContainer
    {
        private static IContainer _IContainer = null;
        /// <summary>
        /// IOC注入
        /// </summary>
        public static void Register()
        {
            //将配置添加到ConfigurationBuilder
            var config = new ConfigurationBuilder();
            config.AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AutofacConfig.json"));

            //用Autofac注册ConfigurationModule
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();            
            builder.RegisterModule(module);
            _IContainer = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _IContainer.Resolve<T>();
        }
    }
}
