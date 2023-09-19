using ProjectReviewWebAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class UserServiceProviderUpdateDto
    {
        //public UserType UserType { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public ServiceProviderSpecialization Specialization { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "Money")]
        public double ChargeRate { get; set; }
        //public ApplicationReviewStatus? ApplicationReviewStatus { get; set; }
    }
}
