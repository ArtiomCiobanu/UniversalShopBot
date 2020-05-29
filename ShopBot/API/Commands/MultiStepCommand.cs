using ShopBot.API.Commands.Steps;
using ShopBot.API.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShopBot.API.Commands
{
    public abstract class MultiStepCommand : Command
    {
        public List<IStep> StepPool { get; private set; }
        public abstract IStep GetInitialStep(Message chatId, TelegramBotClient client);
        public override bool MustBeExecutedForUpdate(Update update)
        {
            var message = update.Message;
            var callback = update.CallbackQuery;

            return ContainsCommandName(message) ||
                (message != null && StepPool.Any(s => s.ChatId == message.Chat.Id && s.CommandName == Name)) ||
                (callback != null && ContainsCommandName(callback.Data) &&
                    StepPool.Any(s => s.ChatId == callback.Message.Chat.Id && s.CommandName == Name));
        }

        public override async void Execute(Update update, TelegramBotClient client)
        {
            var message = update.Message;
            var callback = update.CallbackQuery;

            IStep step = null;
            if (ContainsCommandName(message))
            {
                StepPool.Where(s => s.ChatId == message.Chat.Id && s.CommandName == Name)
                    .ToList().ForEach(s => StepPool.Remove(s));

                step = GetInitialStep(message, client);
            }
            else if (callback != null && ContainsCommandName(callback.Data) &&
                        StepPool.Any(s => s.ChatId == callback.Message.Chat.Id && s.CommandName == Name))
            {
                callback.Data = callback.Data.Remove(0, Name.Length + 1);

                step = StepPool.SingleOrDefault(s => s.ChatId == callback.Message.Chat.Id && s.CommandName == Name);
                StepPool.Remove(step);
            }
            else if (message != null && StepPool.Any(s => s.ChatId == message.Chat.Id && s.CommandName == Name))
            {
                step = StepPool.SingleOrDefault(s => s.ChatId == message.Chat.Id && s.CommandName == Name);
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
                await client.SendTextMessageAsync(update.Message.Chat.Id, "Что-то пошло не так! Попробуйте ещё раз.");
            }
        }

        public MultiStepCommand(List<IStep> stepPool)
        {
            StepPool = stepPool;
        }
    }
}
