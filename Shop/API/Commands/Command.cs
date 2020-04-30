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
            return (update.Message != null) ? ContainsCommandName(update.Message) : false;
        }

        public bool ContainsCommandName(string messageText)
        {
            StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase;

            return messageText.Contains(Name, stringComparison);// && command.Contains(AppSettings.Name);
        }
        public bool ContainsCommandName(Message message)
        {
            if (message == null)
                return false;

            StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase;

            return message.Text.Split().First().Contains(Name, stringComparison);// && command.Contains(AppSettings.Name);
        }
    }
}
