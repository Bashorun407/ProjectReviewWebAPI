using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class UserAdminUpdateDto
    {
        public UserRole UserRole { get; set; }
        public UserType UserType { get; set; }  
        public ApplicationReviewStatus ApplicationReviewStatus { get; set; }
    }
}
