using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string? CoverImage { get; set; }
        public string ProjectName { get; set; }
        public Category Category { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProjectId { get; set;}
        public string ProjectDescription { get; set;}

        [ForeignKey(nameof(User))]
        public string ProjectOwnerId { get; set; }
        [ForeignKey(nameof(User))]
        public string? ServiceProviderId{ get; set; }
        public JobAcceptanceStatus? JobAcceptanceStatus { get; set; }
        public ProjectStartApproval? ProjectStartApproval { get; set; }
        public ProjectLevelApprovalStatus? ProjectLevelApprovalStatus { get; set; }
        public ProjectCompletionStatus? ProjectCompletionStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
