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
        public override bool MustBeExecutedForMessage(Message message)
        {
            return Contains(message.Text.Split().First()) || AwaitedSteps.Any(step => step.ChatId == message.Chat.Id);
        }
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            var step = AwaitedSteps.SingleOrDefault(x => x.ChatId == chatId);

            if (step != null)
            {
                AwaitedSteps.Remove(step);
            }
            else
            {
                step = GetInitialStep(message);
            }

            await step.Execute(client);
            if (step.NextStep != null)
            {
                AwaitedSteps.Add(step.NextStep);
            }
        }
    }
}
