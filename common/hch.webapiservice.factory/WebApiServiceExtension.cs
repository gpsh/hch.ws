using hch.account.apis;
using hch.account.service;
using hch.car.apis;
using hch.car.service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace hch.webapiservice.factory
{
    public static class WebApiServiceExtension
    {
        public static void AddWebApiServices(this IServiceCollection services)
        {
            services.AddTransient<IQueryAccount, QueryAccountService>();
            services.AddTransient<IQueryCar, QueryCarService>();
            services.AddTransient<IWriteAccount, WriteAccountService>();
            services.AddTransient<IWriteCar, WriteCarService>();
        }
    }
}
