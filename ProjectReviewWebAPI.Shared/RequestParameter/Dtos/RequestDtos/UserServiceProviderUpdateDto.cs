using ProjectReviewWebAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record UserServiceProviderUpdateDto 
    {
        public ApplicationStatus ApplicationStatus { get; init; }
        public ServiceProviderSpecialization Specialization { get; init; }
        public string? Description { get; init; }
        [Column(TypeName = "Money")]
        public double ChargeRate { get; init; }
    }
}
