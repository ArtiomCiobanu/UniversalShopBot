using Shop.API.Commands;
using Shop.API.Commands.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API
{
    public interface IBot
    {
        public string Name { get; }
        public string Token { get; }
        public WebhookInfo WebHookInfo { get; }
        public string WebHookUrl { get; }

        public TelegramBotClient Client { get; }
        public List<IStep> StepPool { get; }
        public IReadOnlyList<Command> Commands { get; }

        public Task SetWebhook();
        public Task SetWebhook(string webhookUrl);
        public Task DeleteWebhook();

        public bool FindCommandAndExecute(Update update);
        public void ExecuteCommandStepForUpdate(Update update);
        public Command FindCommandNameInMessage(Message message);
    }
}
