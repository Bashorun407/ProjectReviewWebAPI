using Microsoft.AspNetCore.Identity;
using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class User : IdentityUser
    {
        private string ProfilePicture { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        /*private DateOnly DateOfBirth { get; set; }
        private string PhoneNumber { get; set; }
        private string UserName { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }*/
        []
        private string UserId { get; set; }
        private string Specialization { get; set; }
        private string Description { get; set; }
        private UserRole Role { get; set; }
        private ApplicationStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;


    }
}
