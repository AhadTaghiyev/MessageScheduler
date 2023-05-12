﻿

using AutoMapper;
using MessageScheduler.Core.Abstactions.Repositories.ReadRepositories;
using MessageScheduler.Core.Abstactions.Repositories.WriteRepositories;
using MessageScheduler.Core.Entities;
using MessageScheduler.Service.Dtos;
using MessageScheduler.Service.Dtos.MessageDto;
using MessageScheduler.Service.Exceptions;
using MessageScheduler.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MessageScheduler.Service.Services.Implementations
{
    internal class MessageService : IMessageService
    {
        private readonly IMessageReadRepository _read;
        private readonly IMessageWriteRepository _write;
        private readonly IMapper _mapper;
        private readonly ILogger<MessageService> _logger;

        public MessageService(IMessageReadRepository read, IMessageWriteRepository write, IMapper mapper, ILogger<MessageService> logger)
        {
            _read = read;
            _write = write;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateAsync(MessagePostDto postDto)
        {
            Message message=_mapper.Map<Message>(postDto);
            await _write.AddAsync(message);
            await _write.SaveAsync();
            _logger.Log(LogLevel.Information, $"{DateTime.UtcNow.AddHours(4)}-   message with id: {message.Id} Created : Create success");
        }

        public async Task DeleteAsync(int id)
        {
            Message message =await _read.GetAsync(x=>x.Id==id&&!x.IsDeleted,true);
            await ThrowIfNull(message, id);
            await _write.UpdateAsync(message);
            await _write.SaveAsync();
            _logger.Log(LogLevel.Information, $"message with id: {message.Id} Deleted");
        }

        public async Task<IEnumerable<MessageGetDto>> GetAllAsync()
        {
            IQueryable<Message> messagesQuery =await _read.GetAllAsync(x=>!x.IsDeleted);
            ListDto<MessageGetDto> Messages = new ListDto<MessageGetDto>();
            Messages.Items = messagesQuery.Select(x=> new MessageGetDto { Content=x.Content,Method=x.Method,SendAt=x.SendAt,To=x.To,Id=x.Id}).AsEnumerable();
            _logger.Log(LogLevel.Information, $"{DateTime.UtcNow.AddHours(4)}-   Successfully retrieved all data: GetAll success");
            return Messages.Items;
        }

        public async Task<MessageGetDto> GetAsync(int id)
        {
            Message message = await _read.GetAsync(x=>!x.IsDeleted&&x.Id==id,false);
            await ThrowIfNull(message,id);
            MessageGetDto messageGet=_mapper.Map<MessageGetDto>(message);
            _logger.Log(LogLevel.Information, $"{DateTime.UtcNow.AddHours(4)}-   Successfully retrieved message with id: {message.Id} : Get success");
            return messageGet;
        }

        public async Task UpdateAsync(int id, MessagePostDto postDto)
        {
            Message message = await _read.GetAsync(x => !x.IsDeleted&&x.Id==id, true);
           await ThrowIfNull(message,id);

            message.Method= postDto.Method;
            message.To=postDto.To;
            message.Content=postDto.Content;
            message.SendAt=postDto.SendAt;
            await _write.SaveAsync();
            _logger.Log(LogLevel.Information, $"{DateTime.UtcNow.AddHours(4)}-   Successfully updated message with id: {message.Id} : Update success");
        }

        public async Task ThrowIfNull(Message message,int id)
        {
            if (message == null)
            {
                _logger.LogError($"product with id: {id} not found");
                throw new ItemNotFoundException($"message with id: {id} not found");
            }
        }
    }
}