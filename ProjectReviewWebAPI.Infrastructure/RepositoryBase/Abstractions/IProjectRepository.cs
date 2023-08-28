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

        Task<IEnumerable<Project>> GetAll(bool trackChanges);
        Task<IEnumerable<Project>> GetByProjectName(string name, bool trackChanges);
        Task<Project> GetById(int id, bool trackChanges);
        Task<Project> GetByProjectId(string projectId, bool trackChanges);
        Task<IEnumerable<Project>> GetByProjectOwnerId(string projectOwnerId, bool trackChanges);
        Task<IEnumerable<Project>> GetByServiceProvider(string serviceProviderId, bool trackChanges);
        Task<IEnumerable<Project>> GetByCategory(string category, bool trackChanges);
        Task<IEnumerable<Project>> GetByProjectStatus(string projectStatus, bool trackChanges);
        Task<IEnumerable<Project>> GetByApprovalStatus(string approvalStatus, bool trackChanges);
 


        /*Task<PagedList<Project>> GetAllProjects(ProjectRequestInputParameter parameter);
        Task<PagedList<Project>> GetByProjectName(ProjectRequestInputParameter parameterName);
        Task<Project> GetById(int id);
        Task<Project> GetByProjectId(string projectId);
        Task<PagedList<Project>> GetByCategory(ProjectRequestInputParameter category);
        Task<PagedList<Project>> GetByProjectOwnerId(ProjectRequestInputParameter parameter);
        Task<PagedList<Project>> GetByServiceProviderId(ProjectRequestInputParameter parameter);
        Task<PagedList<Project>> GetByProjectStatus(ProjectRequestInputParameter parameter);
        Task<PagedList<Project>> GetByApprovalStatus(ProjectRequestInputParameter parameter);*/
    }
}
