using ShopBot.API_V2.Commands.Steps.Order;
using ShopBot.API_V2.Models;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public class ReturnOrOrderCatalogueStep : CatalogueStep
    {
        public override string Message => null;

        private Task BackAction(BotUpdate update, IBotClient client)
        {
            return Task.Run(() =>
            {
                NextStep = new ShowCatalogueProductsStep(ChatId, client, Data);
            });
        }
        private Task OrderAction(BotUpdate update, IBotClient client)
        {
            return Task.Run(() =>
            {
                //Data.SetFullName(update.FullName);
                //update.CallbackData = $"{CommandName} {Data.CategoryId}";
                NextStep = new SpecifyPhoneStep(ChatId, client, Data);
            });
        }

        public override async Task MainAction(BotUpdate update, IBotClient client)
        {
            await NextStep.Execute(update, client);
            NextStep = NextStep.NextStep;
        }

        public override Task DefaultAction(BotUpdate update, IBotClient client) => null;

        public ReturnOrOrderCatalogueStep(OrderData data, long chatId, IBotClient client) : base(chatId, client)
        {
            Data = data;

            CallbackActions.Add("Back", BackAction);
            CallbackActions.Add("Order", OrderAction);
        }
    }
}
