using Shop.API.Commands;
using Shop.API.Commands.Steps;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API
{
    public class TelegramBot : Bot
    {
        /// <summary>
        /// Execute if begins with "/commandName"
        /// </summary>
        /// <param name="update"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public override bool FindCommandAndExecute(Update update)
        {
            var command = FindCommandNameInMessage(update.Message);
            if (command != null)
            {
                command.Execute(update, Client);
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void ExecuteCommandStepForUpdate(Update update)
        {
            foreach (var c in Commands)
            {
                if (c.MustBeExecutedForUpdate(update))
                {
                    c.Execute(update, Client);
                    break;
                }
            }
        }
        public override Command FindCommandNameInMessage(Message message)
        {
            if (message == null)
                return null;

            var firstWord = message.Text.Split().First();
            var foundCommand = Commands.SingleOrDefault(c => c.ContainsCommandName(firstWord));

            return foundCommand;
        }

        public TelegramBot(string token) : base(token)
        {

        }
        public TelegramBot(string token, List<Command> commands) : base(token, commands)
        {

        }
    }
}
