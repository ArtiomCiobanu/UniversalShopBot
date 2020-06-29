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
        public abstract string Name { get; }

        //Убрать
        public abstract void ExecuteMainAction(BotUpdate update, IBotClient client);
        public virtual void ExecuteForCallback(BotUpdate update, IBotClient client) => ExecuteMainAction(update, client);
        public virtual void ExecuteForMessage(BotUpdate update, IBotClient client) => ExecuteMainAction(update, client);

        public virtual bool MustBeExecutedForUpdateMessage(BotUpdate updateMessage)
        {
            return (updateMessage.MessageText != null) ? ContainsCommandName(updateMessage.MessageText) : false;
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
