﻿using Microsoft.EntityFrameworkCore;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.Persistence;
using ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Implementations
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Transaction> _transactions;

        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _transactions = context.Set<Transaction>();
        }

        public async Task<PagedList<Transaction>> GetAll(TransactionRequestInputParameter parameter, bool trackChanges)
        {
            var result =  FindAll(trackChanges)
                .OrderByDescending(c => c.CreatedAt)
                .AsQueryable();

            return await PagedList<Transaction>.GetPagination(result, parameter.PageNumber, parameter.PageSize);
        }

        public async Task<Transaction> GetTransactionByInvoiceCode(string invoiceCode, bool trackChanges)
        {
            var result = await FindByCondition( c => c.InvoiceCode.Equals(invoiceCode), trackChanges).SingleOrDefaultAsync();

            return result;
        }

        public async Task<Transaction> GetTransactionByProjectId(string projectId, bool trackChanges)
        {
            var result = await FindByCondition(c => c.ProjectId.Equals(projectId), trackChanges).SingleOrDefaultAsync();

            return result;
        }

    }
}
