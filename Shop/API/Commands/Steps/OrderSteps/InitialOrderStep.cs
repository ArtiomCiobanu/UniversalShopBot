using Shop.API.Commands.Steps.OrderSteps;
using Shop.API.Singletones;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps
{
    public class InitialOrderStep : OrderStep
    {
        public override string Message => "Отлично! Выберите категорию:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            NextStep = new SpecifyOrderProductsStep(ChatId, BotClient, Data);

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetCategoriesButtonRow(CommandName));

            await SendMessageAsync(Message, keyboard);
        }

        public InitialOrderStep(Message message, TelegramBotClient client) : base(message, client)
        {
        }
    }
}
