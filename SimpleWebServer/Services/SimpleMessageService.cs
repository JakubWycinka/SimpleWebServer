using AutoMapper;
using SimpleWebServer.Models.DbModels;
using SimpleWebServer.Models.DtoModels;
using SimpleWebServer.Repositories.Interfaces;
using SimpleWebServer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Services
{
    public class SimpleMessageService : ISimpleMessageService
    {
        private readonly ISimpleMessageRepository simpleMessageRepository;
        private readonly IMapper mapper;

        public SimpleMessageService(ISimpleMessageRepository simpleMessageRepository, IMapper mapper)
        {
            this.simpleMessageRepository = simpleMessageRepository;
            this.mapper = mapper;
        }

        public async Task<SimpleMessageDto> Add(SimpleMessageDto simpleMessageDto)
        {
            var simpleMessage = mapper.Map<SimpleMessageDto, SimpleMessage>(simpleMessageDto);

            var simpleMessageFromDb = await simpleMessageRepository.Add(simpleMessage);

            return mapper.Map<SimpleMessage, SimpleMessageDto>(simpleMessageFromDb);
        }

        public async Task Delete(int id)
        {
            await simpleMessageRepository.Delete(id);
        }

        public async Task<SimpleMessageDto> Get(int id)
        {
            var simpleMessage = await simpleMessageRepository.Get(id);

            return mapper.Map<SimpleMessage, SimpleMessageDto>(simpleMessage);
        }

        public async Task<List<SimpleMessageDto>> GetAll()
        {
            var allMessages = await simpleMessageRepository.GetAll();

            return allMessages.Select(mapper.Map<SimpleMessage, SimpleMessageDto>).ToList();
        }
    }
}
