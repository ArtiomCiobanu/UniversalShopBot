using Shop.API.Commands.Steps.OrderSteps;
using Shop.API.Singletones;
using System.Collections.Generic;
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
            NextStep = new SpecifyOrderGoodsStep(ChatId, Data);

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetCategoriesButtonRow());

            await client.SendTextMessageAsync(ChatId, Message, replyMarkup: keyboard);
        }

        public InitialOrderStep(Message message) : base(message)
        {
        }
    }
}
