using ShopBot.API_V2.Commands.Steps;
using ShopBot.API_V2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands
{
    public abstract class MultiStepCommand : Command
    {
        public List<IStep> StepPool { get; private set; }

        public abstract IStep GetInitialStep(BotUpdate update, IBotClient client);

        public override bool MustBeExecutedForUpdateMessage(BotUpdate updateMessage)
        {
            return StepPool.Any(s => s.ChatId == updateMessage.ChatId && s.CommandName == Name);
        }

        public override async void ExecuteMainAction(BotUpdate update, IBotClient client)
        {
            StepPool.Where(s => s.ChatId == update.ChatId && s.CommandName == Name)
                .ToList().ForEach(s => StepPool.Remove(s));

            var step = GetInitialStep(update, client);

            await ExecuteStep(step, update, client);
        }
        public override async void ExecuteForCallback(BotUpdate update, IBotClient client)
        {
            var step = StepPool.SingleOrDefault(s => s.ChatId == update.ChatId && s.CommandName == Name);
            await ExecuteStep(step, update, client);
        }

        public override async void ExecuteForMessage(BotUpdate update, IBotClient client)
        {
            var step = StepPool.SingleOrDefault(s => s.ChatId == update.ChatId && s.CommandName == Name);
            await ExecuteStep(step, update, client);
        }

        private async Task ExecuteStep(IStep step, BotUpdate update, IBotClient client)
        {
            if (StepPool.Contains(step))
            {
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
