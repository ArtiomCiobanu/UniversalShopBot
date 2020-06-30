using Newtonsoft.Json;
using ShopBot.API_V2.Models;
using System.Text.Json;
using Telegram.Bot.Types;

namespace ShopBot.API_V2.Telegram
{
    public class TelegramBot : Bot
    {
        protected override void InitializeBotClient(string token)
        {
            Client = new TelegramClient(token);
        }

        public override BotUpdate GetUpdate(JsonElement jsonElement)
        {
            Update telegramUpdate = JsonConvert.DeserializeObject<Update>(jsonElement.ToString());

            BotUpdate botUpdate = new BotUpdate();
            Message message = null;
            if (telegramUpdate.Message != null)
            {
                message = telegramUpdate.Message;
                botUpdate.MessageId = telegramUpdate.Message.MessageId;

                botUpdate.CallbackData = null;
                botUpdate.CallbackMessageId = 0;
            }
            else
            {
                message = telegramUpdate.CallbackQuery.Message;

                botUpdate.CallbackData = telegramUpdate.CallbackQuery.Data;
                botUpdate.CallbackMessageId = telegramUpdate.CallbackQuery.Message.MessageId;
            }

            botUpdate.MessageText = message.Text;
            botUpdate.ChatId = message.Chat.Id;

            botUpdate.FirstName = message.From.FirstName;
            botUpdate.LastName = message.From.LastName;

            botUpdate.Date = message.Date;
            botUpdate.EditDate = message.EditDate;

            return botUpdate;
        }

        public TelegramBot(string token, string name) : base(token, name)
        {
        }
        public TelegramBot(string token, string name, string webHookUrl) : base(token, name, webHookUrl)
        {

        }
    }
}
