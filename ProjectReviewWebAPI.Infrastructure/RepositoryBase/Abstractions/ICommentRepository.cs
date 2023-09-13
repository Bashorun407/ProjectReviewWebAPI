﻿using ProjectReviewWebAPI.Domain.Entities;
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

        Task<IEnumerable<Comment>> GetAll(CommentRequestInputParameter parameter, bool trackChanges);
        Task<IEnumerable<Comment>> GetCommentByProjectId(string projectId, bool trackChanges);
        Task<IEnumerable<Comment>> GetCommentByUsername(string username, bool trackChanges);

    }
}
