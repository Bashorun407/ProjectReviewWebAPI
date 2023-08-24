using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class RatingRequestDto
    {
        public string UserId { get; set; }
        public int StarRating { get; set; }
        public int RateCount { get; set; }
        public double AverageRating { get; set; }
    }
}
