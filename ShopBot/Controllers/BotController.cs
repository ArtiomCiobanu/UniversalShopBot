using Microsoft.AspNetCore.Mvc;
using ShopBot.API_V2;
using ShopBot.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.Controllers
{
    public abstract class BotController : ControllerBase
    {
        public abstract IBot ControllerBot { get; set; }

        public abstract BotUpdate GetUpdate(JsonElement jsonElement);

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
            BotUpdate update = GetUpdate(input);

            if (!ControllerBot.FindCommandAndExecute(update))
            {
                ControllerBot.ExecuteCommandStepForUpdate(update);
            }
        }
    }
}
