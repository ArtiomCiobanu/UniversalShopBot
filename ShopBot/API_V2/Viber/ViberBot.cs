using ShopBot.API_V2.Commands;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Viber
{
    public class ViberBot : Bot
    {
        protected override void InitializeBotClient(string token)
        {
            Client = new ViberClient(token);
        }

        public override BotUpdate GetUpdate(JsonElement jsonElement)
        {
            throw new NotImplementedException();
        }

        public ViberBot(string token, string name) : base(token, name)
        {
        }
        public ViberBot(string token, string name, string webHookUrl) : base(token, name, webHookUrl)
        {
        }
    }
}
