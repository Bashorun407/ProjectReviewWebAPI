using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<PagedList<Project>> GetAllProjects(ProjectRequestInputParameter parameter);
        Task<PagedList<Project>> GetByProjectName(ProjectRequestInputParameter parameterName);
        Task<Project> GetById(int id);
        Task<Project> GetByProjectId(string projectId);
        Task<PagedList<Project>> GetByCategory(ProjectRequestInputParameter category);
        Task<PagedList<Project>> GetByProjectOwnerId(ProjectRequestInputParameter parameter);
        Task<PagedList<Project>> GetByServiceProviderId(ProjectRequestInputParameter parameter);
        Task<PagedList<Project>> GetByProjectStatus(ProjectRequestInputParameter parameter);
        Task<PagedList<Project>> GetByApprovalStatus(ProjectRequestInputParameter parameter);
    }
}
