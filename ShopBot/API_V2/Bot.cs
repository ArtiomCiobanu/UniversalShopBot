using ShopBot.API_V2.Commands;
using ShopBot.API_V2.Commands.Steps;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.API_V2
{
    public abstract class Bot : IBot
    {
        public string Name { get; }
        public string Token { get; private set; }
        public string WebHookInfo { get; private set; }
        public string WebHookUrl { get; private set; }
        public IBotClient Client { get; protected set; }
        public List<IStep> StepPool { get; private set; }
        public IReadOnlyList<ICommand> Commands { get; private set; }
        public List<long> ProcessedChats { get; set; }

        public void SetCommands(List<ICommand> commands)
        {
            Commands = commands.AsReadOnly();
        }

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

        public abstract BotUpdate GetUpdate(JsonElement jsonElement);

        public void FindCommandAndExecute(BotUpdate update)
        {
            var command = Commands.SingleOrDefault(c => c.ContainsCommandName(update.Message.Text));

            if (command != null)
            {
                command.ExecuteMainAction(update, Client);
            }
            else if (update.Callback != null && !string.IsNullOrEmpty(update.Callback.SerializedData.Data))
            {
                var commandForCallback = Commands.SingleOrDefault(c =>
                c.ContainsCommandName(update.Callback.SerializedData.CommandName));

                if (commandForCallback != null)
                {
                    commandForCallback.ExecuteForCallback(update, Client);
                }
            }
            else if (!string.IsNullOrEmpty(update.Message.Text))
            {
                var commandForMessage = Commands.SingleOrDefault(c => c.MustBeExecutedForUpdateMessage(update));

                if (commandForMessage != null)
                {
                    commandForMessage.ExecuteForMessage(update, Client);
                }
            }
        }
        /// <summary>
        /// Returns the command with the command name in the specified string.
        /// Returns null if the string doesn't contain any command name
        /// </summary>
        /// <param name="messageText"></param>
        /// <returns></returns>
        public ICommand FindCommandByNameInMessage(string messageText)
        {
            if (string.IsNullOrEmpty(messageText))
            {
                return null;
            }

            var firstWord = messageText.Split().First();
            var foundCommand = Commands.SingleOrDefault(c => c.ContainsCommandName(firstWord));

            return foundCommand;
        }

        protected abstract void InitializeBotClient(string token);

        /// <summary>
        /// Initializes the Bot with the specified token
        /// </summary>
        /// <param name="token"></param>
        public Bot(string token, string name)
        {
            Name = name;
            Token = token;

            StepPool = new List<IStep>();
            ProcessedChats = new List<long>();

            InitializeBotClient(token);
        }
        /// <summary>
        /// Initializes the Bot with the specified token and sets the webhook
        /// </summary>
        /// <param name="token"></param>
        /// <param name="webHookUrl"></param>
        public Bot(string token, string name, string webHookUrl)
        {
            Name = name;
            Token = token;

            StepPool = new List<IStep>();
            ProcessedChats = new List<long>();

            InitializeBotClient(token);

            WebHookUrl = webHookUrl;
            SetWebhook().Wait();
        }
    }
}
