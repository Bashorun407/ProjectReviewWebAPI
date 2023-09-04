using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public class ProjectResponseDto
    {
        public string CoverImage { get; set; }
        public string ProjectName { get; set; }
        public string ProjectId { get; set; }
        public Category Category { get; set; }
        public string ProjectOwner { get; set; }
        public string ProjectOwnerId { get; set; }
        public string? ServiceProviderId { get; set; }
        public ProjectCompletionStatus ProjectCompletionStatus { get; set; }
        public ProjectApprovalStatus ProjectApprovalStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
