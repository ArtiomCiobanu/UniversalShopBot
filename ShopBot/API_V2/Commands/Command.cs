using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands
{
    public abstract class Command : ICommand
    {
        public string Name { get; }

        public abstract void Execute(Update update, IBotClient client);
        public virtual bool MustBeExecutedForUpdate(Update update)
        {
            return (update.MessageText != null) ? ContainsCommandName(update.MessageText) : false;
        }

        public bool ContainsCommandName(string messageText)
        {
            if (string.IsNullOrEmpty(messageText))
            {
                return false;
            }

            StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase;

            return messageText.Split().First().Contains(Name, stringComparison);// && command.Contains(AppSettings.Name);
        }
    }
}
