using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using ProjectReviewWebAPI.Infrastructure.UoW.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Infrastructure.UoW.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private IClienttRepository clienttRepository;
        private ICommentRepository commentRepository;
        private IProjectRepository projectRepository; 
        private IRatingRepository ratingRepository;
        private IUserRepository serviceProvoderRepository;
        private ITransactionRepository transactionRepository;



        //Implementation starts here....

        public IClienttRepository ClienttRepository => throw new NotImplementedException();

        public ICommentRepository CommentRepository => throw new NotImplementedException();

        public IProjectRepository ProjectRepository => throw new NotImplementedException();

        public IRatingRepository RatingRepository => throw new NotImplementedException();

        public IUserRepository ServiceProvoderRepository => throw new NotImplementedException();

        public ITransactionRepository TransactionRepository => throw new NotImplementedException();

        public Task SaveAsyn()
        {
            throw new NotImplementedException();
        }
    }
}
