using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectReview.WebAPI.Controllers
{
    [Route("rating-api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// Returns the ratings of all service providers
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>

        // GET: api/<RatingController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<PagedList<RatingResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("allRatings")]
        public async Task<IActionResult> GetAllRatings([FromQuery] RatingRequestInputParameter parameter)
        {
            var result = await _ratingService.GetAllRatingsAsync(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));
            
            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Returns the rating of a service provider by passing the username of the service provider as a parameter
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        // GET api/<RatingController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<RatingResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("rateByUserId/{userId}")]
        public async Task<IActionResult> GetRatingByUsername(string userId)
        {
            var result = await _ratingService.GetRatingByUserId(userId);

            return Ok(result);
        }

        /// <summary>
        /// A user rates a service provider by passing the username and rating (integer 1 - 5) as method parameter
        /// </summary>
        /// <param name="ratingRequestDto"></param>
        /// <returns></returns>

        // POST api/<RatingController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<RatingResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpPost("addRating")]
        public async Task<IActionResult> AddRating([FromBody] RatingRequestDto ratingRequestDto)
        {
            var result = await _ratingService.AddRating(ratingRequestDto);

            return Ok(result);
        }

    }
}
