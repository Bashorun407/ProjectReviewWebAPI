using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Validators.UserValidators
{
    public class UserAdminUpdateValidator : AbstractValidator<UserAdminUpdateDto>
    {
        public UserAdminUpdateValidator()
        {
            RuleFor(d => d.UserRole).NotEmpty().WithMessage("UserRole field is required");
            RuleFor(d => d.UserType).NotEmpty().WithMessage("UserType field is required");
            RuleFor(d => d.ApplicationReviewStatus).NotEmpty().WithMessage("ApplicationReviewStatus field is required");
        }
    }
}
