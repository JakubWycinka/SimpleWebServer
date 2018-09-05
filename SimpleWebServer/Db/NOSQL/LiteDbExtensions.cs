using LiteDB;
using SimpleWebServer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Db.NOSQL
{
    public static class LiteDbExtensions
    {
        public const string MessagesCollection = "SimpleMessages";

        public static LiteCollection<SimpleMessage> SimpleMessages(this LiteDatabase liteDb)
        {
            return liteDb.GetCollection<SimpleMessage>(LiteDbExtensions.MessagesCollection);
        }
    }
}
