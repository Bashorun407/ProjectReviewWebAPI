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

        Task<IEnumerable<Transaction>> GetAll(bool trackChanges);
        Task<Transaction> GetTransactionByProjectId(string projectId, bool trackChanges);
        Task<Transaction> GetTransactionByInvoiceCode(string invoiceCode, bool trackChanges);
/*        Task<PagedList<Transaction>> GetAllTransaction(TransactionRequestInputParameter parameter);
        Task<Transaction> GetTransactionByProjectId(string projectId);
        Task<Transaction> GetTransactionByInvoiceCode(string invoiceCode);*/
    }
}
