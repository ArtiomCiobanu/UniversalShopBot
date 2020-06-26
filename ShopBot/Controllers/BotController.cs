using Microsoft.AspNetCore.Mvc;
using ShopBot.API_V2;
using ShopBot.API_V2.Models;
using ShopBot.API_V2.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.Controllers
{
    public abstract class BotController : ControllerBase
    {
        public abstract string BotName { get; }
        public IBot ControllerBot => BotFactory.BotDictionary[BotName];

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
            BotUpdate update = ControllerBot.GetUpdate(input);

            if (!ControllerBot.FindCommandAndExecute(update))
            {
                ControllerBot.ExecuteCommandStepForUpdate(update);
            }
        }
    }
}
