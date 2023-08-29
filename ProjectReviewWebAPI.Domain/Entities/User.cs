using Microsoft.AspNetCore.Identity;
using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string? DateOfBirth { get; set; }
        public string? Description { get; set; }
        public string UserId { get; set; }
        [Column(TypeName = "Money")]
        public double ChargeRate { get; set; }
        public UserRole Role { get; set; }
        public UserType UserType { get; set; }
        public Specialization Specialization { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; }

        //Relationship with Rating table
        IEnumerable<Rating> Ratings { get; set; }
        IEnumerable<Project> Projects { get; set; }

    }
}
