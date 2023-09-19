using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Enums;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Abstractions
{
    public interface IProjectService
    {
        Task<StandardResponse<ProjectResponseDto>> CreateProject(ProjectRequestDto projectRequestDto);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetAllProjectsAsync(int pageNumber);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetProjectsByCategory(int pageNumber, Category category);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectName(int pageNumber, string projectName);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectOwnerIdAsync(string projectOwnerId);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByServiceProviderIdAsync(string serviceProviderId);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectStatus(int pageNumber, ProjectCompletionStatus completionStatus);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByApprovalStatus(int pageNumber, ProjectLevelApprovalStatus approvalStatus);
        Task<StandardResponse<ProjectResponseDto>> GetById(int id);
        Task<StandardResponse<ProjectResponseDto>> GetByProjectId(string projectId);
        Task<StandardResponse<ProjectResponseDto>> UpdateProject(string id, ProjectUpdateDto projectUpdateDto);
        Task<StandardResponse<ProjectResponseDto>> ServiceProviderProjectUpdate(string id, ProjectServiceProviderUpdateDto projectUpdateDto);
        Task<StandardResponse<ProjectResponseDto>> AdminProjectUpdate(string id, ProjectAdminUpdateDto projectUpdateDto);
        Task<StandardResponse<ProjectResponseDto>> DeleteProject(string id);

    }
}
