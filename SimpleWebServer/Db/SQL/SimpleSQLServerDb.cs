using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using SimpleWebServer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Db.SQL
{
    public class SimpleSQLServerDb : DbContext
    {
        public SimpleSQLServerDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SimpleMessage> SimpleMessages { get; set; }
    }
}
