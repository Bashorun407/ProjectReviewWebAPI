using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class ProjectRequestDto
    {
        public string CoverImage { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string Category { get; set; }
        [Column(TypeName = "Money")]
        public double Budget { get; set; }
        public string ProjectOwner { get; set; }

        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
