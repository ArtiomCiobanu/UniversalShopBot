using ShopBot.API.Commands;
using ShopBot.API.Commands.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API
{
    public abstract class Bot : IBot
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public WebhookInfo WebHookInfo { get; set; }
        public string WebHookUrl { get; set; }
        public TelegramBotClient Client { get; set; }
        public List<IStep> StepPool { get; set; }
        public IReadOnlyList<Command> Commands { get; set; }

        public abstract void ExecuteCommandStepForUpdate(Update update);
        public abstract bool FindCommandAndExecute(Update update);
        public abstract Command FindCommandNameInMessage(Message message);

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


        public Bot(string token)
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
        public Bot(string token, List<Command> commands)
        {
            StepPool = new List<IStep>();

            Token = token;

            Client = new TelegramBotClient(Token);
            Commands = commands.AsReadOnly();
        }
    }
}
