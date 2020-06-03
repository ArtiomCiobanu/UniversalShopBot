using ShopBot.API_V2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Viber
{
    public class ViberBot : Bot
    {
        protected override void InitializeBotClient(string token)
        {
            Client = new ViberClient(token);
        }

        public ViberBot(string token, string name) : base(token, name)
        {
        }
        public ViberBot(string token, string name, string webHookUrl) : base(token, name, webHookUrl)
        {
        }
        public ViberBot(string token, string name, List<ICommand> commands) : base(token, name, commands)
        {
        }
        public ViberBot(string token, string name, string webHookUrl, List<ICommand> commands) :
            base(token, name, webHookUrl, commands)
        {
        }
    }
}
