using Microsoft.AspNetCore.Http;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
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
        Task<StandardResponse<ProjectResponseDto>> AddServiceProvider(string projectId, SelectServiceProviderDto serviceProviderDto);
        Task<StandardResponse<PagedList<ProjectResponseDto>>> GetAllProjectsAsync(ProjectRequestInputParameter parameter);
        Task<StandardResponse<PagedList<ProjectResponseDto>>> GetProjectsByCategory(ProjectRequestInputParameter parameter);
        Task<StandardResponse<PagedList<ProjectResponseDto>>> GetByProjectName(ProjectRequestInputParameter parameter);
        Task<StandardResponse<PagedList<ProjectResponseDto>>> GetByProjectOwnerIdAsync(ProjectRequestInputParameter parameter);
        //Task<StandardResponse<IEnumerable<ProjectResponseDto>>> GetByServiceProviderIdAsync(string serviceProviderId);
        //Task<StandardResponse<PagedList<ProjectResponseDto>>> GetByProjectStatus(ProjectRequestInputParameter parameter);
        //Task<StandardResponse<PagedList<ProjectResponseDto>>> GetByApprovalStatus(ProjectRequestInputParameter parameter);
        //Task<StandardResponse<ProjectResponseDto>> GetById(int id);
        Task<StandardResponse<ProjectResponseDto>> GetByProjectId(string projectId);
        Task<StandardResponse<ProjectResponseDto>> UpdateProject(string id, ProjectUpdateDto projectUpdateDto);
        Task<StandardResponse<(bool, string)>> UploadProfileImage(string userId, IFormFile file);
        //Task<StandardResponse<ProjectResponseDto>> ServiceProviderProjectUpdate(string id, ProjectServiceProviderUpdateDto projectUpdateDto);
        Task<StandardResponse<ProjectResponseDto>> AdminProjectUpdate(string id, ProjectAdminUpdateDto projectUpdateDto);
        Task<StandardResponse<ProjectResponseDto>> DeleteProject(string id);

    }
}
