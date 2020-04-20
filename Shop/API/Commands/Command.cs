using Shop.API.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(Message message, TelegramBotClient client);
        public bool Contains(string command)
        {
            StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase;

            return command.Contains(Name, stringComparison);// && command.Contains(AppSettings.Name);
        }

    }
}
