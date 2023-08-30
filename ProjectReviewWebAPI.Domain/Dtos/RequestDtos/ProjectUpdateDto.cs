using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class ProjectUpdateDto
    {
        public string? ServiceProviderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProjectCompletionStatus ProjectCompletionStatus { get; set; }
        public ProjectApprovalStatus ProjectApprovalStatus { get; set; }
        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
