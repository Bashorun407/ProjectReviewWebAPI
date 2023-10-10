using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Domain.Enums;
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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Project> _projects;

        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _projects = context.Set<Project>();
        }

        public async Task<PagedList<Project>> GetAll(ProjectRequestInputParameter parameter, bool trackChanges)
        {
           var result = FindAll(trackChanges)
                        .OrderBy(x => x.CreatedAt)
                        .AsQueryable(); //This ensures the data is queryable for further operations

            return await PagedList<Project>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<IEnumerable<Project>> GetByApprovalStatus(ProjectRequestInputParameter parameter, ProjectLevelApprovalStatus approvalStatus, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectLevelApprovalStatus.Equals(approvalStatus), trackChanges).Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Project>> GetByCategory(ProjectRequestInputParameter parameter, Category category, bool trackChanges)
        {
            var result = await FindByCondition(c => c.Category.Equals(category), trackChanges).Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize).ToListAsync();

            return result;
        }

        public async Task<Project> GetById(int id, bool trackChanges)
        {
            var result = await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

            return result;
        }

        public async Task<Project> GetByProjectId(string projectId, bool trackChanges)
        {
            var result =  FindByCondition(c=> c.ProjectId.Equals(projectId), trackChanges).SingleOrDefault();

            return result;
        }


        public async Task<IEnumerable<Project>> GetByProjectName(ProjectRequestInputParameter parameter, string name, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectName.Equals(name), trackChanges).Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Project>> GetByProjectOwnerId(string projectOwnerId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectOwnerId.Equals(projectOwnerId), trackChanges).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Project>> GetByProjectStatus(ProjectRequestInputParameter parameter, ProjectCompletionStatus projectStatus, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectCompletionStatus.Equals(projectStatus), trackChanges).Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Project>> GetByServiceProvider(string serviceProviderName, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ServiceProviderUsername.Equals(serviceProviderName), trackChanges).ToListAsync();

            return result;
        }

        /*public async Task<IEnumerable<Project>> GetCommentsByProjectId(string projectId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectId.Equals(projectId), trackChanges).Include(c => c.Comments).ToListAsync();

            return result;
        }*/


        /*        public async Task<PagedList<Project>> GetAllProjects(ProjectRequestInputParameter parameter)
                {
                    var result = await _projects.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .ToListAsync();

                    var count = await _projects.CountAsync();

                    return new PagedList<Project>(result, count, parameter.PageNumber, parameter.PageSize);

                }
        */
    }
}
