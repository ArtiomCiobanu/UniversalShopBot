using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps
{
    public abstract class Step : IStep
    {
        public abstract string CommandName { get; }
        public abstract string Message { get; }

        /// <summary>
        /// Actions invoked for keyboard callbacks
        /// </summary>
        public Dictionary<string, Func<BotUpdate, IBotClient, Task>> CallbackActions { get; }

        /// <summary>
        /// An action that is always invoked after callback actions and not depending on them
        /// </summary>
        public virtual Task MainAction(BotUpdate update, IBotClient client) => Task.Run(() => { });
        /// <summary>
        /// An action invoked if no action has been invoked for a keyboard callback
        /// </summary>
        public virtual Task DefaultAction(BotUpdate update, IBotClient client) => Task.Run(() => { });

        public async Task Execute(BotUpdate update, IBotClient client)
        {
            if (CallbackActions.Count > 0)
            {
                Func<BotUpdate, IBotClient, Task> action = null;

                if (update.Callback != null && update.Callback.SerializedData.CommandName == CommandName)
                {
                    action = CallbackActions.SingleOrDefault(a => !string.IsNullOrEmpty(a.Key) &&
                                            a.Key == update.Callback.SerializedData.Data).Value;
                    if (action != null)
                    {
                        await action.Invoke(update, client);
                    }
                }

                if (action == null)
                {
                    await DefaultAction(update, client);
                }
            }

            await MainAction(update, client);
        }

        public long ChatId { get; }
        public IStep NextStep { get; set; } = null;
        public IBotClient BotClient { get; }

        public async Task SendMessageAsync(string messageText, int replyToMessageId = 0, KeyboardMarkup keyboardMarkup = null)
        {
            await BotClient.SendTextMessageAsync(ChatId, messageText, replyToMessageId, keyboardMarkup);
        }
        public async Task EditMessageAsync(string messageText, int callbackMessageId, KeyboardMarkup keyboardMarkup = null)
        {
            await BotClient.EditTextMessageAsync(ChatId, callbackMessageId, messageText, keyboardMarkup);
        }

        public Step(long chatId, IBotClient client)
        {
            ChatId = chatId;
            BotClient = client;

            CallbackActions = new Dictionary<string, Func<BotUpdate, IBotClient, Task>>();
        }
    }
}
