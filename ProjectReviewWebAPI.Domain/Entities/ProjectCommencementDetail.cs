using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class ProjectCommencementDetail : BaseEntity
    {
        [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }

        [ForeignKey(nameof(User))]
        public string? ServiceProviderId { get; set; }
        public JobAcceptanceStatus? JobAcceptanceStatus { get; set; }
        public ProjectStartApproval? ProjectStartApproval { get; set; }
        public ProjectLevelApprovalStatus? ProjectLevelApprovalStatus { get; set; }
        public ProjectCompletionStatus? ProjectCompletionStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Navigational Properties
        //public Project Project { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
