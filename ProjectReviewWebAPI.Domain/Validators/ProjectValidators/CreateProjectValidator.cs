using FluentValidation;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Validators.ProjectValidators
{
    public class CreateProjectValidator : AbstractValidator<ProjectRequestDto>
    {
        public CreateProjectValidator()
        {
            RuleFor(d => d.ProjectName).NotEmpty().WithMessage("Name field is required");
            RuleFor(d => d.ProjectDescription).NotEmpty().WithMessage("Project description field is required");
        }
    }
}
