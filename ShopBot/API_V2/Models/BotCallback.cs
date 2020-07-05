using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBot.API_V2.Models
{
    public class BotCallback
    {
        public SerializedCallbackData SerializedData { get; private set; }
        public int MessageId { get; set; }

        public void SetSerializedData(string unserializedData)
        {
            SerializedData = new SerializedCallbackData(unserializedData);
        }
    }
}
