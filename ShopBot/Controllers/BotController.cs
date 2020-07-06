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
        public OkResult Update([FromBody] JsonElement input)
        {
            Task.Run(() =>
            {
                BotUpdate update = ControllerBot.GetUpdate(input);

                if (ControllerBot.ProcessedChats.Contains(update.ChatId))
                {
                    return;
                }


                DateTime? date = null;

                if (update.EditDate != null)
                {
                    date = update.EditDate;
                }
                else
                {
                    date = update.Date;
                }

                var dateDifference = DateTime.Now - (DateTime)date;
                int minutes = dateDifference.Minutes;
                if (minutes <= 1)
                {
                    ControllerBot.ProcessedChats.Add(update.ChatId);
                    ControllerBot.FindCommandAndExecute(update);
                    ControllerBot.ProcessedChats.Remove(update.ChatId);
                }
                else
                {
                    ControllerBot.Client.SendTextMessageAsync(update.ChatId, "Время выполнения операции вышло. Повторите операцию заново.");
                }
            });

            return Ok();
        }
    }
}
