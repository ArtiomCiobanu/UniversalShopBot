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
        public List<IStep> StepPool = new List<IStep>();
        public abstract IStep GetInitialStep(Message chatId, TelegramBotClient client);
        public override bool MustBeExecutedForUpdate(Update update)
        {
            var message = update.Message;
            var callback = update.CallbackQuery;

            return ContainsCommandName(message) ||
                (callback != null && StepPool.Any(step => step.ChatId == callback.Message.Chat.Id)) ||
                (message != null && StepPool.Any(step => step.ChatId == message.Chat.Id));
        }

        public override async void Execute(Update update, TelegramBotClient client)
        {
            var message = update.Message;
            var callback = update.CallbackQuery;

            IStep step = null;
            if (ContainsCommandName(message))
            {
                var duplicate = StepPool.SingleOrDefault(s => s.ChatId == message.Chat.Id);
                if (duplicate != null)
                {
                    StepPool.Remove(duplicate);
                }

                step = GetInitialStep(message, client);
            }
            else if (callback != null && StepPool.Any(s => s.ChatId == callback.Message.Chat.Id))
            {
                step = StepPool.SingleOrDefault(s => s.ChatId == callback.Message.Chat.Id);
                StepPool.Remove(step);
            }
            else if (message != null && StepPool.Any(s => s.ChatId == message.Chat.Id))
            {
                step = StepPool.SingleOrDefault(s => s.ChatId == message.Chat.Id);
                StepPool.Remove(step);
            }

            await step.Execute(update, client);
            if (step.NextStep != null)
            {
                StepPool.Add(step.NextStep);
            }
        }
    }
}
