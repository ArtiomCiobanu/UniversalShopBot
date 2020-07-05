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
            Message telegramMessage = null;
            if (telegramUpdate.Message != null)
            {
                telegramMessage = telegramUpdate.Message;

                botUpdate.Message.MessageId = telegramUpdate.Message.MessageId;

                botUpdate.Callback = null;
            }
            else
            {
                telegramMessage = telegramUpdate.CallbackQuery.Message;

                botUpdate.Callback.SetSerializedData(telegramUpdate.CallbackQuery.Data);
                botUpdate.Callback.MessageId = telegramUpdate.CallbackQuery.Message.MessageId;
            }

            botUpdate.Message.Text = telegramMessage.Text;
            botUpdate.ChatId = telegramMessage.Chat.Id;

            botUpdate.FirstName = telegramMessage.From.FirstName;
            botUpdate.LastName = telegramMessage.From.LastName;

            botUpdate.Date = telegramMessage.Date;
            botUpdate.EditDate = telegramMessage.EditDate;

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
