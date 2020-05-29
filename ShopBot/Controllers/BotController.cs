using Microsoft.AspNetCore.Mvc;
using ShopBot.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopBot.Controllers
{
    public abstract class BotController : ControllerBase
    {
        [HttpGet]
        public abstract string Test();
        [HttpGet]
        public abstract OkObjectResult GetWebhookInfo();
        [HttpGet]
        public abstract Task<OkObjectResult> InitializeWebHook();
        [HttpGet]
        public abstract Task<OkObjectResult> DeleteWebhook();

        [HttpPost]
        public abstract void Update([FromBody] JsonElement input);
    }
}
