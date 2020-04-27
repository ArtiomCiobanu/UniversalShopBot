using Shop.API.Models;
using Shop.API.Singletones;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class SpecifyOrderGoodsStep : OrderStep
    {
        public override string Message => "Теперь выберите товар:";

        public override async Task Execute(Update update, TelegramBotClient client)
        {
            var callback = update.CallbackQuery;
            var callbackMessage = callback.Message;
            var selectedItem = int.Parse(callback.Data) - 1;

            Data.Category = Catalogue.Categories.FirstOrDefault(x => x.Value == callback.Data).Key;
            NextStep = new SpecifyPhoneStep(ChatId, Data);

            var keyboard = new InlineKeyboardMarkup(ReplyKeyboardTools.GetProductsButtonRow(Data.Category));

            await client.EditMessageTextAsync(ChatId, callbackMessage.MessageId,
                $"Вы выбрали Категорию {callback.Data}\n{Message}", replyMarkup: keyboard);
        }
        public SpecifyOrderGoodsStep(long chatId, OrderData data) : base(chatId, data)
        {
        }
    }
}
