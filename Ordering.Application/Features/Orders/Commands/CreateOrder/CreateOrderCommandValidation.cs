using FluentValidation;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidation:AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Please Entry user Name").EmailAddress().WithMessage("Enter Valid Email Address");
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Plese enterf first name").MaximumLength(100).WithMessage("First name must not exceed 100 characters..");
            RuleFor(c => c.TotalPrice).GreaterThan(0).WithMessage("Total price should be greater then o");



            RuleFor(c => c.EmailAddress).EmailAddress().WithMessage("Email Addres should be valid Email");
        }
    }
}
