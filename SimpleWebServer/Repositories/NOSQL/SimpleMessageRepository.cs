using LiteDB;
using SimpleWebServer.Db.NOSQL;
using SimpleWebServer.Exceptions;
using SimpleWebServer.Models.DbModels;
using SimpleWebServer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Repositories.NOSQL
{
    public class SimpleMessageRepository : ISimpleMessageRepository
    {
        private readonly LiteDatabase db;

        public SimpleMessageRepository(LiteDatabase db)
        {
            this.db = db;
        }

        public async Task<SimpleMessage> Add(SimpleMessage simpleMessage)
        {
            var result = db.SimpleMessages().Insert(simpleMessage);
            return simpleMessage;
        }

        public async Task Delete(int id)
        {
            bool deleteSucceded = db.SimpleMessages().Delete(new BsonValue(id));

            if (!deleteSucceded)
            {
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, $"Message with {id} doesn't exist.");
            }
        }

        public async Task<SimpleMessage> Get(int id)
        {
            var simpleMessage = db.SimpleMessages().FindById(new BsonValue(id));

            if(simpleMessage == null)
            {
                throw new HttpStatusCodeException(System.Net.HttpStatusCode.NotFound, $"Message with {simpleMessage.Id} doesn't exist.");
            }

            return simpleMessage;
        }

        public async Task<List<SimpleMessage>> GetAll()
        {
            return db.SimpleMessages().FindAll().ToList();
        }
    }
}
