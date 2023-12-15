using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record UserLoginDto /*(string email, string password);*/
    {
        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
