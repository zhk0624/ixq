﻿using System.Data.Entity;
using ixq.Demo.DbContext;
using Ixq.Core.Cache;
using Ixq.Core.DependencyInjection.Extensions;
using Ixq.Core.Logging;
using Ixq.Demo.Entities;
using Ixq.Demo.Web;
using Ixq.Logging.Log4Net;
using Ixq.Owin.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Ixq.Core.Security;
using Ixq.Demo.Domain;

[assembly: OwinStartup(typeof (Startup))]

namespace Ixq.Demo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 启用缓存
            ICacheProvider cacheProvider = new MemoryCacheProvider(); // new Redis.RedisCacheProvider();
            CacheManager.SetCacheProvider(cacheProvider);

            // 启用日志
            ILoggerFactory factory = new Log4NetLoggerFactory();
            LogManager.SetLoggerFactory(factory);

            app.Initialization()
                .RegisterAutoMappe()
                .RegisterIdentity(serverCollection =>
                {
                    serverCollection.TryAddSingleton<DbContext, DataContext>();
                    serverCollection.TryAddScoped<IUserStore<ApplicationUser>, Domain.UserStore<ApplicationUser>>();
                    serverCollection.TryAddScoped<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole>>();
                    serverCollection.TryAddScoped<IUserManager<Security.Identity.IUser>, ApplicationUserManager>();
                    ConfigureAuth(app);
                })
                .RegisterAutofac(typeof (MvcApplication));
        }
    }
}