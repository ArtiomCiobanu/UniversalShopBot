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

        public void Execute(BotUpdate update, IBotClient client);
        public bool MustBeExecutedForUpdate(BotUpdate updateMessage);
        public bool ContainsCommandName(string messageText);
    }
}
