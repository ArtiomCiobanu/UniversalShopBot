using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.API_V2
{
    public interface IBotClient
    {
        Task DeleteWebhookAsync();
        Task SetWebhookAsync(string url);
        Task<string> GetWebhookInfoJsonAsync();

        Task SendTextMessageAsync(long chatId, string text);
    }
}
