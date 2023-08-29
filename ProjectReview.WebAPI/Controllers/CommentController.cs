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

        // GET: api/<CommentController>
        [HttpGet("allComments")]
        public  async Task<IActionResult> GetAllComments()
        {
            var result = await _commentService.GetAllComments();
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<CommentController>
        [HttpGet("commentsByProjectId/{projectId}")]
        public async Task<IActionResult> GetCommentsByProjectId(string projectId)
        {
            var result = await _commentService.GetCommentsByProjectId(projectId);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            
            return Ok(result);
        }

        // GET api/<CommentController>/5
        [HttpGet("commentsByUserName/{username}")]
        public async Task<IActionResult> GetCommentsByUsername([FromQuery] string username)
        {
            var result = await _commentService.GetCommentsByUsername(username);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.comments));

            return Ok(result);
        }

        // POST api/<CommentController>
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentRequestDto commentRequestDto)
        {
            var result = await _commentService.CreateComment(commentRequestDto);

            return Ok(result);
        }

    }
}
