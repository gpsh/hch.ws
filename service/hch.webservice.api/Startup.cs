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
                Title= "Hch�ӿ�˵��",
                Developers=new string[] { "����˧"}

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
            #region ��ʼ�����ݿ�
            //�ɵĳ�ʼ�����ݷ�ʽ��ֱ��д�����ַ�������DataInitializer Build��ֱ��ʹ�ò���IWxDbContext context����WxDbFactory.GetDbContext("hch_dba")
            //var datarunner = new HchDataBuilder("hch_dba", Configuration.GetConnectionString("hch_dba"));
            //datarunner.CreateTables();
            //datarunner.BuildData();
            #endregion
        }

        public override void BuildDatabaseAndInitialize(string connectionname, string connectionstring)
        {
            //������BuildDbConnectionNames������д�����ַ������������DataInitializer Build��ֱ��ʹ��WxDbFactory.GetDbContext().MyDB
            var datarunner = new HchDataBuilder(connectionname, connectionstring);
            datarunner.CreateTables();
            datarunner.BuildData();
        }
    }
}
