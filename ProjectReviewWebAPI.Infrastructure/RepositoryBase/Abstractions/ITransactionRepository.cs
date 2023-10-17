using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;

namespace ProjectReviewWebAPI.Infrastructure.RepositoryBase.Abstractions
{
    public interface ITransactionRepository : IRepository<Transaction>
    {

        Task<PagedList<Transaction>> GetAll(TransactionRequestInputParameter parameter, bool trackChanges);
        Task<Transaction> GetTransactionByProjectId(string projectId, bool trackChanges);
        Task<Transaction> GetTransactionByInvoiceCode(string invoiceCode, bool trackChanges);

    }
}
