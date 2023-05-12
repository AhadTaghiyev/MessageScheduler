using MessageScheduler.Service.Dtos;
using MessageScheduler.Service.Dtos.MessageDto;
using System;


namespace MessageScheduler.Service.Services.Interfaces
{
    public interface IMessageService
    {
        public Task CreateAsync(MessagePostDto postDto);
        public Task UpdateAsync(int id,MessagePostDto postDto);
        public Task DeleteAsync(int id);
        public Task<MessageGetDto> GetAsync(int id);
        public Task<IEnumerable<MessageGetDto>> GetAllAsync();
    }
}
