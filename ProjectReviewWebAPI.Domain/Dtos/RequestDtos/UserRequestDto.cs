using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public record UserRequestDto /*(string profilePicture, string firstName, string lastName, string username, 
        string email, string password, string? phoneNumber);*/
    {
        public string ProfilePicture { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string? PhoneNumber { get; init; }
    }
}
