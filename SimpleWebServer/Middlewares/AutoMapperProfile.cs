using AutoMapper;
using SimpleWebServer.Models.DbModels;
using SimpleWebServer.Models.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebServer.Middlewares
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SimpleMessage, SimpleMessageDto>().ReverseMap();
        }
    }
}
