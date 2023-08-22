using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
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
        Task<StandardResponse<ProjectResponseDto>> CreateProject(ProjectResponseDto projectResponseDto);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetAllProjectsAsync(ProjectRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetProjectsByProjectOwnerIdAsync(ProjectRequestInputParameter parameter);
        Task<StandardResponse<(IEnumerable<ProjectResponseDto> projects, MetaData pagingData)>> GetProjectsByServiceProviderIdAsync(ProjectRequestInputParameter paramter);
        Task<StandardResponse<ProjectResponseDto>> GetProjectByProjectId(string projectId);
        Task<StandardResponse<ProjectResponseDto>> UpdateProject(int id, ProjectRequestDto projectRequestDto);
        Task<StandardResponse<ProjectResponseDto>> DeleteProject(int id);
    }
}
