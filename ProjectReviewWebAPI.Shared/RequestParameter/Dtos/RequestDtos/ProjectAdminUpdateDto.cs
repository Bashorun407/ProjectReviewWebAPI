
using ProjectReviewWebAPI.Domain.Enums;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record ProjectAdminUpdateDto
    {
        public ProjectLevelApprovalStatus ProjectLevelApprovalStatus { get; init; }
    }
}
