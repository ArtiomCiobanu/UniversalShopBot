using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop.API;
using Shop.API.Singletones;
using Shop.Controllers;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            MessageController.ControllerBot = new TelegramBot("1158660778:AAEi0BoYtLIRBbfrNh6LmDbv7Lko3SIjppg")
            {
                Name = "TestTelegramShop"
            };
            MessageController.ControllerBot.SetWebhook("https://shoptelegrambot.azurewebsites.net/api/message/Update").Wait();

            /*ViberMessageController.ControllerBot = new TelegramBot("1158660778:AAEi0BoYtLIRBbfrNh6LmDbv7Lko3SIjppg")
            {
                Name = "TestViberBot"
            };*/

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
