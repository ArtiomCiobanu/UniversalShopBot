using Shop.API.Commands;
using Shop.API.Commands.Steps;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Singletones
{
    public static class Bot
    {
        public static readonly TelegramBotClient Client = new TelegramBotClient(AppSettings.Token);

        public static List<IStep> StepPool { get; private set; } = new List<IStep>();

        static readonly List<Command> commandsList = new List<Command>
        {
            new HelloCommand(),
            new StartCommand(),
            new HelpCommand(),
            new OrderCommand(StepPool),
            new CatalogueCommand(StepPool),
        };
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static WebhookInfo WebHookInfo { get; private set; }

        public static async Task SetWebhook()
        {
            await Client.DeleteWebhookAsync();

            await Client.SetWebhookAsync(AppSettings.WebHookUrl);
            WebHookInfo = await Client.GetWebhookInfoAsync();
        }
        public static async Task DeleteWebhook()
        {
            await Client.DeleteWebhookAsync();
        }
        /// <summary>
        /// Execude if begins with "/commandName"
        /// </summary>
        /// <param name="update"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool FindCommandAndExecute(Update update)
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
        public static void ExecuteCommandStepForUpdate(Update update)
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
        public static Command FindCommandNameInMessage(Message message)
        {
            if (message == null)
                return null;

            var firstWord = message.Text.Split().First();
            var foundCommand = Commands.SingleOrDefault(c => c.ContainsCommandName(firstWord));

            return foundCommand;
        }
    }
}
