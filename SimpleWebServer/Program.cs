using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleWebServer.Db.NOSQL;
using SimpleWebServer.Db.SQL;

namespace SimpleWebServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var webHost = CreateWebHostBuilder(args).Build();

            string dataSource = config.GetValue<string>("DataSource:Source");

            if (dataSource.Equals(Consts.Consts.SQLServer, StringComparison.OrdinalIgnoreCase))
            {
                webHost.ApplyMigrationsOrCreateSQLDb();
            }
            else if (dataSource.Equals(Consts.Consts.LiteDb, StringComparison.OrdinalIgnoreCase))
            {
                webHost.CreateLiteDb();
            }  
            
            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((ctx, builder) =>
                {
                    builder.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                    builder.AddFile(o => o.RootPath = AppContext.BaseDirectory);
                })
                .UseStartup<Startup>();
    }
}
