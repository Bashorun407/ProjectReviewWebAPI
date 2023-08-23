﻿using Microsoft.AspNetCore.Mvc;
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
        public  async Task<IActionResult> GetAllComments([FromQuery] CommentRequestInputParameter parameter)
        {
            var result = await _commentService.GetAllComments(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.comments);
        }

        // GET: api/<CommentController>
        [HttpGet("commentsByProjectId")]
        public async Task<IActionResult> GetCommentsByProjectId([FromQuery] CommentRequestInputParameter parameter)
        {
            var result = await _commentService.GetCommentsByProjectId(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            
            return Ok(result.Data.comments);
        }

        // GET api/<CommentController>/5
        [HttpGet("commentsByUserName")]
        public async Task<IActionResult> GetCommentsByUsername([FromQuery] CommentRequestInputParameter parameter)
        {
            var result = await _commentService.GetCommentsByUsername(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.comments));

            return Ok(result.Data.comments);
        }

        // POST api/<CommentController>
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment([FromBody] CommentRequestDto commentRequestDto)
        {
            var result = await _commentService.CreateComment(commentRequestDto);

            return Ok(result);
        }

/*        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
