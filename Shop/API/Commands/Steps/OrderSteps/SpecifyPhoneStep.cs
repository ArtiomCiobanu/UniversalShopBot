using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shop.API.Commands.Steps.OrderSteps
{
    public class SpecifyPhoneStep : IOrderStep
    {
        public OrderData Data => throw new NotImplementedException();

        public long ChatId => throw new NotImplementedException();

        public string Message => throw new NotImplementedException();

        public IStep NextStep => throw new NotImplementedException();

        public Task Execute(Update update, TelegramBotClient client)
        {


            throw new NotImplementedException();
        }
    }
}
