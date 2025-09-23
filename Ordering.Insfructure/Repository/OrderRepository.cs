using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contacts.Persistence;
using Ordering.Domain.Models;
using Ordering.Insfructure.Persistence;

namespace Ordering.Insfructure.Repository
{
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        OrderDbContext _orderContext;
        public OrderRepository( OrderDbContext orderContext) : base(orderContext)
        {
            _orderContext = orderContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUSerName(string userName)
        {
            var orderlist = await _orderContext.Orders.Where(c => c.UserName.ToLower() == userName.ToLower()).ToListAsync();
            return orderlist;
        }
    }
}
