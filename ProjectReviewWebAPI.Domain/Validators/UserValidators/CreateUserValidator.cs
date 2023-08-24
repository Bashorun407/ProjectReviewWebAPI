using FluentValidation;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Validators.ServiceProviderValidators
{
    public class CreateUserValidator : AbstractValidator<UserRequestDto>
    {
        public CreateUserValidator()
        {
            RuleFor(d => d.FirstName).NotEmpty().WithMessage("First name field is required");
            RuleFor(d => d.LastName).NotEmpty().WithMessage("Last name field is required");
            RuleFor(d => d.PhoneNumber).NotEmpty().WithMessage("Phone number field is required");
            RuleFor(d => d.Email).NotEmpty().WithMessage("Email field is required");
            RuleFor(d => d.UserName).NotEmpty().WithMessage("Username field is required");
            RuleFor(d => d.Password).NotEmpty().WithMessage("Password  field is required");
        }
    }
}
