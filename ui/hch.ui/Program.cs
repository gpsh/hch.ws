using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace hch.ui
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Hch.Web.Ui";
            Console.WriteLine("服务站点正在启动……");
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            foreach (var fileinfo in new DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles("*settings.json", SearchOption.AllDirectories))
            {
                config = config.AddJsonFile(fileinfo.Name, optional: true, reloadOnChange: true);
                Console.WriteLine("发现配置文件:" + fileinfo.FullName);
            }

            BuildWebHost(args, config.Build()).Run();
        }

        public static IWebHost BuildWebHost(string[] args, IConfiguration config) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
    }
}
