using ShopBot.API_V2.Commands;
using ShopBot.API_V2.Commands.Steps;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.API_V2
{
    public abstract class Bot : IBot
    {
        public string Name { get; private set; }
        public string Token { get; private set; }
        public string WebHookInfo { get; private set; }
        public string WebHookUrl { get; private set; }
        public IBotClient Client { get; protected set; }
        public List<IStep> StepPool { get; private set; }
        public IReadOnlyList<ICommand> Commands { get; private set; }

        public async Task SetWebhook()
        {
            await Client.DeleteWebhookAsync();

            await Client.SetWebhookAsync(WebHookUrl);
            WebHookInfo = await Client.GetWebhookInfoJsonAsync(); ;
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

        public void ExecuteCommandStepForUpdate(BotUpdate update)
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
        public bool FindCommandAndExecute(BotUpdate update)
        {
            var command = FindCommandByNameInMessage(update.MessageText);
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
        public ICommand FindCommandByNameInMessage(string messageText)
        {
            if (!string.IsNullOrEmpty(messageText))
            {
                return null;
            }

            var firstWord = messageText.Split().First();
            var foundCommand = Commands.SingleOrDefault(c => c.ContainsCommandName(firstWord));

            return foundCommand;
        }

        protected abstract void InitializeBotClient(string token);

        public Bot(string token)
        {
            StepPool = new List<IStep>();
            Token = token;

            var commands = new List<Command>
            {
                /*new HelloCommand(),
                new StartCommand(),
                new HelpCommand(),
                new OrderCommand(StepPool),
                new CatalogueCommand(StepPool),*/
            };
            Commands = commands.AsReadOnly();

            InitializeBotClient(token);
            //Client = new TelegramBotClient(Token);
        }
        public Bot(string token, List<ICommand> commands)
        {
            StepPool = new List<IStep>();
            Token = token;
            Commands = commands.AsReadOnly();

            InitializeBotClient(token);
            //Client = new TelegramBotClient(Token);
        }
    }
}
