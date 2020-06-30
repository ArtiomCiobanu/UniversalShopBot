using ShopBot.API_V2.Models;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public abstract class CatalogueStep : Step
    {
        public override string CommandName => "catalogue";
        public OrderData Data { get; protected set; }

        public CatalogueStep(long chatId, IBotClient client) : base(chatId, client)
        {
            Data = new OrderData();
        }
        public CatalogueStep(long chatId, IBotClient client, OrderData data) : base(chatId, client)
        {
            Data = data;
        }
    }
}
