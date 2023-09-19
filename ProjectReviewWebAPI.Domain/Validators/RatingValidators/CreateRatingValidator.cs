using FluentValidation;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Validators.RatingValidators
{
    public class CreateRatingValidator : AbstractValidator<RatingRequestDto>
    {
        public CreateRatingValidator()
        {
            RuleFor(d => d.Username).NotEmpty().WithMessage("Username field is required");
            RuleFor(d => d.StarRating).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Rating field must be between 1 and 5");
        }
    }
}
