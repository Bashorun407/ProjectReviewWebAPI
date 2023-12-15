using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Abstractions
{
    public interface IRatingService
    {
        Task<StandardResponse<RatingResponseDto>> AddRating(RatingRequestDto ratingRequestDto);
        Task<StandardResponse<PagedList<RatingResponseDto>>> GetAllRatingsAsync(RatingRequestInputParameter parameter);
        Task<StandardResponse<RatingResponseDto>> GetRatingByUserId(string userId);
    }
}
