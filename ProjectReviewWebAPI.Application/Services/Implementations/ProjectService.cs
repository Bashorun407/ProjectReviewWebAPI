using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Infrastructure.UoW.Abstraction;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using ProjectReviewWebAPI.Utility.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectService> logger, IEmailService emailService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
            _userService = userService;
        }

        public async Task<StandardResponse<ProjectResponseDto>> CreateProject(ProjectRequestDto projectRequestDto)
        {
            _logger.LogInformation("Creating a project");
            var project = _mapper.Map<Project>(projectRequestDto);

            //setting unique projectId
            project.ProjectId = Utilities.GenerateUniqueId();

            await _unitOfWork.ProjectRepository.CreateAsync(project);
            _logger.LogInformation("Saving new project to database");
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"Project with project Id: {project.ProjectId} successfully saved to database");

            //Sends email notification to projectOwner that project has been created
            var productOwner = await _unitOfWork.UserRepository.GetById(project.ProjectOwnerId, false);
            var owner = _mapper.Map<User>(productOwner);

            _emailService.SendEmailAsync(owner.Email, "Project Creation Notification", $"Dear {owner.LastName}, {owner.FirstName},\nYou have successfully created a project with project-id: {project.ProjectId}.\nThank you for your patronage.");


            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            return StandardResponse<ProjectResponseDto>.Success("Project successfully created", projectDto, 201);
        }

        public async Task<StandardResponse<ProjectResponseDto>> DeleteProject(int id)
        {
            var project = await _unitOfWork.ProjectRepository.GetById(id, false);
            if(project is null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"Project with id: {id} does not exist", 99);
            }

            _logger.LogInformation("Project is about to be deleted");
            _unitOfWork.ProjectRepository.Delete(project);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($" Project with project id: {project.Id} has been deleted");

            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            return StandardResponse<ProjectResponseDto>.Success("Project was deleted successfully", projectDto, 200);
        }

/*        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetAllCommentsByProjectId(string projectId)
        {
            var result = await _unitOfWork.ProjectRepository.GetCommentsByProjectId(projectId, false);

            if(result is null)
            {
                return StandardResponse<IEnumerable<ProjectResponseDto>>.Failed($"There are no comments by project id: {projectId} yet", 99);
            }


            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("All comments on project specified", projectsDto, 200);
        }*/

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetAllProjectsAsync()
        {
            var result = await _unitOfWork.ProjectRepository.GetAll(false);

            if(result is null)
            {
                return StandardResponse<IEnumerable<ProjectResponseDto>>.Failed($"There are no projects yet", 99);
            }

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("All projects", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByApprovalStatus(ProjectApprovalStatus approvalStatus)
        {
            var result = await _unitOfWork.ProjectRepository.GetByApprovalStatus(approvalStatus, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("Projects by Approval status ", projectsDto, 200);
        }

        public async Task<StandardResponse<ProjectResponseDto>> GetById(int id)
        {
            var project = await _unitOfWork.ProjectRepository.GetById(id, false);

            if(project is null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"Project with id: {id} does not exist", 99);
            }
            
            var projectDto = _mapper.Map<ProjectResponseDto>(project);
            return StandardResponse<ProjectResponseDto>.Success($"Project with id: {id} found", projectDto, 200);
        }

        public async Task<StandardResponse<ProjectResponseDto>> GetByProjectId(string projectId)
        {
            var project = await _unitOfWork.ProjectRepository.GetByProjectId(projectId, false);

            if (project is null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"Project with id: {projectId} does not exist", 99);
            }

            var projectDto = _mapper.Map<ProjectResponseDto>(project);
            return StandardResponse<ProjectResponseDto>.Success($"Project with id: {projectId} found", projectDto, 200);

        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectName(string projectName)
        {
            var result = await _unitOfWork.ProjectRepository.GetByProjectName(projectName, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("Projects by project name ", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectOwnerIdAsync(string projectOwnerId)
        {
            var result = await _unitOfWork.ProjectRepository.GetByProjectOwnerId(projectOwnerId, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("Projects by project name ", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectStatus(ProjectCompletionStatus completionStatus)
        {
            var result = await _unitOfWork.ProjectRepository.GetByProjectStatus(completionStatus, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("Projects by completion status ", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByServiceProviderIdAsync(string serviceProviderId)
        {
            var result = await _unitOfWork.ProjectRepository.GetByServiceProvider(serviceProviderId, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("All projects by ", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetProjectsByCategory(Category category)
        {
            var result = await _unitOfWork.ProjectRepository.GetByCategory(category, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("All projects by ", projectsDto, 200);
        }

        public async Task<StandardResponse<ProjectResponseDto>> UpdateProject(int id, ProjectUpdateDto projectUpdateDto)
        {
            var projectExists = await _unitOfWork.ProjectRepository.GetById(id, false);
            if (projectExists is null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"Project with id: {id} does not exist", 99);
            }

            var updatedEntity = _mapper.Map(projectUpdateDto, projectExists);

            _logger.LogInformation("Project is about to be updated");
             _unitOfWork.ProjectRepository.Update(updatedEntity);
            await _unitOfWork.SaveAsync();
            
            _logger.LogInformation($" Project with project id: {updatedEntity.Id} has been updated");
            var projectDto = _mapper.Map<ProjectResponseDto>(updatedEntity);

            if (projectUpdateDto.ProjectCompletionStatus.Equals(ProjectCompletionStatus.Completed))
            {
                var productOwner = await _unitOfWork.UserRepository.GetByUserId(projectExists.ProjectOwnerId, false);

                //Sends email notification to projectOwner that project has been completed
                _emailService.SendEmailAsync(productOwner.Email, "Project Completion Notification", $"Dear {productOwner.LastName}, {productOwner.FirstName},\nYour project with project id: {projectExists.ProjectId} has been completed successfully.");
            }

            return StandardResponse<ProjectResponseDto>.Success("Project was updated successfully", projectDto, 200);
        }
    }
}
