using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands
{
    public interface ICommand
    {
        public string Name { get; }

        public void ExecuteMainAction(BotUpdate update, IBotClient client);
        public void ExecuteForCallback(BotUpdate update, IBotClient client);
        public void ExecuteForMessage(BotUpdate update, IBotClient client);

        public bool MustBeExecutedForUpdateMessage(BotUpdate updateMessage);
        public bool ContainsCommandName(string messageText);
    }
}
