using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidation:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            RuleFor(c => c.Id).GreaterThan(0).WithMessage("Please Enter order Id");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("Please Entry user Name").EmailAddress().WithMessage("Enter Valid Email Address");
            RuleFor(c => c.FirstName).NotEmpty().WithMessage("Plese enterf first name").MaximumLength(100).WithMessage("First name must not exceed 100 characters..");
            RuleFor(c => c.TotalPrice).GreaterThan(0).WithMessage("Total price should be greater then o");



            RuleFor(c => c.EmailAddress).EmailAddress().WithMessage("Email Addres should be valid Email");
        }
    }
}
