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
    public interface IBot
    {
        public string Name { get; }
        public string Token { get; }
        public JsonElement WebHookInfo { get; }
        public string WebHookUrl { get; }

        public IBotClient Client { get; }
        public List<IStep> StepPool { get; }
        public IReadOnlyList<ICommand> Commands { get; }

        public Task SetWebhook();
        public Task SetWebhook(string webhookUrl);
        public Task DeleteWebhook();

        public bool FindCommandAndExecute(Update updateMessage);
        public ICommand FindCommandByNameInMessage(string message);
        public void ExecuteCommandStepForUpdate(Update update);
    }
}
