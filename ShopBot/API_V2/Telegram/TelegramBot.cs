using ShopBot.API_V2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Telegram
{
    public class TelegramBot : Bot
    {
        protected override void InitializeBotClient(string token)
        {
            Client = new TelegramClient(token);
        }

        public TelegramBot(string token) : base(token)
        {
        }
        public TelegramBot(string token, List<ICommand> commands) : base(token, commands)
        {

        }
    }
}
