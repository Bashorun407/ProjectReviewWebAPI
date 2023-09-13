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

        public async Task<IEnumerable<Project>> GetAll(bool trackChanges)
        {
           var result = FindAll(trackChanges);

            return result;
        }

        public async Task<IEnumerable<Project>> GetByApprovalStatus(ProjectApprovalStatus approvalStatus, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectApprovalStatus.Equals(approvalStatus), trackChanges).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Project>> GetByCategory(Category category, bool trackChanges)
        {
            var result = await FindByCondition(c => c.Category.Equals(category), trackChanges).ToListAsync();

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


        public async Task<IEnumerable<Project>> GetByProjectName(string name, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectName.Equals(name), trackChanges).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Project>> GetByProjectOwnerId(string projectOwnerId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectOwnerId.Equals(projectOwnerId), trackChanges).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Project>> GetByProjectStatus(ProjectCompletionStatus projectStatus, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectCompletionStatus.Equals(projectStatus), trackChanges).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Project>> GetByServiceProvider(string serviceProviderId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ServiceProviderId.Equals(serviceProviderId), trackChanges).ToListAsync();

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

                public Task<PagedList<Project>> GetByApprovalStatus(ProjectRequestInputParameter parameter)
                {
                    throw new NotImplementedException();
                }

                public async Task<PagedList<Project>> GetByCategory(ProjectRequestInputParameter parameter)
                {
                    var result = await _projects.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .Where(c=> c.Category.Equals(parameter.SearchTerm))
                        .ToListAsync();

                    var count = await _projects.CountAsync();

                    return new PagedList<Project>(result, count, parameter.PageNumber, parameter.PageSize);
                }

                public async Task<Project> GetById(int id)
                {
                    return await _projects.FindAsync(id);
                }

                public async Task<Project> GetByProjectId(string projectId)
                {
                    return  await _projects.FindAsync(projectId);
                }

                public async Task<PagedList<Project>> GetByProjectName(ProjectRequestInputParameter parameter)
                {
                    var result = await _projects.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .Where(c=> c.ProjectName.Equals(parameter.SearchTerm))
                        .ToListAsync();
                    var count = await _projects.CountAsync();

                    return new PagedList<Project>(result, count, parameter.PageNumber, parameter.PageSize);
                }

                public async Task<PagedList<Project>> GetByProjectOwnerId(ProjectRequestInputParameter parameter)
                {
                    var result = await _projects.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .Where(c=> c.ProjectOwnerId.Equals(parameter.SearchTerm))
                        .ToListAsync();

                    var count = await _projects.CountAsync();

                    return new PagedList<Project>(result, count, parameter.PageNumber, parameter.PageSize);
                }

                public async Task<PagedList<Project>> GetByProjectStatus(ProjectRequestInputParameter parameter)
                {
                    var result = await _projects.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .Where(c => c.ProjectStatus.Equals(parameter.SearchTerm))
                        .ToListAsync();

                    var count = await _projects.CountAsync();

                    return new PagedList<Project>(result, count, parameter.PageNumber, parameter.PageSize);
                }

                public async Task<PagedList<Project>> GetByServiceProviderId(ProjectRequestInputParameter parameter)
                {
                    var result = await _projects.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                        .Where(c=> c.ServiceProviderId.Equals(parameter.SearchTerm))
                        .ToListAsync();

                    var count = await _projects.CountAsync();

                    return new PagedList<Project>(result, count, parameter.PageNumber, parameter.PageSize);
                }*/
    }
}
