using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.InterfacesConstants.Constants
{
    public class RabbitMqMassTransitConstants
    {
        public const string RabbitMqUri = "rabbitmq://rabbitmq/";
        public const string Username = "guest";
        public const string Password = "guest";
        public const string RegisterOrderCommandQueue = "register.order.command";
    }
}
