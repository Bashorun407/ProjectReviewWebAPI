using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectReview.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

/*        [HttpGet("allCommentsByProjectId/{projectId}")]
        public async Task<IActionResult> GetAllCommentsByProjectId(string projectId)
        {
            var result = await _projectService.GetAllCommentsByProjectId(projectId);

            return Ok(result);
        }*/

        // GET: api/<ProjectController>
        [HttpGet("allProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var result = await _projectService.GetAllProjectsAsync();
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<ProjectController>
        [HttpGet("projectName/{projectName}")]
        public async Task<IActionResult> GetByProjectName(string projectName)
        {
            var result = await _projectService.GetByProjectName(projectName);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<ProjectController>
        [HttpGet("projectCategory/{category}")]
        public async Task<IActionResult> GetByCategory(Category category)
        {
            var result = await _projectService.GetProjectsByCategory(category);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<ProjectController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("projectOwnerId/{ownerId}")]
        public async Task<IActionResult> GetByProjectOwnerId(string ownerId)
        {
            var result = await _projectService.GetByProjectOwnerIdAsync(ownerId);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<ProjectController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("serviceProvider/{providerId}")]
        public async Task<IActionResult> GetByServiceProviderId(string providerId)
        {
            var result = await _projectService.GetByServiceProviderIdAsync(providerId);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<ProjectController>
        [HttpGet("projectStatus/{status}")]
        public async Task<IActionResult> GetByProjectCompletionStatus(ProjectCompletionStatus status)
        {
            var result = await _projectService.GetByProjectStatus(status);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<ProjectController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("approvalStatus/{status}")]
        public async Task<IActionResult> GetByApprovalStatus(ProjectApprovalStatus status)
        {
            var result = await _projectService.GetByApprovalStatus(status);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET api/<ProjectController>/5

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByProjectId(string id)
        {
            var result = await _projectService.GetByProjectId(id);

            return Ok(result);
        }


        // POST api/<ProjectController>
        [HttpPost("createProject")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectRequestDto projectRequstDto)
        {
           var result =  await _projectService.CreateProject(projectRequstDto);

            return Ok(result);
        }

        // PUT api/<ProjectController>/5
        //[Authorize(Roles = "Admin")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            var result = await _projectService.UpdateProject(id, projectUpdateDto);

            return Ok(result);
        }

        // DELETE api/<ProjectController>/5
        //[Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProject(id);

            return Ok(result);
        }
    }
}
