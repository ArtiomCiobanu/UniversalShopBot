using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBot.API;
using ShopBot.API.Singletones;
using Telegram.Bot.Types;

namespace ShopBot.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public static TelegramBot ControllerBot { get; set; }

        [HttpGet]
        public string Test()
        {
            return "Yyyyyes";
        }
        [HttpGet]
        public OkObjectResult GetWebhookInfo()
        {
            var i = ControllerBot.WebHookInfo;

            return Ok(i);
        }
        [HttpGet]
        public async Task<OkObjectResult> InitializeWebHook()
        {
            await ControllerBot.SetWebhook();

            return Ok(ControllerBot.WebHookInfo);
        }
        [HttpGet]
        public async Task<OkObjectResult> DeleteWebhook()
        {
            await ControllerBot.DeleteWebhook();

            return Ok(ControllerBot.WebHookInfo);
        }

        [HttpPost]
        public void Update([FromBody] JsonElement input)
        {
            Update update = JsonConvert.DeserializeObject<Update>(input.ToString());

            if (!ControllerBot.FindCommandAndExecute(update))
            {
                ControllerBot.ExecuteCommandStepForUpdate(update);
            }
        }
    }
}