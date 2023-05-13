using MessageScheduler.Core.Entities;
using MessageScheduler.Service.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bots.Http;

namespace MessageScheduler.Service.Services.Implementations
{
    public class TelegramService : ISender
    {
        private readonly IConfiguration _configuration;
        private readonly TelegramBotClient _telegramBotClient;

        public TelegramService(IConfiguration configuration)
        {
            _configuration = configuration;
            _telegramBotClient = new TelegramBotClient(_configuration.GetSection("Keys")["TelegramKey"]);
        }

       public async Task Send(string to, string content)
        {
            var chatId = new ChatId(to);
            var result= await _telegramBotClient.SendTextMessageAsync(chatId, content);
        }
    }
}
