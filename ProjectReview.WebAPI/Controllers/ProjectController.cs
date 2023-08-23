using Microsoft.AspNetCore.Authorization;
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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/<ProjectController>
        [HttpGet("allProjects")]
        public async Task<IActionResult> GetAllProjects([FromQuery] ProjectRequestInputParameter parameter)
        {
            var result = await _projectService.GetAllProjectsAsync(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.projects);
        }

        // GET: api/<ProjectController>
        [HttpGet("projectName")]
        public async Task<IActionResult> GetByProjectName([FromQuery] ProjectRequestInputParameter parameter)
        {
            var result = await _projectService.GetByProjectName(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.projects);
        }

        // GET: api/<ProjectController>
        [HttpGet("projectCategory")]
        public async Task<IActionResult> GetByCategory([FromQuery] ProjectRequestInputParameter parameter)
        {
            var result = await _projectService.GetProjectsByCategory(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.projects);
        }

        // GET: api/<ProjectController>
        [Authorize(Roles = "Admin")]
        [HttpGet("projectOwnerId")]
        public async Task<IActionResult> GetByProjectOwnerId([FromQuery] ProjectRequestInputParameter parameter)
        {
            var result = await _projectService.GetByProjectOwnerIdAsync(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.projects);
        }

        // GET: api/<ProjectController>
        [Authorize(Roles = "Admin")]
        [HttpGet("serviceProvider")]
        public async Task<IActionResult> GetByServiceProviderId([FromQuery] ProjectRequestInputParameter parameter)
        {
            var result = await _projectService.GetByServiceProviderIdAsync(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.projects);
        }

        // GET: api/<ProjectController>
        [HttpGet("projectStatus")]
        public async Task<IActionResult> GetByProjectCompletionStatus([FromQuery] ProjectRequestInputParameter parameter)
        {
            var result = await _projectService.GetByProjectStatus(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.projects);
        }

        // GET: api/<ProjectController>
        [Authorize(Roles = "Admin")]
        [HttpGet("approvalStatus")]
        public async Task<IActionResult> GetByApprovalStatus([FromQuery] ProjectRequestInputParameter parameter)
        {
            var result = await _projectService.GetByApprovalStatus(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.projects);
        }

        // GET api/<ProjectController>/5

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByProjectId(string id)
        {
            var result = await _projectService.GetByProjectId(id);

            return Ok(result);
        }

     /*   // GET api/<ProjectController>/5
        [HttpGet("projectId/{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<ProjectController>
        [HttpPost("createProject")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectRequestDto projectRequstDto)
        {
           var result =  await _projectService.CreateProject(projectRequstDto);

            return Ok(result);
        }

        // PUT api/<ProjectController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectRequestDto projectRequestDto)
        {
            var result = await _projectService.UpdateProject(id, projectRequestDto);

            return Ok(result);
        }

        // DELETE api/<ProjectController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectService.DeleteProject(id);

            return Ok(result);
        }
    }
}
