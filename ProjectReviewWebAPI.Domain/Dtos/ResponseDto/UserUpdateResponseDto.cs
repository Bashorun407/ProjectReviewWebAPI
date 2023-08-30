using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public class UserUpdateResponseDto
    {
        public string? ProfilePicture { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
/*        public UserType UserType { get; set; }
        public Specialization Specialization { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public DateTime ModifiedAt { get; set; }*/
    }
}
