using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Validators.UserValidators
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateRequestDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(d => d.Email).EmailAddress().NotEmpty().WithMessage("Email field is required");
            RuleFor(d => d.Password).NotEmpty().Length(4, 8).WithMessage("Password description field is required");
            RuleFor(d => d.PhoneNumber).NotEmpty().WithMessage("Phone number field is required");
            RuleFor(d => d.Username).NotEmpty().WithMessage("Username field is required");
            RuleFor(d => d.DateOfBirth).NotEmpty().WithMessage("Date of Birth field is required");
        }
    }
}
