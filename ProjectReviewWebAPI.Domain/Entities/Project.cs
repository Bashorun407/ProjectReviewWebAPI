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
        public Category Category { get; set; }
        public string ProjectName { get; set;}
        public string ProjectId { get; set;}
        public string ProjectDescription { get; set;}
        [Column(TypeName = "Money")]
        public double Budget { get; set; }
        public string ProjectOwner { get; set; }

        [ForeignKey(nameof(User))]
        public string ProjectOwnerId { get; set; } 
        public string? ServiceProviderId { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set;}
        public ProjectCompletionStatus ProjectCompletionStatus { get; set; }
        public ProjectApprovalStatus ProjectApprovalStatus { get; set; }

        //Navigation Property
        public User User { get; set; } //This may not be important due to my implimentation on Rating class
        public IEnumerable<Comment> Comments { get; set; }
    }
}
