using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.API;
using Shop.API.Singletones;
using Telegram.Bot.Types;

namespace Shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IBot MainBot;

        [HttpGet]
        public string Test()
        {
            return "Yyyyyes";
        }
        [HttpGet]
        public OkObjectResult GetWebhookInfo()
        {
            var i = MainBot.WebHookInfo;

            return Ok(i);
        }
        [HttpGet]
        public async Task<OkObjectResult> InitializeWebHook()
        {
            await MainBot.SetWebhook();

            return Ok(MainBot.WebHookInfo);
        }
        [HttpGet]
        public async Task<OkObjectResult> DeleteWebhook()
        {
            await MainBot.DeleteWebhook();

            return Ok(MainBot.WebHookInfo);
        }

        [HttpPost]
        public void Update([FromBody]JsonElement input)
        {
            Update update = JsonConvert.DeserializeObject<Update>(input.ToString());

            if (!MainBot.FindCommandAndExecute(update))
            {
                MainBot.ExecuteCommandStepForUpdate(update);
            }
        }
    }
}