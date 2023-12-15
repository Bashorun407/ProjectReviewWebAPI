using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Validators.UserValidators
{
    public class UserServiceProviderUpdateValidator : AbstractValidator<UserServiceProviderUpdateDto>
    {
        public UserServiceProviderUpdateValidator()
        {
            RuleFor(d => d.Specialization).NotEmpty().WithMessage("Specialization field is required");
            RuleFor(d => d.ApplicationStatus).NotEmpty().WithMessage("Application Status description field is required");
            RuleFor(d => d.ChargeRate).NotEmpty().GreaterThan(0).WithMessage("Charge rate field is required");
        }
    }
}
