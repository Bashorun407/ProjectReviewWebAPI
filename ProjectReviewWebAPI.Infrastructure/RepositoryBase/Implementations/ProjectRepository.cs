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


        public async Task<PagedList<Project>> GetByCategory(ProjectRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(c => c.Category.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(x => x.ProjectName)
                .AsQueryable();

            return await PagedList<Project>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<Project> GetById(int id, bool trackChanges)
        {
            var result = await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

            return result;
        }

        public async Task<Project> GetByProjectId(string projectId, bool trackChanges)
        {
            var result =  FindByCondition(c=> c.Id.Equals(projectId), trackChanges).SingleOrDefault();

            return result;
        }


        public async Task<PagedList<Project>> GetByProjectName(ProjectRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindByCondition(c => c.ProjectName.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(x => x.ProjectName)
                .AsQueryable();

            return await PagedList<Project>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<PagedList<Project>> GetByProjectOwnerId(ProjectRequestInputParameter parameter , bool trackChanges)
        {
            var result = FindByCondition(c => c.ProjectOwnerId.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(x => x.ProjectName)
                .AsQueryable();

            return await PagedList<Project>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }



    }
}
