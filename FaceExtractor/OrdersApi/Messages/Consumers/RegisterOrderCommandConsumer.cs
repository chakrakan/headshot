using MassTransit;
using Messaging.InterfacesConstants.Commands;
using OrdersApi.Models;
using OrdersApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersApi.Messages.Consumers
{
    public class RegisterOrderCommandConsumer : IConsumer<IRegisterOrderCommand>
    {
        private readonly IOrderRepository _orderRepo;

        public RegisterOrderCommandConsumer(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public Task Consume(ConsumeContext<IRegisterOrderCommand> context)
        {
            var result = context.Message;
            if (result.OrderId != null && result.PictureUrl != null && result.UserEmail != null && result.ImageData != null)
            {
                SaveOrder(result);
            }
            return Task.FromResult(true); 
        }

        private void SaveOrder(IRegisterOrderCommand result)
        {
            Order order = new Order
            {
                OrderId = result.OrderId,
                UserEmail = result.UserEmail,
                Status = Status.Registered,
                PictureUrl = result.PictureUrl,
                ImageData = result.ImageData
            };
            _orderRepo.RegisterOrder(order);
        }
    }
}
