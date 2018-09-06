using Microsoft.EntityFrameworkCore;
using SimpleWebServer.Db.SQL;
using SimpleWebServer.Exceptions;
using SimpleWebServer.Models.DbModels;
using SimpleWebServer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Repositories.SQL
{
    public class SimpleMessageRepository : ISimpleMessageRepository
    {
        private readonly SimpleSQLServerDb db;

        public SimpleMessageRepository(SimpleSQLServerDb db)
        {
            this.db = db;
        }

        public async Task<SimpleMessage> Add(SimpleMessage simpleMessage)
        {
            var simpleMessageFromDb = await db.SimpleMessages.AddAsync(simpleMessage);
            await db.SaveChangesAsync();

            return simpleMessageFromDb.Entity;
        }

        public async Task Delete(int id)
        {
            var simpleMessage = await Get(id);

            db.SimpleMessages.Remove(simpleMessage);
            await db.SaveChangesAsync();
        }

        public async Task<SimpleMessage> Get(int id)
        {
            var simpleMessage = await db.SimpleMessages.FindAsync(id);

            if (simpleMessage == null)
            {
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, $"Message with {simpleMessage.Id} doesn't exist.");
            }
            return simpleMessage;
        }

        public Task<List<SimpleMessage>> GetAll()
        {
            return db.SimpleMessages.AsNoTracking().ToListAsync();
        }
    }
}
