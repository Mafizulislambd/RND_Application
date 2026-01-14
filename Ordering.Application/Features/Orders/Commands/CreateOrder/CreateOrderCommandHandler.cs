using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Insfrastructure;
using Ordering.Application.Contacts.Persistence;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Models;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandlers : IRequestHandler<DeleteOrderCommand, bool>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        IEmailService _emailService;
        public CreateOrderCommandHandlers(IOrderRepository orderRepository,IMapper mapper,IEmailService emailService)
        {
            _orderRepository=orderRepository;
            _mapper=mapper;
            _emailService=emailService;
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            order.CreatedBy = "Sumon";
            order.CreatedDate = new DateTime();
            bool isOrderPlaced=await _orderRepository.AddAsync(order);
            if (isOrderPlaced)
            {
                EmailMessage email = new EmailMessage();
                email.Subject = "Your has been placed";
                email.To = order.UserName;
                email.Body = $"Dear{order.FirstName + " " + order.LastName} <br/> <br/> wWe are Excited for you to erceived your order #{order.Id} and with notify you one it's way . <br/> Thanks for ordering from ..... ";

                await _emailService.SenddEmailAsync(email);
            }
            return isOrderPlaced;
        }
    }
}
