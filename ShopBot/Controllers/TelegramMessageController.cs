using Microsoft.AspNetCore.Mvc;

namespace ShopBot.Controllers
{

    [Route("TelegramBot/[action]")]
    [ApiController]
    public class TelegramMessageController : BotController
    {
        public override string BotName => "MainTelegramBot";
    }
}
