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
            Update update = JsonConvert.DeserializeObject<Update>(jsonElement.ToString());

            BotUpdate botUpdate = new BotUpdate();
            Message message = null;
            if (update.Message != null)
            {
                message = update.Message;
                botUpdate.MessageId = update.Message.MessageId;

                botUpdate.CallbackData = null;
                botUpdate.CallbackMessageId = 0;
            }
            else
            {
                message = update.CallbackQuery.Message;

                botUpdate.CallbackData = update.CallbackQuery.Data;
                botUpdate.CallbackMessageId = update.CallbackQuery.Message.MessageId;
            }

            botUpdate.MessageText = message.Text;
            botUpdate.ChatId = message.Chat.Id;

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
