using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class ProjectServiceProviderUpdateDto
    {
        //public string ServiceProviderUsername { get; set; }
        public JobAcceptanceStatus JobAcceptanceStatus { get; set; }
        public ProjectCompletionStatus ProjectCompletionStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
