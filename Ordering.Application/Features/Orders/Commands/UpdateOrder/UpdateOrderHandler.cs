using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;
using Ordering.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        IOrderRepository _repository;
        IMapper _mapper;

        public UpdateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _repository = orderRepository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            
            var order = _mapper.Map<Order>(request);
            order.UpdatedBy = "123";
            order.UpdateDate = new DateTime();
            return await _repository.UpdateAsync(order);
        }
    }
}
