using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps
{
    public interface IStep
    {
        long ChatId { get; }
        string Message { get; }
        IStep NextStep { get; }
        Task Execute(Update update, TelegramBotClient client);
    }
}
