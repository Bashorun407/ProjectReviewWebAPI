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
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<PagedList<Comment>> GetAllComments(CommentRequestInputParameter parameter);
        //Task<PagedList<Comment>> GetAllCommentByCondition(CommentRequestInputParameter parameter);
        Task<PagedList<Comment>> GetCommentByProjectId(CommentRequestInputParameter parameter);
        Task<PagedList<Comment>> GetCommentByUsername(CommentRequestInputParameter parameter);

    }
}
