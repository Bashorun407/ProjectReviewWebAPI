﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.UoW.Abstraction;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;

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
            //Check if ratingRequestDo.username exists in the database
            var user = await _unitOfWork.UserRepository.GetById(ratingRequestDto.UserId, false);
            if (user == null)
            {
                return StandardResponse<RatingResponseDto>.Failed($"User by this id: {ratingRequestDto.UserId} does not exist ", 99);
            }

            _logger.LogInformation("New rating for service provider");
            var rate = _mapper.Map<Rating>(ratingRequestDto);
            rate.UserId = user.Id; //UserId of rate class is gotten from user.Id (which is from Identity class

            //Check if a rating has been done for that user prior.
            var findRate = await _unitOfWork.RatingRepository.FindByCondition(c => c.UserId.Equals(user.Id), false).SingleOrDefaultAsync();
            
            if (findRate == null)
            {
                //If there was no rating for a, create a new rating
                rate.RateCount = 1; //Incrementing the count
                rate.AverageRating = rate.StarRating;

                await _unitOfWork.RatingRepository.CreateAsync(rate);
                await _unitOfWork.SaveAsync();

                _logger.LogInformation("Saved new rate to database");
                var newRate = _mapper.Map<RatingResponseDto>(rate);

                return StandardResponse<RatingResponseDto>.Success("Thanks for the new review", newRate, 201);

            }

            //Obtaining current data for average and count
            double currentAverage = findRate.AverageRating;
            int currentCount = findRate.RateCount;

            //Getting new values
            findRate.StarRating = rate.StarRating;
            findRate.RateCount = findRate.RateCount + 1;

            //To calculate the new average: Product of former average and former count summed with new rating and all
            //...divided with new count (i.e. former count + 1
            findRate.AverageRating =((currentAverage * currentCount) + rate.StarRating) / (currentCount + 1);

            //Updating with the new rate
            _unitOfWork.RatingRepository.Update(findRate);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation("Updated rate to database");
            var rateDto = _mapper.Map<RatingResponseDto>(rate);

            return StandardResponse<RatingResponseDto>.Success("Thanks for reviewing", rateDto, 201);
        }

        public async Task<StandardResponse<PagedList<RatingResponseDto>>> GetAllRatingsAsync(RatingRequestInputParameter parameter)
        {

            var result = await _unitOfWork.RatingRepository.GetAll(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<RatingResponseDto>>.Failed($"There are no ratings yet", 99);
            }
            var ratesDto = _mapper.Map<IEnumerable<RatingResponseDto>>(result);
            var pagedList = new PagedList<RatingResponseDto>(ratesDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<RatingResponseDto>>.Success($"All ratings", pagedList, 200);
           
        }

        public async Task<StandardResponse<RatingResponseDto>> GetRatingByUserId(string userId)
        {
            var rate = await _unitOfWork.RatingRepository.GetRatingByUserId(userId, false);

            if(rate is null)
            {
                return StandardResponse<RatingResponseDto>.Failed($"Rate by username: {userId} does not exist", 99);
            }

            var rateDto = _mapper.Map<RatingResponseDto>(rate);

            return StandardResponse<RatingResponseDto>.Success($"Rate by user with id: {userId}", rateDto, 200);
        }
    }
}
