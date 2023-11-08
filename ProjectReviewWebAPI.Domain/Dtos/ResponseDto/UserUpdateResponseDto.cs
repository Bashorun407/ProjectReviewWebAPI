using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public record UserUpdateResponseDto /*(string? profilePicture, string? phoneNumber, string? email, 
        string? password, string? description);*/
    {
        public string? ProfilePicture { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init; }
        public string? Password { get; init; }
        public string? Description { get; init; }

    }
}
