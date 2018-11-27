using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hch.account.apis;
using hch.account.service;
using hch.datainit;
using hch.global;
using hch.webapiservice.factory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wx;

namespace hch.webservice.api
{
    public class Startup: WxWebApiStartup
    {
        public Startup(IConfiguration configuration):base(configuration)
        {
           
        }
        public override string Name =>HchInfo.Name;
        public override string Code => HchInfo.Code;

        public override string[] BuildDbConnectionNames()
        {
            return new string[] { "hch_dba" };
        }
        public override WxDocumentInfo BuildWxDocumentInfo()
        {
            return new WxDocumentInfo {
                Version="V1.0.0",
                Title= "Hch接口说明",
                Developers=new string[] { "顾培帅"}

            };
        }
        public override void WxConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                   options.AddPolicy("any", builder => 
                          builder.AllowCredentials().AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("any"));
            });
            //services.AddScoped<IQueryAccount, QueryAccountService>();
            services.AddWebApiServices();

        }
        public override void WxConfigure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region 初始化数据库
            //旧的初始化数据方式，直接写连接字符串，在DataInitializer Build中直接使用参数IWxDbContext context或者WxDbFactory.GetDbContext("hch_dba")
            //var datarunner = new HchDataBuilder("hch_dba", Configuration.GetConnectionString("hch_dba"));
            //datarunner.CreateTables();
            //datarunner.BuildData();
            #endregion
        }

        public override void BuildDatabaseAndInitialize(string connectionname, string connectionstring)
        {
            //必须在BuildDbConnectionNames方法中写连接字符串，则可以在DataInitializer Build中直接使用WxDbFactory.GetDbContext().MyDB
            var datarunner = new HchDataBuilder(connectionname, connectionstring);
            datarunner.CreateTables();
            datarunner.BuildData();
        }
    }
}
