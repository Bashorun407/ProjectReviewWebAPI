using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public record ProjectResponseDto /*(string coverImage, string projectName, string projectId, Category category, 
        string projectOwner, ProjectCompletionStatus projectCompletionStatus, ProjectLevelApprovalStatus projectLevelApprovalStatus, 
        DateTime startDate, DateTime endDate);*/
    {
        public string CoverImage { get; init; }
        public string ProjectName { get; init; }
        public string ProjectId { get; init; }
        public Category Category { get; init; }
        public string ProjectOwner { get; init; }
        public ProjectCompletionStatus ProjectCompletionStatus { get; init; }
        public ProjectLevelApprovalStatus ProjectApprovalStatus { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}
