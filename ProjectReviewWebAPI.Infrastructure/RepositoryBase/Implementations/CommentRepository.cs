using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Implementations
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly DbSet<Comment> _comments;
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _comments = context.Set<Comment>();
        }

        public async Task<PagedList<Comment>> GethAll(CommentRequestInputParameter parameter, bool trackChanges)
        {
            var result = FindAll(trackChanges).OrderBy(x => x.CreatedAt);
           return await PagedList<Comment>.GetPagination(result,parameter.PageNumber,parameter.PageSize);
        }
        public async Task<PagedList<Comment>> GetAll(CommentRequestInputParameter parameter, bool trackChanges)
        {
            // Assuming FindAll returns an IQueryable<Comment>
            var result = FindAll(trackChanges)
                .OrderBy(x => x.CreatedAt)
                .AsQueryable(); // Ensure it's IQueryable for further operations

            return await PagedList<Comment>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }


        public async Task<PagedList<Comment>> GetCommentByUsername(CommentRequestInputParameter parameter, bool trackChanges)
        {
           var result = FindByCondition(c => c.UserId.Equals(parameter.SearchTerm), trackChanges)
                .OrderBy(x => x.CreatedAt)
                .AsQueryable();

            return await PagedList<Comment>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }
    }
}
