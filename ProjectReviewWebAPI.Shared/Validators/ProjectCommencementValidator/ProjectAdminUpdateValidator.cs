using FluentValidation;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Validators.ProjectCommencementValidator
{
    public class ProjectAdminUpdateValidator : AbstractValidator<ProjectAdminUpdateDto>
    {
        public ProjectAdminUpdateValidator()
        {
            RuleFor(d => d.ProjectLevelApprovalStatus).NotEmpty().WithMessage("Project description field is required");
        }
    }
}
