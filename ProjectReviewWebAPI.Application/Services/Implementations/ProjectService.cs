using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
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

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
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

            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            _logger.LogInformation("Project is about to be deleted");
            _unitOfWork.ProjectRepository.Delete(project);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($" Project with project id: {project.Id} has been deleted");

            return StandardResponse<ProjectResponseDto>.Success("Project was deleted successfully", projectDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetAllProjectsAsync(ProjectRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ProjectRepository.GetAll(false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("All projects", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByApprovalStatus(ProjectRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ProjectRepository.GetByApprovalStatus(parameter.SearchTerm, false);

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

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectName(ProjectRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ProjectRepository.GetByProjectName(parameter.SearchTerm, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("Projects by project name ", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectOwnerIdAsync(ProjectRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ProjectRepository.GetByProjectOwnerId(parameter.SearchTerm, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("Projects by project name ", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectStatus(ProjectRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ProjectRepository.GetByProjectStatus(parameter.SearchTerm, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("Projects by completion status ", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByServiceProviderIdAsync(ProjectRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ProjectRepository.GetByServiceProvider(parameter.SearchTerm, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("All projects by ", projectsDto, 200);
        }

        public async Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetProjectsByCategory(ProjectRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ProjectRepository.GetByCategory(parameter.SearchTerm, false);

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            return StandardResponse<IEnumerable<ProjectResponseDto>>.Success("All projects by ", projectsDto, 200);
        }

        public async Task<StandardResponse<ProjectResponseDto>> UpdateProject(int id, ProjectRequestDto projectRequestDto)
        {
            var projectExists = _unitOfWork.ProjectRepository.GetById(id, false);
            if (projectExists is null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"Project with id: {id} does not exist", 99);
            }

            var project = _mapper.Map<Project>(projectRequestDto);

            _logger.LogInformation("Project is about to be updated");
             _unitOfWork.ProjectRepository.Update(project);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($" Project with project id: {project.Id} has been updated");
            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            return StandardResponse<ProjectResponseDto>.Success("Project was updated successfully", projectDto, 200);
        }
    }
}
