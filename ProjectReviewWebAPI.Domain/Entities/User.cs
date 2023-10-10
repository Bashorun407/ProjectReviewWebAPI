using Microsoft.AspNetCore.Identity;
using ProjectReviewWebAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? DateOfBirth { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }
        [Column(TypeName = "Money")]
        public double ChargeRate { get; set; }
        public UserRole Role { get; set; }
        public UserType UserType { get; set; }
        public ServiceProviderSpecialization Specialization { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public ApplicationReviewStatus ApplicationReviewStatus { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }

        //Relationship with Rating and Project table
        public Rating Ratings { get; set; }
        public IEnumerable<Project> Projects { get; set; }

    }
}
