using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.ResponseDto
{
    public record UserUpdateResponseDto     
    {
        public string? ProfilePicture { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init; }
        public string? Password { get; init; }
        public string? Description { get; init; }

    }
}
