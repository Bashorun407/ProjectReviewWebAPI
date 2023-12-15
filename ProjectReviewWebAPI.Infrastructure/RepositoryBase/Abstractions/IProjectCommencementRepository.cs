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
    public interface IProjectCommencementRepository : IRepository<ProjectCommencementDetail>
    {
        Task<PagedList<ProjectCommencementDetail>> GetAllAsync(ProjectCommencementRequestInputParameter parameter, bool trackChanges);
        Task<ProjectCommencementDetail> GetById(ProjectCommencementRequestInputParameter parameter, bool trackChanges);
        Task<ProjectCommencementDetail> GetByProjectId(ProjectCommencementRequestInputParameter parameter, bool trackChanges);
     Task<PagedList<ProjectCommencementDetail>> GetByServiceProviderId(ProjectCommencementRequestInputParameter parameter, bool trackChanges);

    Task<PagedList<ProjectCommencementDetail>> GetByProjectStatus(ProjectCommencementRequestInputParameter parameter, bool trackChanges);
    Task<PagedList<ProjectCommencementDetail>> GetByApprovalStatus(ProjectCommencementRequestInputParameter parameter, bool trackChanges);
    }
}
