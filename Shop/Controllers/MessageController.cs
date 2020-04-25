using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shop.API.Commands;
using Shop.API.Singletones;
using Telegram.Bot.Types;

namespace Shop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpGet]
        public string Test()
        {
            return "Yyyyyes";
        }
        [HttpGet]
        public OkObjectResult GetWebhookInfo()
        {
            var i = Bot.WebHookInfo;

            return Ok(i);
        }
        [HttpGet]
        public async Task<OkObjectResult> InitializeWebHook()
        {
            await Bot.SetWebhook();

            return Ok(Bot.WebHookInfo);
        }
        [HttpGet]
        public async Task<OkObjectResult> DeleteWebhook()
        {
            await Bot.DeleteWebhook();

            return Ok(Bot.WebHookInfo);
        }


        [HttpPost]
        public void Update([FromBody]JsonElement input)
        {
            Update update = JsonConvert.DeserializeObject<Update>(input.ToString());

            foreach (var c in Bot.Commands)
            {
                if (c.MustBeExecutedForUpdate(update))
                {
                    c.Execute(update, Bot.Client);
                    break;
                }
            }
        }
    }
}