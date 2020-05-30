using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBot.API_V2;
using ShopBot.API_V2.Models;
using ShopBot.API_V2.Telegram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ShopBot.Controllers
{
    public class TelegramMessageController : BotController
    {
        static TelegramBot telegramBot = null;
        public override IBot ControllerBot
        {
            get => telegramBot;
            set
            {
                telegramBot = (TelegramBot)value;
            }
        }

        public override BotUpdate GetUpdate(JsonElement jsonElement)
        {
            Update update = JsonConvert.DeserializeObject<Update>(jsonElement.ToString());

            BotUpdate botUpdate = new BotUpdate();
            Message message = null;
            if (update.Message != null)
            {
                message = update.Message;

                botUpdate.CallbackData = null;
            }
            else
            {
                message = update.CallbackQuery.Message;

                botUpdate.CallbackData = update.CallbackQuery.Data;
            }

            botUpdate.MessageText = message.Text;
            botUpdate.ChatId = message.Chat.Id;

            return botUpdate;
        }
    }
}
