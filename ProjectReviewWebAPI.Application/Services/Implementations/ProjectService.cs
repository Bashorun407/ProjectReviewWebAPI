using AutoMapper;
using Microsoft.AspNetCore.Http;
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

namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IPhotoService _photoService;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ProjectService> logger, IEmailService emailService, IUserService userService, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
            _userService = userService;
            _photoService = photoService;
        }

        public async Task<StandardResponse<ProjectResponseDto>> AddServiceProvider(string projectId, SelectServiceProviderDto serviceProviderDto)
        {
            //Check if username exists in User database
            var userExists = await _unitOfWork.UserRepository.GetById(serviceProviderDto.ServiceProviderId, false);
            if (userExists == null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"User with id: {serviceProviderDto.ServiceProviderId} does not exist", 99);
            }

            var projectExist = await _unitOfWork.ProjectRepository.GetByProjectId(projectId, false);

            if (projectExist == null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"Project with id: {projectId} does not exist", 99);
            }

            var updatedEntity = _mapper.Map(serviceProviderDto, projectExist);
            //This project will be updated
            _unitOfWork.ProjectRepository.Update(updatedEntity);
            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"A Service provider has been added to project with project-id: {projectId} ");

            //Returning a ProjectResponseDto
            var projectDto = _mapper.Map<ProjectResponseDto>(updatedEntity);

            return StandardResponse<ProjectResponseDto>.Success("Project was updated successfully", projectDto, 200);

        }

        public async Task<StandardResponse<ProjectResponseDto>> AdminProjectUpdate(string id, ProjectAdminUpdateDto projectUpdateDto)
        {
            //var checkProject = await _unitOfWork.ProjectRepository.GetByProjectId
            var projectExists = await _unitOfWork.ProjectRepository.GetByProjectId(id, false);


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

            return StandardResponse<ProjectResponseDto>.Success("Project was updated successfully", projectDto, 200);
        }

        public async Task<StandardResponse<ProjectResponseDto>> CreateProject(ProjectRequestDto projectRequestDto)
        {
            _logger.LogInformation("Creating a project");
            //Check if there is a user by projectOwnerId from the projectRequestDto
            var user = await _unitOfWork.UserRepository.GetByUserId(projectRequestDto.ProjectOwnerId, false);

            if (user == null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"There is no user with: {projectRequestDto.ProjectOwnerId}", 99);
            }
            var project = _mapper.Map<Project>(projectRequestDto);

            //setting unique projectId
            //project.ProjectId = Utilities.GenerateUniqueId();
            project.JobAcceptanceStatus = JobAcceptanceStatus.NOT_ACCEPTED;
            project.ProjectStartApproval = ProjectStartApproval.NOT_APPROVED;
            project.ProjectLevelApprovalStatus = ProjectLevelApprovalStatus.NOT_SATISFIED;
            project.ProjectCompletionStatus = ProjectCompletionStatus.Pending;
           
            await _unitOfWork.ProjectRepository.CreateAsync(project);
            _logger.LogInformation("Saving new project to database");
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($"Project with project Id: {project.ProjectId} successfully saved to database");

            //Sends email notification to projectOwner that project has been created
            //var productOwner = await _unitOfWork.UserRepository.GetById(project.ProjectOwnerId, false);
            var owner = _mapper.Map<User>(user);

            _emailService.SendEmailAsync(owner.Email, "Project Creation Notification", $"Dear {owner.LastName}, {owner.FirstName},\nYou have successfully created a project with project-id: {project.ProjectId}.\nThank you for your patronage.");


            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            return StandardResponse<ProjectResponseDto>.Success("Project successfully created", projectDto, 201);
        }

        public async Task<StandardResponse<ProjectResponseDto>> DeleteProject(string projectId)
        {
            //var project = await _unitOfWork.ProjectRepository.GetById(id, false);
            var project = await _unitOfWork.ProjectRepository.GetByProjectId(projectId, false);

            if(project == null)
            {
                return StandardResponse<ProjectResponseDto>.Failed($"Project with id: {projectId} does not exist", 99);
            }

            _logger.LogInformation("Project is about to be deleted");
            _unitOfWork.ProjectRepository.Delete(project);
            await _unitOfWork.SaveAsync();
            _logger.LogInformation($" Project with project id: {project.Id} has been deleted");

            var projectDto = _mapper.Map<ProjectResponseDto>(project);

            return StandardResponse<ProjectResponseDto>.Success("Project was deleted successfully", projectDto, 200);
        }


        public async Task<StandardResponse<PagedList<ProjectResponseDto>>> GetAllProjectsAsync(ProjectRequestInputParameter parameter)
        {

            var result = await _unitOfWork.ProjectRepository.GetAll(parameter, false);

            if(!result.Any())
            {
                return StandardResponse<PagedList<ProjectResponseDto>>.Failed($"There are no projects yet", 99);
            }

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);

            var pagedList = new PagedList<ProjectResponseDto>(projectsDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<ProjectResponseDto>>.Success($"All projects", pagedList, 200);
        }

        public async Task<StandardResponse<PagedList<ProjectResponseDto>>> GetByApprovalStatus(ProjectRequestInputParameter parameter)
        {

            var result = await _unitOfWork.ProjectRepository.GetByApprovalStatus(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<ProjectResponseDto>>.Failed($"There are no projects by this approval status: {parameter.SearchTerm} yet", 99);
            }
            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);
            var pagedList = new PagedList<ProjectResponseDto>(projectsDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<ProjectResponseDto>>.Success($"Projects by Approval status", pagedList, 200);
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

        public async Task<StandardResponse<PagedList<ProjectResponseDto>>> GetByProjectName(ProjectRequestInputParameter parameter)
        {

            var result = await _unitOfWork.ProjectRepository.GetByProjectName(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<ProjectResponseDto>>.Failed($"There are no projects by this name: {parameter.SearchTerm} yet", 99);
            }

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);
            var pagedList = new PagedList<ProjectResponseDto>(projectsDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<ProjectResponseDto>>.Success("Projects by project name ", pagedList, 200);
        }

        public async Task<StandardResponse<PagedList<ProjectResponseDto>>> GetByProjectOwnerIdAsync(ProjectRequestInputParameter parameter)
        {
            var result = await _unitOfWork.ProjectRepository.GetByProjectOwnerId(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<ProjectResponseDto>>.Failed($"There are no projects by project ownerId {parameter.SearchTerm} yet", 99);
            }

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);
            var pagedList = new PagedList<ProjectResponseDto>(projectsDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<ProjectResponseDto>>.Success("Projects by project name ", pagedList, 200);
        }

        public async Task<StandardResponse<PagedList<ProjectResponseDto>>> GetByProjectStatus(ProjectRequestInputParameter parameter)
        {


            var result = await _unitOfWork.ProjectRepository.GetByProjectStatus(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<ProjectResponseDto>>.Failed($"There are no projects by status: {parameter.SearchTerm} yet", 99);
            }

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);
            var pagedList = new PagedList<ProjectResponseDto>(projectsDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<ProjectResponseDto>>.Success($"All projects by specified criteria ", pagedList, 200);
        }


        public async Task<StandardResponse<PagedList<ProjectResponseDto>>> GetProjectsByCategory(ProjectRequestInputParameter parameter)
        {

            var result = await _unitOfWork.ProjectRepository.GetByCategory(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<ProjectResponseDto>>.Failed($"There are no projects by category: {parameter.SearchTerm} yet", 99);
            }

            var projectsDto = _mapper.Map<IEnumerable<ProjectResponseDto>>(result);
            var pagedList = new PagedList<ProjectResponseDto>(projectsDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<ProjectResponseDto>>.Success($"All projects by category: {parameter.SearchTerm} ", pagedList, 200);
        }

        public async Task<StandardResponse<ProjectResponseDto>> ServiceProviderProjectUpdate(string id, ProjectServiceProviderUpdateDto projectUpdateDto)
        {

            var projectExists = await _unitOfWork.ProjectRepository.GetByProjectId(id, false);


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

        public async Task<StandardResponse<ProjectResponseDto>> UpdateProject(string id, ProjectUpdateDto projectUpdateDto)
        {
            //var checkProject = await _unitOfWork.ProjectRepository.GetByProjectId
            var projectExists = await _unitOfWork.ProjectRepository.GetByProjectId(id, false);
            
            
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


            //Sends email notification to projectOwner that project has been completed
            var productOwner = await _unitOfWork.UserRepository.GetByUserId(projectExists.ProjectOwnerId, false);
            _emailService.SendEmailAsync(productOwner.Email, "Project Completion Notification", $"Dear {productOwner.LastName}, {productOwner.FirstName},\nYour project with project id: {projectExists.ProjectId} has been completed successfully.");

            return StandardResponse<ProjectResponseDto>.Success("Project was updated successfully", projectDto, 200);
        }

        public async Task<StandardResponse<(bool, string)>> UploadProfileImage(string projectId, IFormFile file)
        {
            var result = await _unitOfWork.ProjectRepository.GetByProjectId(projectId, false);

            if (result is null)
            {
                _logger.LogWarning($"No project with id {projectId}");

                return StandardResponse<(bool, string)>.Failed("project not found", 99);

            }

            var project = _mapper.Map<Project>(result);

            string url = _photoService.AddPhotoForUser(file);

            if (string.IsNullOrWhiteSpace(url))

                return StandardResponse<(bool, string)>.Failed("Failed to upload", 500);

            project.CoverImage = url;

            _unitOfWork.ProjectRepository.Update(project);
            await _unitOfWork.SaveAsync();
            return StandardResponse<(bool, string)>.Success("Successfully uploaded image", (true, url), 204);

        }
    }
}
