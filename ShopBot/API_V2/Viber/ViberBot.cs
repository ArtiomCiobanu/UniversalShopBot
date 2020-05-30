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

        public ViberBot(string token) : base(token)
        {
        }
        public ViberBot(string token, List<ICommand> commands) : base(token, commands)
        {

        }
    }
}
