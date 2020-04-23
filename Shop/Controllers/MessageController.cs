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

        [HttpPost]
        public OkResult Update([FromBody]JsonElement input)
        {
            Update update = JsonConvert.DeserializeObject<Update>(input.ToString());

            var commands = Bot.Commands;
            var message = update.Message;
            var client = Bot.Client;

            foreach (var c in commands)
            {
                if (c.MustBeExecutedForMessage(message))
                {
                    c.Execute(message, client);
                    break;
                }
            }

            return Ok();
        }
    }
}