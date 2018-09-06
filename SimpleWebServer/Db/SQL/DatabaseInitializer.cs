using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebServer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Db.SQL
{
    public static class DatabaseInitializer
    {
        public static IWebHost ApplyMigrationsOrCreateSQLDb(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<SimpleSQLServerDb>();

                var dbIsNewlyCreated = context.Database.EnsureCreated();

                if (dbIsNewlyCreated)
                {
                    context.SimpleMessages.Add(new SimpleMessage { AuthorName = "Jakub", Message = "This is sample message from SQL Server."});
                    context.SaveChanges();
                }
            }

            return host;
        }
    }
}
