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
       // [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }
        public string UserName { get; set; }
        public string Comments { get; set; }

        //Navigational Property
        public List<Project> Projects { get; set; }
    }
}
