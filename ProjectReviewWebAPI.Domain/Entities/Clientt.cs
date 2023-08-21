using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class Clientt : BaseEntity
    {
        private string ProfilePicture { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private DateOnly DateOfBirth { get; set; }
        private string PhoneNumber { get; set; }
        private string UserName { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
    }
}
