using CqrsCrudDemo.Application.Products.Commands;
using CqrsCrudDemo.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CqrsCrudDemo.Api.FluentValidator
{
    public class CreateUserCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(2000);
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
