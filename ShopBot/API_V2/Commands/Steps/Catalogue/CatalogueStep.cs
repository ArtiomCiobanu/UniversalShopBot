namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public abstract class CatalogueStep : Step
    {
        public override string CommandName => "catalogue";

        public CatalogueStep(long chatId, IBotClient client) : base(chatId, client)
        {
        }
    }
}
