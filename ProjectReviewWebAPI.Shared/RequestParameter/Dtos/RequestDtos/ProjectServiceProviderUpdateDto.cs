using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record ProjectServiceProviderUpdateDto 
    {
        public JobAcceptanceStatus JobAcceptanceStatus { get; init; }
        public ProjectCompletionStatus ProjectCompletionStatus { get; init; }
        public DateTime? StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }
}
