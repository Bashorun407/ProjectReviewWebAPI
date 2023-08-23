using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectReview.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        // GET: api/<RatingController>
        [HttpGet("allRatings")]
        public async Task<IActionResult> GetAllRatings([FromQuery] RatingRequestInputParameter parameter)
        {
            var result = await _ratingService.GetAllRatingsAsync(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            
            return Ok(result.Data.ratings);
        }

        // GET api/<RatingController>/5
        [HttpGet("rateByUserId/{id}")]
        public async Task<IActionResult> GetRatingByUserId(string id)
        {
            var result = await _ratingService.GetRatingByUserId(id);

            return Ok(result);
        }

        // POST api/<RatingController>
        [HttpPost]
        public async Task<IActionResult> AddRating([FromBody] RatingRequestDto ratingRequestDto)
        {
            var result = await _ratingService.AddRating(ratingRequestDto);

            return Ok(result);
        }

/*        // PUT api/<RatingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RatingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
