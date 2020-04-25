using Shop.API.Commands.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands
{
    public abstract class MultiStepCommand : Command
    {
        public List<IStep> AwaitedSteps = new List<IStep>();
        public abstract IStep GetInitialStep(Message chatId);
        public override bool MustBeExecutedForUpdate(Update update)
        {
            var message = update.Message;
            var callback = update.CallbackQuery;

            if (callback != null)
            {
                var id = callback.Message.Chat.Id;
            }

            return (callback != null && AwaitedSteps.Any(step => step.ChatId == callback.Message.Chat.Id)) ||
                Contains(message.Text.Split().First());
        }
        public override async void Execute(Update update, TelegramBotClient client)
        {
            var message = update.Message;
            var callback = update.CallbackQuery;

            IStep step = null;
            if (callback != null)
            {
                step = AwaitedSteps.SingleOrDefault(x => x.ChatId == callback.Message.Chat.Id);
                AwaitedSteps.Remove(step);
            }
            else if (message != null)
            {
                step = GetInitialStep(message);
            }

            await step.Execute(update, client);
            if (step.NextStep != null)
            {
                AwaitedSteps.Add(step.NextStep);
            }
        }
    }
}
