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

        public async Task<IEnumerable<Comment>> GetAll(CommentRequestInputParameter parameter, bool trackChanges)
        {
            var result =  FindAll(trackChanges).Skip((parameter.PageNumber - 1) * parameter.PageSize)
            .Take(parameter.PageSize);

            return result;
        }


        public async Task<IEnumerable<Comment>> GetCommentByUsername(string username, bool trackChanges)
        {
           var result = await FindByCondition(c => c.UserName.Equals(username), trackChanges).ToListAsync();

            return result;
        }

        /*
        public async Task<PagedList<Comment>> GetCommentByUsername(CommentRequestInputParameter parameter)
        {
            var result = await _comments.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize)
                .Where(c=> c.UserName.Equals(parameter.SearchTerm))
                .ToListAsync();

            var count = await _comments.CountAsync();

            return new PagedList<Comment>(result, count, parameter.PageNumber, parameter.PageSize);
        }
*/
    }
}
