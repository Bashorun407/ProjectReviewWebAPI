using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Validators.CommentValidators
{
    public class CreateCommentValidator : AbstractValidator<CommentRequestDto>
    {
        public CreateCommentValidator()
        {
            RuleFor(d => d.UserName).NotEmpty().WithMessage("UserId field is required");
            RuleFor(d => d.Comments).NotEmpty().WithMessage("Comment field is required");
        }
    }
}
