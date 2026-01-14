using AutoMapper;
using MediatR;
using Ordering.Application.Contacts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderByUserName
{
    public class GetOrderByUserHandlers : IRequestHandler<GetUserByOrderQueries, List<OrderVm>>
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public GetOrderByUserHandlers(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;

        }

        public async Task<List<OrderVm>> Handle(GetUserByOrderQueries request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByUSerName(request.UserName);
            return _mapper.Map<List<OrderVm>>(orders);
        }
    }
}
