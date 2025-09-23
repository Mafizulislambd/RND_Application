using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandlers : IRequestHandler<DeleteOrderCommand, bool>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public DeleteOrderCommandHandlers(IOrderRepository orderRepository,IMapper mapper)
        {
            _orderRepository=orderRepository;
            _mapper=mapper;
            
        }
        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
           // var order = _mapper.Map<Order>(request);
            return await _orderRepository.DeleteAsync(new Domain.Models.Order() { Id=request.Id});
        }
    }
}
