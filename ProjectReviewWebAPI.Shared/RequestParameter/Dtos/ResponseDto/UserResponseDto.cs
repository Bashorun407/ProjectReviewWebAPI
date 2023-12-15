using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.ResponseDto
{
    public record UserResponseDto 
    {
        public string? ProfilePicture { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserId { get; init; }
        public string? Specialization { get; init; }
        public string? Description { get; init; }
        public UserType UserType { get; init; }
        public ApplicationStatus ApplicationStatus { get; init; }
    }
}
