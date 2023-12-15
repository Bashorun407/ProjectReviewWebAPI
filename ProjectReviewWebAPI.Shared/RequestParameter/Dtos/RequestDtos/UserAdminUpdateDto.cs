using ProjectReviewWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record UserAdminUpdateDto 
    {
        public UserRole UserRole { get; init; }
        public UserType UserType { get; init; }
        public ApplicationReviewStatus ApplicationReviewStatus { get; init; }
    }
}
