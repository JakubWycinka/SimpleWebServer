using LiteDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SimpleWebServer.Consts;
using SimpleWebServer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Db.NOSQL
{
    public static class DatabaseInitializer
    {
        public static IWebHost CreateLiteDb(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<LiteDatabase>();

                if (!context.CollectionExists(LiteDbExtensions.MessagesCollection))
                {
                    var messagesCollection = context.SimpleMessages();

                    messagesCollection.Insert(new SimpleMessage { AuthorName = "Jakub", Message = "This is sample message from NOSQL LiteDb." });
                }
            }

            return host;
        }
    }
}
