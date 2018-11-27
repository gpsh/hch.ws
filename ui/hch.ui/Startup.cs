using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wx;

namespace hch.ui
{
    public class Startup : WxWebApiStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {

        }
        public override string Name => "HchWebUI·þÎñ";
        public override string Code => "Hch";
        public override string[] BuildDbConnectionNames()
        {
            return new string[] { "hch_dbs", "hch_dba" };
        }

        public override WxDocumentInfo BuildWxDocumentInfo()
        {
            return new WxDocumentInfo
            {
                Version = "V1.0.0",
                Title = "HchUI",
                Developers = new string[] { "¹ËÅàË§" }

            };
        }
        public override void WxConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            options.AddPolicy("any", builder => builder.AllowCredentials().AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("any"));
            });
        }
        public override void WxConfigure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
        }

        public override void BuildDatabaseAndInitialize(string connectionname, string connectionstring)
        {
            
        }
    }
}
