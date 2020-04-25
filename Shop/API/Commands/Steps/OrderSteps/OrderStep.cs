using Shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Commands.Steps.OrderSteps
{
    interface IOrderStep : IStep
    {
        public OrderData Data { get; }
    }
}
