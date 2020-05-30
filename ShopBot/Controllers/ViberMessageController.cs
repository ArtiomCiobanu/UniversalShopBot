using Microsoft.AspNetCore.Mvc;
using ShopBot.API_V2;
using ShopBot.API_V2.Models;
using ShopBot.API_V2.Telegram;
using ShopBot.API_V2.Viber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.Controllers
{
    public class ViberMessageController : BotController
    {
        static ViberBot telegramBot = null;
        public override IBot ControllerBot
        {
            get => telegramBot;
            set
            {
                telegramBot = (ViberBot)value;
            }
        }

        public override BotUpdate GetUpdate(JsonElement jsonElement)
        {
            throw new NotImplementedException();
        }
    }
}
