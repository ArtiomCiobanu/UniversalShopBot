using Shop.API.Commands;
using Shop.API.Commands.Steps;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API
{
    public class TelegramBot : IBot
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public WebhookInfo WebHookInfo { get; private set; }
        public string WebHookUrl { get; set; }


        public TelegramBotClient Client { get; }
        public List<IStep> StepPool { get; }
        public IReadOnlyList<Command> Commands { get; }

        public async Task SetWebhook()
        {
            await Client.DeleteWebhookAsync();

            await Client.SetWebhookAsync(WebHookUrl);
            WebHookInfo = await Client.GetWebhookInfoAsync();
        }
        public async Task SetWebhook(string webhookUrl)
        {
            WebHookUrl = @webhookUrl;

            await SetWebhook();
        }

        public async Task DeleteWebhook()
        {
            await Client.DeleteWebhookAsync();
        }
        /// <summary>
        /// Execude if begins with "/commandName"
        /// </summary>
        /// <param name="update"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool FindCommandAndExecute(Update update)
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
        public void ExecuteCommandStepForUpdate(Update update)
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
        public Command FindCommandNameInMessage(Message message)
        {
            if (message == null)
                return null;

            var firstWord = message.Text.Split().First();
            var foundCommand = Commands.SingleOrDefault(c => c.ContainsCommandName(firstWord));

            return foundCommand;
        }

        public TelegramBot(string token)
        {
            StepPool = new List<IStep>();

            Token = token;

            var commands = new List<Command>
            {
                new HelloCommand(),
                new StartCommand(),
                new HelpCommand(),
                new OrderCommand(StepPool),
                new CatalogueCommand(StepPool),
            };
            Commands = commands.AsReadOnly();

            Client = new TelegramBotClient(Token);
        }
        public TelegramBot(string token, List<Command> commands)
        {
            StepPool = new List<IStep>();

            Token = token;

            Client = new TelegramBotClient(Token);
            Commands = commands.AsReadOnly();
        }
    }
}
