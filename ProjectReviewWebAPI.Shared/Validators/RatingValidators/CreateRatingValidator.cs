using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Validators.RatingValidators
{
    public class CreateRatingValidator : AbstractValidator<RatingRequestDto>
    {
        public CreateRatingValidator()
        {
            RuleFor(d => d.UserId).NotEmpty().WithMessage("UserId field is required");
            RuleFor(d => d.StarRating).NotEmpty().InclusiveBetween(1, 5).WithMessage("Rating field is required and must be between 1 and 5");
        }
    }
}
