using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public record ProjectServiceProviderUpdateDto /*(JobAcceptanceStatus JobAcceptanceStatus, ProjectCompletionStatus projectCompletionStatus, 
        DateTime? startDate, DateTime? endDate);*/
    {

        public JobAcceptanceStatus JobAcceptanceStatus { get; init; }
        public ProjectCompletionStatus ProjectCompletionStatus { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }
}
