using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderByUserName
{
    public class GetUserByOrderQueries:IRequest<List<OrderVm>>
    {
        public string UserName { get; set; }
        public GetUserByOrderQueries(string userName)
        {
            UserName = userName;
        }
    }
}
