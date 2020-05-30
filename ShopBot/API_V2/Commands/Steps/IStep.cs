using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps
{
    public interface IStep
    {
        string CommandName { get; }
        long ChatId { get; }
        string Message { get; }
        IStep NextStep { get; }
        IBotClient BotClient { get; }
        Task Execute(BotUpdate update, IBotClient client);
        //Task SendMessageAsync(string message, InlineKeyboardMarkup replyMarkup = null);
        //Task EditMessageAsync(stыring message, CallbackQuery callback, InlineKeyboardMarkup replyMarkup = null);
    }
}
