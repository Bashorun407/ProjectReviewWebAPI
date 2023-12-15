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
        public string ProjectDescription { get; set;}

        [ForeignKey(nameof(User))]
        public string ProjectOwnerId { get; set; }

/*        [ForeignKey(nameof(ProjectCommencementDetail))]
        public string ProjectCommencementId { get; set; }*/

        //Navigational Property
        public User User { get; set; }
        public ProjectCommencementDetail ProjectCommencementDetail { get; set; }

    }
}
