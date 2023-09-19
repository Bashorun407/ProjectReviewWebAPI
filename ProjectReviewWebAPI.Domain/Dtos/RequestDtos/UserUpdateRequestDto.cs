using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class UserUpdateRequestDto
    {
        public string? PhoneNumber { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? DateOfBirth { get; set; }
        /*public string? Description { get; set; }
        [Column(TypeName = "Money")]
        public double ChargeRate { get; set; }
        public UserType UserType { get; set; }
        public ServiceProviderSpecialization Specialization { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }*/

        //Newly added

        public DateTime ModifiedAt { get; set; } = DateTime.Now;
    }
}
