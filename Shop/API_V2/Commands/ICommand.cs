using Shop.API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API_V2.Commands
{
    public interface ICommand
    {
        public string Name { get; }

        public void Execute(Update update, IBotClient client);
        public bool MustBeExecutedForUpdate(Update updateMessage);
        public bool ContainsCommandName(string messageText);
    }
}
