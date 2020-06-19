using ShopBot.API_V2.Commands.Steps.Order;
using ShopBot.API_V2.Models;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Commands.Steps.Catalogue
{
    public class ReturnOrOrderStep : CatalogueStep
    {
        public override string Message => null;
        public string SelectedCategoryId { get; }
        public OrderData Data { get; private set; }

        private Task BackAction(BotUpdate update, IBotClient client)
        {
            return Task.Run(() =>
            {
                NextStep = new ShowCatalogueProductsStep(SelectedCategoryId, ChatId, client);
            });
        }
        private Task OrderAction(BotUpdate update, IBotClient client)
        {
            return Task.Run(() =>
            {
                Data.SetFullName(update.FullName);
                update.CallbackData = SelectedCategoryId;
                NextStep = new SpecifyPhoneStep(ChatId, client, Data);
            });
        }

        public override async Task MainAction(BotUpdate update, IBotClient client)
        {
            await NextStep.Execute(update, client);
            NextStep = NextStep.NextStep;
        }

        public override Task DefaultAction(BotUpdate update, IBotClient client) => null;

        public ReturnOrOrderStep(OrderData data, string categoryID, long chatId, IBotClient client) : base(chatId, client)
        {
            SelectedCategoryId = categoryID;
            Data = data;

            CallbackActions.Add("Back", BackAction);
            CallbackActions.Add("Order", OrderAction);
        }
    }
}
