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
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetAllProjectsAsync();
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetProjectsByCategory(Category category);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectName(string projectName);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectOwnerIdAsync(string projectOwnerId);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByServiceProviderIdAsync(string serviceProviderId);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByProjectStatus(ProjectCompletionStatus completionStatus);
        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByApprovalStatus(ProjectApprovalStatus approvalStatus);
/*        Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetAllCommentsByProjectId(string projectId);*/
        Task<StandardResponse<ProjectResponseDto>> GetById(int id);
        Task<StandardResponse<ProjectResponseDto>> GetByProjectId(string projectId);
        Task<StandardResponse<ProjectResponseDto>> UpdateProject(int id, ProjectUpdateDto projectUpdateDto);
        Task<StandardResponse<ProjectResponseDto>> DeleteProject(int id);


/*        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetAllProjectsAsync(ProjectRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetProjectsByCategory(ProjectRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetByProjectName(ProjectRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetByProjectOwnerIdAsync(ProjectRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetByServiceProviderIdAsync(ProjectRequestInputParameter paramter);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetByProjectStatus(ProjectRequestInputParameter paramter);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetByApprovalStatus(ProjectRequestInputParameter parameter);*/
    }
}
