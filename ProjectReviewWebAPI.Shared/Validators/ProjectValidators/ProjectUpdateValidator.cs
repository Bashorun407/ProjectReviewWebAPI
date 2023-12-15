using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Validators.ProjectValidators
{
    public class ProjectUpdateValidator : AbstractValidator<ProjectUpdateDto>
    {
        public ProjectUpdateValidator()
        {
            RuleFor(d => d.ProjectName).NotEmpty().WithMessage("Project Name field is required");
            RuleFor(d => d.ProjectDescription).NotEmpty().WithMessage("Project description field is required");
        }
    }
}
