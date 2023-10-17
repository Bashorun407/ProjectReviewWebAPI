using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectReview.WebAPI.Controllers
{
    [Route("project-api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Returns all projects
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>

        // GET: api/<ProjectController>
        [HttpGet("allProjects")]
        public async Task<IActionResult> GetAllProjects([FromQuery] ProjectRequestInputParameter parameter)
        {
            var result = await _projectService.GetAllProjectsAsync(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));
            return StatusCode(result.StatusCode, result);
        }

        /*        // GET: api/<ProjectController>
                [HttpGet("projectName/{projectName}")]
                public async Task<IActionResult> GetByProjectName(string projectName)
                {
                    var result = await _projectService.GetByProjectName(projectName);
                    //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
                    return Ok(result);
                }*/

        /// <summary>
        /// Returns all projects that falls under specified category
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="category"></param>
        /// <returns></returns>

        // GET: api/<ProjectController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<IEnumerable<ProjectResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("projectCategory/{category}")]
        public async Task<IActionResult> GetByCategory([FromQuery] int pageNumber, Category category)
        {
            var result = await _projectService.GetProjectsByCategory(pageNumber, category);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        /// <summary>
        /// Returns a project by passing projectOwnerId as method parameter
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>

        // GET: api/<ProjectController>
        //[Authorize(Roles = "Admin")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("projectOwnerId/{ownerId}")]
        public async Task<IActionResult> GetByProjectOwnerId(string ownerId)
        {
            var result = await _projectService.GetByProjectOwnerIdAsync(ownerId);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<ProjectController>
        //[Authorize(Roles = "Admin")]
        /*  [HttpGet("serviceProvider/{providerId}")]
          public async Task<IActionResult> GetByServiceProviderId(string providerId)
          {
              var result = await _projectService.GetByServiceProviderIdAsync(providerId);
              //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
              return Ok(result);
          }*/

        /// <summary>
        /// Returns all projects that fall under the specified Completion status which can be Pending, Started and Completed
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        // GET: api/<ProjectController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<IEnumerable<ProjectResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "Admin")]
        [HttpGet("projectStatus/{status}")]
        public async Task<IActionResult> GetByProjectCompletionStatus([FromQuery] int pageNumber, ProjectCompletionStatus status)
        {
            var result = await _projectService.GetByProjectStatus(pageNumber, status);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        /// <summary>
        /// Returns a project by entering specific Project level status which can be NOT_SATISFIED or SATISFIED
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        // GET: api/<ProjectController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<IEnumerable<ProjectResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "Admin")]
        [HttpGet("approvalStatus/{status}")]
        public async Task<IActionResult> GetByApprovalStatus( [FromQuery] int pageNumber, ProjectLevelApprovalStatus status)
        {
            var result = await _projectService.GetByApprovalStatus(pageNumber, status);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        /// <summary>
        /// Returns a project by entering project-id as method parameter
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>

        // GET api/<ProjectController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetByProjectId(string projectId)
        {
            var result = await _projectService.GetByProjectId(projectId);

            return Ok(result);
        }

        /// <summary>
        /// A project is created via this endpoint
        /// </summary>
        /// <param name="projectRequstDto"></param>
        /// <returns></returns>

        // POST api/<ProjectController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpPost("createProject")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectRequestDto projectRequstDto)
        {
           var result =  await _projectService.CreateProject(projectRequstDto);

            return Ok(result);
        }

        /// <summary>
        /// A project is updated by passing the project's id and update dto which contains update values
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectUpdateDto"></param>
        /// <returns></returns>

        // PUT api/<ProjectController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpPut("update/{projectId}")]
        public async Task<IActionResult> UpdateProject(string projectId, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            var result = await _projectService.UpdateProject(projectId, projectUpdateDto);

            return Ok(result);
        }

        /// <summary>
        /// Service providers will update a project via this endpoint
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectUpdateDto"></param>
        /// <returns></returns>

        // PUT api/<ProjectController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpPut("serviceProviderProjectUpdate/{projectId}")]
        public async Task<IActionResult> ServiceProviderProjectUpdate(string projectId, [FromBody] ProjectServiceProviderUpdateDto projectUpdateDto)
        {
            var result = await _projectService.ServiceProviderProjectUpdate(projectId, projectUpdateDto);

            return Ok(result);
        }

        /// <summary>
        /// Clients add Service provider to a project via this endpoint by passing the project's id as method parameter
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="serviceProviderDto"></param>
        /// <returns></returns>

        // PUT api/<ProjectController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpPut("addServiceProvider/{projectId}")]
        public async Task<IActionResult> AddServiceProvider(string projectId, [FromBody] SelectServiceProviderDto serviceProviderDto)
        {
            var result = await _projectService.AddServiceProvider(projectId, serviceProviderDto);

            return Ok(result);
        }

        /// <summary>
        /// Clients approve a projects level via this endpoint
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="projectUpdateDto"></param>
        /// <returns></returns>

        // PUT api/<ProjectController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpPut("adminProjectUpdate/{projectId}")]
        public async Task<IActionResult> AdminProjectUpdate(string projectId, [FromBody] ProjectAdminUpdateDto projectUpdateDto)
        {
            var result = await _projectService.AdminProjectUpdate(projectId, projectUpdateDto);

            return Ok(result);
        }

        /// <summary>
        /// Proejct owner can delete a project via this end point by passing a project's id as method parameter
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>

        // DELETE api/<ProjectController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpDelete("delete/{projectId}")]
        public async Task<IActionResult> DeleteProject(string projectId)
        {
            var result = await _projectService.DeleteProject(projectId);

            return Ok(result);
        }

        /// <summary>
        /// Client can upload picture to a project via this endpoint. project's id is added as method parameter
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="file"></param>
        /// <returns></returns>

        // [Authorize]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<ProjectResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        //[Authorize(Roles = "User")]
        [HttpPost("uploadImage/{projectId}")]
        public IActionResult UploadProfilePic(string projectId, IFormFile file)
        {
            var result = _projectService.UploadProfileImage(projectId, file);
            if (result.Result.Succeeded)
            {
                return Ok(new { ImageUrl = result.Result.Data.Item2 });
            }
            return NotFound();
        }
    }
}
