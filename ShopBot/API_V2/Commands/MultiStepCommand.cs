using ShopBot.API_V2.Commands.Steps;
using ShopBot.API_V2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopBot.API_V2.Commands
{
    public abstract class MultiStepCommand : Command
    {
        public List<IStep> StepPool { get; private set; }

        public abstract IStep GetInitialStep(BotUpdate update, IBotClient client);

        public override bool MustBeExecutedForUpdate(BotUpdate update)
        {
            var message = update.MessageText;
            var callbackData = update.CallbackData;

            return ContainsCommandName(message) ||
                (!string.IsNullOrEmpty(message) && StepPool.Any(s => s.ChatId == update.ChatId && s.CommandName == Name)) ||
                (!string.IsNullOrEmpty(callbackData) && ContainsCommandName(callbackData) &&
                    StepPool.Any(s => s.ChatId == update.ChatId && s.CommandName == Name));
        }

        public override async void Execute(BotUpdate update, IBotClient client)
        {
            var message = update.MessageText;
            var callbackData = update.CallbackData;

            IStep step = null;
            if (ContainsCommandName(message))
            {
                StepPool.Where(s => s.ChatId == update.ChatId && s.CommandName == Name)
                    .ToList().ForEach(s => StepPool.Remove(s));
                //StepPool.Where(s => s.ChatId == update.ChatId).ToList().ForEach(s => StepPool.Remove(s));

                step = GetInitialStep(update, client);
            }
            else if (!string.IsNullOrEmpty(callbackData) && ContainsCommandName(callbackData) &&
                        StepPool.Any(s => s.ChatId == update.ChatId && s.CommandName == Name))
            {
                step = StepPool.SingleOrDefault(s => s.ChatId == update.ChatId && s.CommandName == Name);
                StepPool.Remove(step);
            }
            else if (!string.IsNullOrEmpty(message) && StepPool.Any(s => s.ChatId == update.ChatId && s.CommandName == Name))
            {
                step = StepPool.SingleOrDefault(s => s.ChatId == update.ChatId && s.CommandName == Name);
                StepPool.Remove(step);
            }

            try
            {
                await step.Execute(update, client);
                if (step.NextStep != null)
                {
                    StepPool.Add(step.NextStep);
                }
            }
            catch
            {
                await client.SendTextMessageAsync(update.ChatId, "Что-то пошло не так! Попробуйте ещё раз.");
            }
        }

        public MultiStepCommand(List<IStep> stepPool)
        {
            StepPool = stepPool;
        }
    }
}
