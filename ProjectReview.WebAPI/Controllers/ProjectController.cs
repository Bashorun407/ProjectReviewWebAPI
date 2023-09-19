﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Application.Services.Implementations;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
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

        // GET: api/<ProjectController>
        [HttpGet("allProjects")]
        public async Task<IActionResult> GetAllProjects([FromQuery] int pageNumber)
        {
            var result = await _projectService.GetAllProjectsAsync(pageNumber);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

/*        // GET: api/<ProjectController>
        [HttpGet("projectName/{projectName}")]
        public async Task<IActionResult> GetByProjectName(string projectName)
        {
            var result = await _projectService.GetByProjectName(projectName);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }*/

        // GET: api/<ProjectController>
        [HttpGet("projectCategory/{category}")]
        public async Task<IActionResult> GetByCategory([FromQuery] int pageNumber, Category category)
        {
            var result = await _projectService.GetProjectsByCategory(pageNumber, category);
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
        /*  [HttpGet("serviceProvider/{providerId}")]
          public async Task<IActionResult> GetByServiceProviderId(string providerId)
          {
              var result = await _projectService.GetByServiceProviderIdAsync(providerId);
              //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
              return Ok(result);
          }*/

        // GET: api/<ProjectController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("projectStatus/{status}")]
        public async Task<IActionResult> GetByProjectCompletionStatus([FromQuery] int pageNumber, ProjectCompletionStatus status)
        {
            var result = await _projectService.GetByProjectStatus(pageNumber, status);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET: api/<ProjectController>
        //[Authorize(Roles = "Admin")]
        [HttpGet("approvalStatus/{status}")]
        public async Task<IActionResult> GetByApprovalStatus( [FromQuery] int pageNumber, ProjectLevelApprovalStatus status)
        {
            var result = await _projectService.GetByApprovalStatus(pageNumber, status);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result);
        }

        // GET api/<ProjectController>/5
        //[Authorize(Roles = "User")]
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetByProjectId(string projectId)
        {
            var result = await _projectService.GetByProjectId(projectId);

            return Ok(result);
        }


        // POST api/<ProjectController>
        //[Authorize(Roles = "User")]
        [HttpPost("createProject")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectRequestDto projectRequstDto)
        {
           var result =  await _projectService.CreateProject(projectRequstDto);

            return Ok(result);
        }

        // PUT api/<ProjectController>/5
        //[Authorize(Roles = "User")]
        [HttpPut("update/{projectId}")]
        public async Task<IActionResult> UpdateProject(string projectId, [FromBody] ProjectUpdateDto projectUpdateDto)
        {
            var result = await _projectService.UpdateProject(projectId, projectUpdateDto);

            return Ok(result);
        }

        // PUT api/<ProjectController>/5
        //[Authorize(Roles = "User")]
        [HttpPut("serviceProviderProjectUpdate/{projectId}")]
        public async Task<IActionResult> ServiceProviderProjectUpdate(string projectId, [FromBody] ProjectServiceProviderUpdateDto projectUpdateDto)
        {
            var result = await _projectService.ServiceProviderProjectUpdate(projectId, projectUpdateDto);

            return Ok(result);
        }

        // PUT api/<ProjectController>/5
        //[Authorize(Roles = "User")]
        [HttpPut("addServiceProvider/{projectId}")]
        public async Task<IActionResult> AddServiceProvider(string projectId, [FromBody] SelectServiceProviderDto serviceProviderDto)
        {
            var result = await _projectService.AddServiceProvider(projectId, serviceProviderDto);

            return Ok(result);
        }

        // PUT api/<ProjectController>/5
        //[Authorize(Roles = "User")]
        [HttpPut("adminProjectUpdate/{projectId}")]
        public async Task<IActionResult> AdminProjectUpdate(string projectId, [FromBody] ProjectAdminUpdateDto projectUpdateDto)
        {
            var result = await _projectService.AdminProjectUpdate(projectId, projectUpdateDto);

            return Ok(result);
        }

        // DELETE api/<ProjectController>/5
        //[Authorize(Roles = "User")]
        [HttpDelete("delete/{projectId}")]
        public async Task<IActionResult> DeleteProject(string projectId)
        {
            var result = await _projectService.DeleteProject(projectId);

            return Ok(result);
        }

        // [Authorize]
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
