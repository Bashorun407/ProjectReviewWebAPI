using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class Comment : BaseEntity
    {
        [ForeignKey(nameof(Project))]
        private string ProjectId { get; set; }
        private string UserName { get; set; }
        private string Comments { get; set; }

        //Navigational Property
        private List<Project> Projects { get; set; }
    }
}
