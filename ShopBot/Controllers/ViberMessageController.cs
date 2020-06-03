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
        public override string BotName => "MainViberBot";

        public override BotUpdate GetUpdate(JsonElement jsonElement)
        {
            throw new NotImplementedException();
        }
    }
}
