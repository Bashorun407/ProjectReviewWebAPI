using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.ResponseDto
{
    public record RatingResponseDto 
    {
        public string UserId { get; init; }
        public int StarRating { get; init; }
        public int RateCount { get; init; }
        public double AverageRating { get; init; }

    }
}
