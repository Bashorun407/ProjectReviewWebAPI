using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Validators.ProjectCommencementValidator
{
    public class ProjectServiceProviderUpdateValidator : AbstractValidator<ProjectServiceProviderUpdateDto>
    {
        public ProjectServiceProviderUpdateValidator()
        {
            RuleFor(d => d.JobAcceptanceStatus).NotEmpty().WithMessage("Job Acceptance Status field is required");
            RuleFor(d => d.StartDate).NotEmpty().WithMessage("Project Start Date can not be empty");
            RuleFor(d => d.EndDate).NotEmpty().GreaterThan(d => d.StartDate).WithMessage("Project End Date must be greater than Project Start Date");
        }
    }
}
