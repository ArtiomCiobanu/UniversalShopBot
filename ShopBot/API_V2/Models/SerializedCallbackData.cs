using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
{
    public class SerializedCallbackData
    {
        public string CommandName { get; set; }
        public string Data { get; set; }

        public SerializedCallbackData()
        {

        }
        public SerializedCallbackData(string unserializedData)
        {
            var words = unserializedData.Split();

            CommandName = words[0];
            Data = words[1];
        }
    }
}
