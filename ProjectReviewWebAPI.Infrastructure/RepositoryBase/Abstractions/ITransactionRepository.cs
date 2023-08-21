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
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<PagedList<Transaction>> GetAllTransaction(TransactionRequestInputParameter parameter);
        Task<Transaction> GetTransactionByProjectId(string projectId);
        Task<Transaction> GetTransactionByInvoiceCode(string invoiceCode);
        Task<PagedList<Transaction>> GetTransactionByEmail(string email);
    }
}
