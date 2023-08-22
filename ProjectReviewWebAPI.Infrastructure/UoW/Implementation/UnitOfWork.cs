using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Implementations;
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
        private ICommentRepository _commentRepository;
        private IProjectRepository _projectRepository; 
        private IRatingRepository _ratingRepository;
        private IUserRepository _userRepository;
        private ITransactionRepository _transactionRepository;

        private readonly ApplicationDbContext _context;

        //Implementation starts here....


        public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_context);

        public IProjectRepository ProjectRepository => _projectRepository ?? new ProjectRepository(_context);

        public IRatingRepository RatingRepository => _ratingRepository ?? new RatingRepository(_context);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

        public ITransactionRepository TransactionRepository => _transactionRepository ?? new TransactionRepository(_context);

        public void Dispose()
        {
           _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
