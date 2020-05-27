using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ViberMessageController : BotController
    {
        public override Task<OkObjectResult> DeleteWebhook()
        {
            throw new NotImplementedException();
        }

        public override OkObjectResult GetWebhookInfo()
        {
            throw new NotImplementedException();
        }

        public override Task<OkObjectResult> InitializeWebHook()
        {
            throw new NotImplementedException();
        }

        public override string Test()
        {
            throw new NotImplementedException();
        }

        public override void Update([FromBody] JsonElement input)
        {
            throw new NotImplementedException();
        }
    }
}
