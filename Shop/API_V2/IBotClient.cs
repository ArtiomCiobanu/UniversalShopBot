using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.API_V2
{
    public interface IBotClient
    {
        Task DeleteWebhookAsync();
        Task SetWebhookAsync(string url);
        Task<JsonElement> GetWebhookInfoAsync();
    }
}
