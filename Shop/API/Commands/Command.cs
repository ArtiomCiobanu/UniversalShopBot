using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(Update update, TelegramBotClient client);
        public virtual bool MustBeExecutedForUpdate(Update update)
        {
            return (update.Message != null) ? Contains(update.Message.Text.Split().First()) : false;
        }

        public bool Contains(string command)
        {
            StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase;

            return command.Contains(Name, stringComparison);// && command.Contains(AppSettings.Name);
        }
    }
}
