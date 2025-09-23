using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidation:AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidation()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Please Enter order Id");

        }
    }
}
