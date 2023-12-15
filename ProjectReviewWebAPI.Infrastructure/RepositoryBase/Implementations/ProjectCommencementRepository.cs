using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Implementations
{
    public class ProjectCommencementRepository : Repository<ProjectCommencementDetail>, IProjectCommencementRepository
    {
        private readonly DbSet<ProjectCommencementDetail> _projectCommencement;
        private readonly ApplicationDbContext _context;

        public ProjectCommencementRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _projectCommencement = _context.Set<ProjectCommencementDetail>();
        }

        public Task<PagedList<ProjectCommencementDetail>> GetAllAsync(ProjectCommencementRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindAll(trackChanges)
                .OrderBy(p => p.CreatedAt)
                .AsQueryable();

            return PagedList<ProjectCommencementDetail>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public Task<PagedList<ProjectCommencementDetail>> GetByApprovalStatus(ProjectCommencementRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(p => p.ProjectLevelApprovalStatus.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(p => p.CreatedAt)
                .AsQueryable();

            return PagedList<ProjectCommencementDetail>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        

        public Task<ProjectCommencementDetail> GetById(ProjectCommencementRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(p => p.Id.Equals(parameter.SearchTerm), trackChanges)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<ProjectCommencementDetail> GetByProjectId(ProjectCommencementRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(p => p.ProjectId.Equals(parameter.SearchTerm), trackChanges)
                .SingleOrDefaultAsync();

            return result;
        }

        public Task<PagedList<ProjectCommencementDetail>> GetByProjectStatus(ProjectCommencementRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(p => p.ProjectCompletionStatus.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(p => p.CreatedAt)
                .AsQueryable();

            return PagedList<ProjectCommencementDetail>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public Task<PagedList<ProjectCommencementDetail>> GetByServiceProviderId(ProjectCommencementRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(p => p.ServiceProviderId.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(p => p.CreatedAt)
                .AsQueryable();

            return PagedList<ProjectCommencementDetail>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }
    }
}
