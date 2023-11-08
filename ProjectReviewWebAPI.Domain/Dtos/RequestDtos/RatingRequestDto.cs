using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public record RatingRequestDto /*(string serviceProviderId, string starRating);*/
    {
        public string? ServiceProviderId { get; init; }
        public int StarRating { get; init; }
    }
}
