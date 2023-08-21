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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly DbSet<Project> _projects;

        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _projects = context.Set<Project>();
        }

        public async Task<PagedList<Project>> GetAllProjects(ProjectRequestInputParameter parameter)
        {
            var result = await _projects.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                .ToListAsync();

            var count = await _projects.CountAsync();

            return new PagedList<Project>(result, count, parameter.PageNumber, parameter.PageSize);

        }

        public async Task<PagedList<Project>> GetProjectByCategory(ProjectRequestInputParameter parameter)
        {
            var result = await _projects.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                .ToListAsync();

            var count = await _projects.CountAsync();

            return new PagedList<Project>(result, count, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<Project> GetProjectById(string projectId)
        {
            return  await _projects.FindAsync(projectId);
        }

        public Task<PagedList<Project>> GetProjectByProjectName(ProjectRequestInputParameter parameterName)
        {
            throw new NotImplementedException();
        }
    }
}
