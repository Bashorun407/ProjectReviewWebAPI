using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.UoW.Abstraction;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class RatingService : IRatingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RatingService> _logger;

        public RatingService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RatingService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StandardResponse<RatingResponseDto>> AddRating(RatingRequestDto ratingRequestDto)
        {
            _logger.LogInformation("New rating for service provider");
            var rate = _mapper.Map<Rating>(ratingRequestDto);
            await _unitOfWork.RatingRepository.CreateAsync(rate);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Saved new rate to database");
            var rateDto = _mapper.Map<RatingResponseDto>(rate);

            return StandardResponse<RatingResponseDto>.Success("Thanks for reviewing", rateDto, 201);
        }

        public async Task<StandardResponse<(IEnumerable<RatingResponseDto> ratings, MetaData pagingData)>> GetAllRatingsAsync(RatingRequestInputParameter parameter)
        {
            var result = await _unitOfWork.RatingRepository.GetAllRating(parameter);
            var ratesDto = _mapper.Map<IEnumerable<RatingResponseDto>>(result);

            return StandardResponse<(IEnumerable<RatingResponseDto>, MetaData)>.Success("All ratings", (ratesDto, result.MetaData), 200);
           
        }

        public async Task<StandardResponse<RatingResponseDto>> GetRatingByUserId(string userId)
        {
            var rate = await _unitOfWork.RatingRepository.GetRatingByUserId(userId);

            if(rate is null)
            {
                return StandardResponse<RatingResponseDto>.Failed($"Rate by user id: {userId} does not exist", 99);
            }

            var rateDto = _mapper.Map<RatingResponseDto>(rate);

            return StandardResponse<RatingResponseDto>.Success($"Rate by user with id: {userId}", rateDto, 200);
        }
    }
}
