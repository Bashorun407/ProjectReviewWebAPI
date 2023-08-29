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
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Transaction> _transactions;

        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _transactions = context.Set<Transaction>();
        }

        public async Task<IEnumerable<Transaction>> GetAll(bool trackChanges)
        {
            var result =  FindAll(trackChanges).OrderByDescending(c => c.Amount);
            return result;
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



        /*public async Task<PagedList<Transaction>> GetAllTransaction(TransactionRequestInputParameter parameter)
        {
            var result = await _transactions.Skip((parameter.PageNumber - 1) * parameter.PageSize).Take(parameter.PageSize).ToListAsync();
            var count = await _transactions.CountAsync();

            return new PagedList<Transaction>(result, count, parameter.PageNumber, parameter.PageSize);
        }


        public async Task<Transaction> GetTransactionByInvoiceCode(string invoiceCode)
        {
            return await _transactions.FindAsync(invoiceCode);
        }

        public async Task<Transaction> GetTransactionByProjectId(string projectId)
        {
            return await _transactions.FindAsync(projectId);
        }*/
    }
}
