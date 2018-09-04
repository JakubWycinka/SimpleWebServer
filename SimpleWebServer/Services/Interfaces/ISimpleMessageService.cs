using SimpleWebServer.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Services.Interfaces
{
    public interface ISimpleMessageService
    {
        Task<SimpleMessageDto> Add(SimpleMessageDto simpleMessageDto);
        Task Delete(int id);
        Task<List<SimpleMessageDto>> GetAll();
        Task<SimpleMessageDto> Get(int id);
    }
}
