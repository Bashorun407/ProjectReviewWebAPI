using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
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

        Task<PagedList<Project>> GetAll(ProjectRequestInputParameter parameter, bool trackChanges);
        Task<PagedList<Project>> GetByProjectName(ProjectRequestInputParameter parameter, bool trackChanges);
        Task<Project> GetById(int id, bool trackChanges);
        Task<Project> GetByProjectId(string projectId, bool trackChanges);
        Task<PagedList<Project>> GetByProjectOwnerId(ProjectRequestInputParameter parameter, bool trackChanges);
        Task<PagedList<Project>> GetByServiceProviderId(ProjectRequestInputParameter parameter, bool trackChanges);
        Task<PagedList<Project>> GetByCategory(ProjectRequestInputParameter parameter, bool trackChanges);
        Task<PagedList<Project>> GetByProjectStatus(ProjectRequestInputParameter parameter, bool trackChanges);
        Task<PagedList<Project>> GetByApprovalStatus(ProjectRequestInputParameter parameter, bool trackChanges);


    }
}
