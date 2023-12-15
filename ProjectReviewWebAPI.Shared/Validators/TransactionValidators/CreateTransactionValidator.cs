using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Validators.TransactionValidators
{
    public class CreateTransactionValidator : AbstractValidator<TransactionRequestDto>
    {
        public CreateTransactionValidator()
        {
            RuleFor(d => d.FirstName).NotEmpty().WithMessage("Name field is required");;
            RuleFor(d => d.LastName).NotEmpty().WithMessage("Last name field is required");
            RuleFor(d => d.Email).NotEmpty().WithMessage("Email field is required");
            RuleFor(d => d.ProjectId).NotEmpty().WithMessage("ProjectId field is required");
            RuleFor(d => d.UserId).NotEmpty().WithMessage("UserId field is required");
            RuleFor(d => d.Amount).NotEmpty().GreaterThan(1).WithMessage("Amount field is required");

        }
    }
}
