using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBot.API_V2;
using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletons;
using ShopBot.API_V2.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ShopBot.Controllers
{

    [Route("TelegramBot/[action]")]
    [ApiController]
    public class TelegramMessageController : BotController
    {
        public override string BotName => "MainTelegramBot";

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
    }
}
