using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public class ClientResponseDto
    {
        private string ProfilePicture { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }
        private string UserName { get; set; }
        private string Email { get; set; }

    }
}
