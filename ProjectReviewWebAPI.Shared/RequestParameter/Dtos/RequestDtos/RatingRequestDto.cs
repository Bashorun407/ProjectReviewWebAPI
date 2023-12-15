using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.RequestDtos
{
    public record RatingRequestDto     
    {
        public string? UserId { get; init; }
        public int StarRating { get; init; }
    }
}
