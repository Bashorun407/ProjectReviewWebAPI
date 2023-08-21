using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.UoW.Abstraction
{
    public interface IUnitOfWork
    {
        public IClienttRepository ClienttRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IRatingRepository RatingRepository { get; }
        public IUserRepository ServiceProvoderRepository { get; }
        public ITransactionRepository TransactionRepository { get; }

        Task SaveAsyn();
    }
}
