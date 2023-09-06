using ProjectReviewWebAPI.Domain.Entities;
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
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Description { get; set; }
        public UserType UserType { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }

        //Navigational property...to fetch user's projects
        public RatingResponseDto Ratings { get; set; }
        public IEnumerable<ProjectResponseDto> Projects { get; set; }
    }
}
