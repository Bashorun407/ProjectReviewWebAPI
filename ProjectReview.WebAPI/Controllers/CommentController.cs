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
        public  async Task<IActionResult> GetAllComments([FromQuery] int pageNumber)
        {
            var result = await _commentService.GetAllComments(pageNumber);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }


        /// <summary>
        /// Returns comments by username. username of user is passed as method argument
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

        // GET api/<CommentController>/5
        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetCommentsByUsername(string username)
        {
            var result = await _commentService.GetCommentsByUsername(username);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.comments));

            return Ok(result);
        }

        /// <summary>
        /// Users are able to add comment via this endpoint
        /// </summary>
        /// <param name="commentRequestDto"></param>
        /// <returns></returns>

        // POST api/<CommentController>
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentRequestDto commentRequestDto)
        {
            var result = await _commentService.CreateComment(commentRequestDto);

            return Ok(result);
        }

    }
}
