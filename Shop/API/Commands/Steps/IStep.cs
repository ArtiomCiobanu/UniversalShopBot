using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps
{
    public interface IStep
    {
        long ChatId { get; }
        string Message { get; }
        IStep NextStep { get; }
        TelegramBotClient BotClient { get; }
        Task Execute(Update update, TelegramBotClient client);
        Task SendMessage(string message, InlineKeyboardMarkup replyMarkup = null);
        Task EditMessage(string message, InlineKeyboardMarkup replyMarkup = null);
    }
}
