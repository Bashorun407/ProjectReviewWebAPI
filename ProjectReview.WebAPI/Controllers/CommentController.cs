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
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Returns all comments by users
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>

        // GET: api/<CommentController>
        [HttpGet("allComments")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<PagedList<CommentResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        public  async Task<IActionResult> GetAllComments([FromQuery]CommentRequestInputParameter parameter)
        {
            var result = await _commentService.GetAllComments(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));
            return StatusCode(result.StatusCode, result);
        }


        /// <summary>
        /// Returns comments by username. username of user is passed as method argument
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        // GET api/<CommentController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<CommentResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetCommentsByUsername(CommentRequestInputParameter parameter)
        {
            var result = await _commentService.GetCommentsByUsername(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Users are able to add comment via this endpoint
        /// </summary>
        /// <param name="commentRequestDto"></param>
        /// <returns></returns>

        // POST api/<CommentController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<CommentResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentRequestDto commentRequestDto)
        {
            var result = await _commentService.CreateComment(commentRequestDto);

            return Ok(result);
        }

    }
}
