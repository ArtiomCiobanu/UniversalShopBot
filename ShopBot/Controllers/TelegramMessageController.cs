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
    }
}
