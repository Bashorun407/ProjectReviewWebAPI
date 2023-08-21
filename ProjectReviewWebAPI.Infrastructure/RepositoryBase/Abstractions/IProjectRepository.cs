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
        Task<PagedList<Project>> GetProjectByProjectName(ProjectRequestInputParameter parameterName);
        Task<Project> GetProjectById(string projectId);
        Task<PagedList<Project>> GetProjectByCategory(ProjectRequestInputParameter category);
    }
}
