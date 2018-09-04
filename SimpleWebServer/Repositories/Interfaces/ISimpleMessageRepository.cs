using SimpleWebServer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Repositories.Interfaces
{
    public interface ISimpleMessageRepository
    {
        Task<SimpleMessage> Add(SimpleMessage simpleMessage);
        Task<SimpleMessage> Get(int id);
        Task<List<SimpleMessage>> GetAll();
        Task Delete(int id);
    }
}
