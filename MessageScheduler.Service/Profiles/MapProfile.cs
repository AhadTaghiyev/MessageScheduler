using AutoMapper;
using MessageScheduler.Core.Entities;
using MessageScheduler.Service.Dtos.MessageDto;


namespace MessageScheduler.Service.Profiles
{

    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MessagePostDto, Message>();
            CreateMap<Message, MessageGetDto>();
        }
    }
}
