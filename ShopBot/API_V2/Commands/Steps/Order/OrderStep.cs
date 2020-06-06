using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Order
{
    public abstract class OrderStep : Step
    {
        public override string CommandName => "order";

        public OrderData Data { get; }

        public OrderStep(BotUpdate update, IBotClient client) : base(update, client)
        {
            Data = new OrderData(update.FullName);
        }
        public OrderStep(BotUpdate update, IBotClient client, OrderData data) : base(update, client)
        {
            Data = data;
        }
        public OrderStep(long chatId, string fullName, IBotClient client) : base(chatId, client)
        {
            Data = new OrderData(fullName);
        }
        public OrderStep(long chatId, IBotClient client, OrderData data) : base(chatId, client)
        {
            Data = data;
        }
    }
}
