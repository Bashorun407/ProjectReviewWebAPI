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

        Task<IEnumerable<Project>> GetAll(ProjectRequestInputParameter parameter, bool trackChanges);
        Task<IEnumerable<Project>> GetByProjectName(ProjectRequestInputParameter parameter, string name, bool trackChanges);
        Task<Project> GetById(int id, bool trackChanges);
        Task<Project> GetByProjectId(string projectId, bool trackChanges);
        Task<IEnumerable<Project>> GetByProjectOwnerId(string projectOwnerId, bool trackChanges);
        Task<IEnumerable<Project>> GetByServiceProvider(string serviceProviderId, bool trackChanges);
        Task<IEnumerable<Project>> GetByCategory(ProjectRequestInputParameter parameter, Category category, bool trackChanges);
        Task<IEnumerable<Project>> GetByProjectStatus(ProjectRequestInputParameter parameter, ProjectCompletionStatus projectStatus, bool trackChanges);
        Task<IEnumerable<Project>> GetByApprovalStatus(ProjectRequestInputParameter parameter, ProjectLevelApprovalStatus approvalStatus, bool trackChanges);


    }
}
