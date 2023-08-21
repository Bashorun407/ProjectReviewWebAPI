using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public class UserResponseDto
    {
        private string ProfilePicture { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Specialization { get; set; }
        private string Description { get; set; }
        private ApplicationStatus Status { get; set; }
    }
}
